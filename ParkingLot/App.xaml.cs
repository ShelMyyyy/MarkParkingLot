using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParkingLot.Core.Service.DBServices;
using ParkingLot.Core.Service.Interface;
using ParkingLot.Main.Common.ViewModels;
using ParkingLot.Main.Common.Views;
using ParkingLot.ORM;
using System;
using System.Windows;

namespace ParkingLot
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            containerRegistry.RegisterInstance<IConfiguration>(config);

            var connectionString = config.GetConnectionString("DefaultConnection");
            var userOptions = new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString)
                .Options;
            containerRegistry.RegisterInstance(userOptions);

            containerRegistry.RegisterScoped<IUserDbService, UserDbService>();
           // containerRegistry.RegisterScoped<DbContext, UserDbContext>();
        }

        // 重写初始化方法，在主窗口显示之前弹出登录窗口
        protected override void OnInitialized()
        {
            // 从容器解析DialogService
            var dialogService = Container.Resolve<IDialogService>();

            var parameters = new DialogParameters();
            parameters.Add("Width", 700);
            parameters.Add("Height", 400);
            parameters.Add("Title", "登录");

            // 弹出登录窗口，这时候主窗口还没显示，不会有闪烁
             dialogService.ShowDialog("LoginView", parameters,result=>
             {
                 if (result.Result != ButtonResult.OK)
                 {
                     // 如果登录未成功，直接关闭应用
                     System.Environment.Exit(0);
                 }
             });
            // 登录成功后，再执行base初始化，显示主窗口
            base.OnInitialized();
        }
    }

}
