using System.Windows;
using System.Windows.Controls;

namespace ParkingLot.Main.Core.Extensions
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty PasswordExProperty =
            DependencyProperty.RegisterAttached(
                "PasswordEx",
                typeof(string),
                typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnPasswordExChanged));

        public static string GetPasswordEx(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordExProperty);
        }

        public static void SetPasswordEx(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordExProperty, value);
        }

        private static void OnPasswordExChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                // 订阅密码变化事件（只订阅一次）
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;

                // 更新密码框内容
                string newPassword = e.NewValue?.ToString() ?? string.Empty;
                if (passwordBox.Password != newPassword)
                {
                    passwordBox.Password = newPassword;
                }
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                // 将密码变化更新回附加属性
                SetPasswordEx(passwordBox, passwordBox.Password);
            }
        }
    }
}



