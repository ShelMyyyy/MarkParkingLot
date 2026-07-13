using ParkingLot.Core.Service.Interface;
using ParkingLot.Models.DataBaseModels;
using System.Windows;

namespace ParkingLot.Main.Common.ViewModels
{
    public class LoginViewModel : BaseViewModel, IDialogAware
    {
        public DialogCloseListener RequestClose { get; }

        private readonly IUserDbService _iUserDbService;

        public LoginViewModel(IUserDbService IUserDbService)
        {
            _iUserDbService = IUserDbService;
            RequestClose = new DialogCloseListener();

            
        }
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


        private int _backEffect = 0;
        public int BackEffect
        {
            get => _backEffect;
            set => SetProperty(ref _backEffect, value);
        }

        private bool _isShow = false;
        public bool IsShow
        {
            get => _isShow;
            set => SetProperty(ref _isShow, value);
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        #endregion
        /// <summary>
        /// 用来关闭窗口的开关
        /// </summary>

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
            IsShow = true;
            BackEffect = 5;
            Task.Run(async () =>
            {
                try
                {
                    var user = _iUserDbService.Query<SysUsers>(x => x.Username == Username && x.PasswordHash == Password).FirstOrDefault();
                    await Task.Delay(2000);
                    BackEffect = 0;
                    IsShow = false;
                    if (user == null)
                    {
                        throw new Exception("用户名未注册或密码错误");
                    }
                    else
                    {
                        // System.Windows.MessageBox.Show("登录成功");

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            RequestClose.Invoke(new DialogResult(ButtonResult.OK));
                        });
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }

            });

        }

        private bool CanExecuteLogin()
        {
            return true;
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

    }
}
