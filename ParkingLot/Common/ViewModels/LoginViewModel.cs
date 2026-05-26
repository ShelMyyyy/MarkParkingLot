using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Main.Common.ViewModels
{
    public class LoginViewModel : BaseViewModel, IDialogAware
    {

        #region 属性
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        private string _username;
        private string _password;
        private bool _rememberPassword;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool RememberPassword
        {
            get => _rememberPassword;
            set => SetProperty(ref _rememberPassword, value);
        }
        #endregion
        /// <summary>
        /// 用来关闭窗口的开关
        /// </summary>
        public DialogCloseListener RequestClose { get; } 

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.TryGetValue("Title", out string title))
            {
                Title = title;
            }
        }


        #region 命令
         private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLogin, CanExecuteLogin));

        private DelegateCommand _forgotPasswordCommand;
        public DelegateCommand ForgotPasswordCommand =>
            _forgotPasswordCommand ?? (_forgotPasswordCommand = new DelegateCommand(ExecuteForgotPassword));
        #endregion

       

        private void ExecuteForgotPassword()
        {
            // 忘记密码逻辑
        }

        private void ExecuteLogin()
        {
            // 实现登录逻辑，例如验证用户名和密码
            if (Username == "admin" && Password == "123456")
            {
                // 登录成功
            }
            else
            {
                // 登录失败
            }
        }

        private bool CanExecuteLogin()
        {
            //return true;
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

    }
}
