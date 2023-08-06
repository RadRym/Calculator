using Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class MyFillet : MainViewModel
    {
        private float length;
        private float fillet1;
        private float fillet2;
        private float fillet3;
        private float fillet4;
        private float angle;
        public MyFillet(float filletAngle, float filletLength)
        {
            angle = filletAngle;
            length = filletLength;
        }
        public float FilletLength
        {
            get => length;
            set
            {
                if (SetProperty(ref length, value))
                    UpdatePropertiesBasedOnFilletLength();
            }
        }
        private void UpdatePropertiesBasedOnFilletLength()
        {
            Fillet1 = (int)(FilletLength * Math.Sin(angle.ToRad()));
            Fillet2 = (int)(FilletLength * Math.Cos(angle.ToRad()));
            if (angle > 45)
            {
                Fillet3 = 0;
                Fillet4 = (int)((FilletLength / 2) / Math.Cos(angle.ToRad()) - Fillet2);
            }
            else
            {
                Fillet4 = 0;
                Fillet3 = (int)((FilletLength / 2) / Math.Sin(angle.ToRad()) - Fillet1);
            }
        }
        public float Fillet1
        {
            get { return fillet1; }
            set
            {
                if (fillet1 != value)
                {
                    fillet1 = value;
                    OnPropertyChanged("Fillet1");
                }
            }
        }
        public float Fillet2
        {
            get { return fillet2; }
            set
            {
                if (fillet2 != value)
                {
                    fillet2 = value;
                    OnPropertyChanged("Fillet2");
                }
            }
        }
        public float Fillet3
        {
            get { return fillet3; }
            set
            {
                if (fillet3 != value)
                {
                    fillet3 = value;
                    OnPropertyChanged("Fillet3");
                }
            }
        }
        public float Fillet4
        {
            get { return fillet4; }
            set
            {
                if (fillet4 != value)
                {
                    fillet4 = value;
                    OnPropertyChanged("Fillet4");
                }
            }
        }
    }

}
