using System.Collections.ObjectModel;
using System.Windows; // 用于MessageBox

namespace WpfApp1
{
    public class RegistrationViewModel : ViewModelBase
    {
        // === 1. 输入框绑定的属性 ===
        private string _newName;
        private string _newAge;
        private string _newEmail;

        public string NewName
        {
            get => _newName;
            set { _newName = value; OnPropertyChanged(nameof(NewName)); }
        }

        public string NewAge
        {
            get => _newAge;
            set { _newAge = value; OnPropertyChanged(nameof(NewAge)); }
        }

        public string NewEmail
        {
            get => _newEmail;
            set { _newEmail = value; OnPropertyChanged(nameof(NewEmail)); }
        }

        // === 2. 神奇列表 (绑定到表格) ===
        // 只要往这里 Add，界面自动刷新！无需 self.ui.table.update()
        public ObservableCollection<Person> PeopleList { get; set; }

        // === 3. 命令 ===
        public RelayCommand AddCommand { get; }

        public RegistrationViewModel()
        {
            // 初始化列表
            PeopleList = new ObservableCollection<Person>();

            // 预先加两个假数据看看效果
            PeopleList.Add(new Person { Name = "张三", Age = "25", Email = "zhang@test.com" });
            PeopleList.Add(new Person { Name = "李四", Age = "30", Email = "li@test.com" });

            AddCommand = new RelayCommand(ExecuteAdd);
        }

        private void ExecuteAdd()
        {
            if (string.IsNullOrWhiteSpace(NewName))
            {
                MessageBox.Show("名字得填啊！");
                return;
            }

            // 创建新人
            var newPerson = new Person
            {
                Name = NewName,
                Age = NewAge,
                Email = NewEmail
            };

            // 【核心魔法】直接 Add，界面立刻更新
            PeopleList.Add(newPerson);

            // 清空输入框
            NewName = "";
            NewAge = "";
            NewEmail = "";
        }
    }
}