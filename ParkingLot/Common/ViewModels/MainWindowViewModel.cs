using DryIoc;
using ParkingLot.Core.Service.Interface;
using ParkingLot.Models;
using ParkingLot.Models.DataBaseModels;
using Prism.Common;
using Prism.Dialogs;
using System.Collections.ObjectModel;

namespace ParkingLot.Main.Common.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ISysMenuDbService _imenuDbService;
        private readonly IDialogService _dialogService;

        public MainWindowViewModel(ISysMenuDbService sysMenuDbService, IDialogService dialogService)
        {
            _imenuDbService = sysMenuDbService;
            _dialogService = dialogService;
            MenuNodes= new ObservableCollection<MenuNode>();
           // ShowLoginDialog();
            OriginalMenu = (List<SysMenu>)_imenuDbService.GetMenuList();
            LoadMenus(MenuNodes,0);
        }

        #region 属性

        public ObservableCollection<MenuNode> MenuNodes { get; set; }
        public List<SysMenu> OriginalMenu { get; set; }
        #endregion

        private void ShowLoginDialog()
        {
            var parameters = new DialogParameters();
            parameters.Add("Width", 700);
            parameters.Add("Height", 400);
            parameters.Add("Title", "登录");
            _dialogService.ShowDialog("LoginView", parameters, result =>
            {
                if (result.Result != ButtonResult.OK)
                {
                    // 如果登录未成功，直接关闭应用
                    System.Environment.Exit(0);
                }
            });
        }
        private void LoadMenus(ObservableCollection<MenuNode> menuNodes,int parentId)
        {
            var menus = OriginalMenu.Where(x => x.ParentId == parentId).OrderBy(x=>x.Index).ToList();
            if (menus.Count == 0)
            {
                return;
            }
            foreach (var menu in menus)
            {
                var menuNode = new MenuNode()
                {
                    MenuHeader = menu.Header,
                    ID = menu.Id,
                    TargetView = menu.TargetView,
                    MenuIcon = menu.MenuIcon,
                    Index = menu.Index,
                    MenuType = menu.MenuType,
                    State = menu.State,
                    Children=new ObservableCollection<MenuNode>(),
                };
                menuNodes.Add(menuNode);

                LoadMenus(menuNode.Children, menu.Id);
            }
        }
    }
}
