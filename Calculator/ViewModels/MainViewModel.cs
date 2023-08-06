using Calculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private MyPentagram _myPentagram;
        private static MyPentagram _myPentagramInstance;
        private MyParameters _myParameters;
        private static MyParameters _myParametersInstance;
        public MyPentagram myPentagram
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
        public MyParameters myParameters
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
            myPentagram.A = new MyPoint(0, 0);
            myPentagram.B = new MyPoint(myParameters.EdgeA, 0);
            myPentagram.C = new MyPoint(myParameters.Width, myParameters.Height);
            myPentagram.D = new MyPoint(myParameters.Width , myParameters.Height);
            myPentagram.E = new MyPoint(0, myParameters.EdgeB);

            //myPentagram.A = new MyPoint(0, 0);
            //myPentagram.B = new MyPoint(myParameters.EdgeA, 0);
            //myPentagram.C = new MyPoint(myParameters.Width - myParameters.Fillet.Fillet3, myParameters.Height - myParameters.Fillet.Fillet4 - myParameters.Fillet.Fillet2);
            //myPentagram.D = new MyPoint(myParameters.Width - myParameters.Fillet.Fillet3 - myParameters.Fillet.Fillet1, myParameters.Height - myParameters.Fillet.Fillet4);
            //myPentagram.E = new MyPoint(0, myParameters.EdgeB);
        }
    }
}
