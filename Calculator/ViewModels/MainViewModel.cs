using Calculator.Models;

namespace Calculator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private MyPentagram _myPentagram;
        private static MyPentagram _myPentagramInstance;
        private MyParameters _myParameters;
        private static MyParameters _myParametersInstance;
        public MyPentagram Pentagram
        {
            get
            {
                if (_myPentagramInstance == null)
                {
                    _myPentagramInstance = new MyPentagram() { };
                    UpdateSketch();
                };
                return _myPentagramInstance;
            }
            set
            {
                _myPentagram = value;
                OnPropertyChanged(nameof(MyPentagram));
            }
        }
        public MyParameters Parameters
        {
            get
            {
                if (_myParametersInstance == null)
                    _myParametersInstance = new MyParameters() { };
                ;
                return _myParametersInstance;
            }
            set
            {
                _myParameters = value;
                OnPropertyChanged(nameof(MyParameters));
            }
        }
        public void UpdateSketch()
        {
            Pentagram.A = new MyPoint(0, 0);
            Pentagram.B = new MyPoint(Parameters.EdgeA, 0);
            Pentagram.C = new MyPoint(Parameters.Width - Parameters.FilletInstance.Fillet3, Parameters.Height - Parameters.FilletInstance.Fillet4 - Parameters.FilletInstance.Fillet2);
            Pentagram.D = new MyPoint(Parameters.Width - Parameters.FilletInstance.Fillet3 - Parameters.FilletInstance.Fillet1, Parameters.Height - Parameters.FilletInstance.Fillet4);
            Pentagram.E = new MyPoint(0, Parameters.EdgeB);
        }
    }
}
