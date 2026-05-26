using System.Windows;
using System.Windows.Controls;

namespace ParkingLot.Main.Core.Extensions
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty PasswordExProperty =
            DependencyProperty.RegisterAttached(
                nameof(GetPasswordEx),
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
                // 避免在用户输入时产生循环更新
                if (passwordBox.Password != (e.NewValue?.ToString() ?? string.Empty))
                {
                    passwordBox.Password = e.NewValue?.ToString() ?? string.Empty;
                }
            }
        }
    }
}



