namespace WpfApp1
{
    public class Person
    {
        public string Name { get; set; }
        public string Age { get; set; } // 用string偷懒，防止输入非数字报错，实际应为int
        public string Email { get; set; }

        // 为了方便显示，重写 ToString (可选)
        public string DisplayInfo => $"{Name} ({Age}岁)";
    }
}