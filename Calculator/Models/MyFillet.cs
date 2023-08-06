using Calculator.ViewModels;
using System;

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

        public float Angle
        {
            get => angle;
            set
            {
                if (SetProperty(ref angle, value))
                    UpdatePropertiesBasedOnFilletLength();
            }
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

        public void UpdatePropertiesBasedOnFilletLength()
        {
            Fillet1 = (float)(FilletLength * Math.Sin(angle.ToRad()));
            Fillet2 = (float)(FilletLength * Math.Cos(angle.ToRad()));

            if (angle > 45)
            {
                Fillet3 = 0;
                Fillet4 = (float)((FilletLength / 2) / Math.Cos(angle.ToRad()) - Fillet2);
            }
            else
            {
                Fillet4 = 0;
                Fillet3 = (float)((FilletLength / 2) / Math.Sin(angle.ToRad()) - Fillet1);
            }
        }

        public float Fillet1
        {
            get => fillet1;
            set => SetProperty(ref fillet1, value);
        }

        public float Fillet2
        {
            get => fillet2;
            set => SetProperty(ref fillet2, value);
        }

        public float Fillet3
        {
            get => fillet3;
            set => SetProperty(ref fillet3, value);
        }

        public float Fillet4
        {
            get => fillet4;
            set => SetProperty(ref fillet4, value);
        }
    }
}
