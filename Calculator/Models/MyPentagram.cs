using Calculator.ViewModels;

namespace Calculator.Models
{
    public class MyPentagram : ViewModelBase
    {
        private MyPoint _a;
        private MyPoint _b;
        private MyPoint _c;
        private MyPoint _d;
        private MyPoint _e;

        public MyPoint A
        {
            get => _a;
            set => SetProperty(ref _a, value);
        }

        public MyPoint B
        {
            get => _b;
            set => SetProperty(ref _b, value);
        }

        public MyPoint C
        {
            get => _c;
            set => SetProperty(ref _c, value);
        }

        public MyPoint D
        {
            get => _d;
            set => SetProperty(ref _d, value);
        }

        public MyPoint E
        {
            get => _e;
            set => SetProperty(ref _e, value);
        }
    }
}
