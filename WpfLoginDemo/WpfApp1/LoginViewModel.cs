using System.Windows;

// 【重要】请把下面的 WpfApp1 改成你实际的项目名字！
namespace WpfApp1
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _statusMessage;
        
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(nameof(StatusMessage)); }
        }
        public System.Action OnLoginSuccess { get; set; }
        public RelayCommand LoginCommand { get; }
        public RelayCommand RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
            RegisterCommand = new RelayCommand(ExecuteRegister);
            StatusMessage = "请输入用户名和密码"; // 默认提示
        }

        private void ExecuteLogin()
        {
            if (Username == "admin" && Password == "1234")
            {
                StatusMessage = "登录成功！欢迎回来。";
                OnLoginSuccess?.Invoke();
            }    
            else
                StatusMessage = "登录失败：用户名或密码错误。";
        }

        private void ExecuteRegister()
        {
            if (string.IsNullOrWhiteSpace(Username))
                StatusMessage = "注册失败：用户名不能为空。";
            else
                StatusMessage = $"注册成功：用户 {Username} 已创建。";
        }
    }
}