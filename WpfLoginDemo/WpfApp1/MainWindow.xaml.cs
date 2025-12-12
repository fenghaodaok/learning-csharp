using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // === 加上这一行！这就是“注入灵魂” ===
            var vm = new LoginViewModel();
            this.DataContext = vm;

            vm.OnLoginSuccess = () =>
            {
                // 1. 创建新窗口
                var regWindow = new RegistrationWindow();

                // 2. 显示新窗口
                regWindow.Show();

                // 3. 关闭当前登录窗口
                this.Close();
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("恭喜你，C# 环境配置成功！");
        }
    }
}