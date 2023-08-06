using Calculator.ViewModels;
using System;

namespace Calculator.Models
{
    public class MyParameters : MainViewModel
    {
        private float width;
        private float height;
        private float diagonalLength = 100;
        private float angle = 45;
        private float edgeA;
        private float edgeB;
        private float filletEdgeLength = 0;
        private MyFillet filletInstance;

        public float Diagonal => (float)Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
        public float CalculatedAngle => (float)(Math.Atan(Height / Width) * (180 / Math.PI));

        public MyParameters()
        {
            width = CalculateNewWidthBasedOnDiagonalLength();
            height = CalculateNewHeightBasedOnDiagonalLength();
            edgeA = width;
            edgeB = height;
        }

        #region Properties

        public float Width
        {
            get => width;
            set
            {
                if (SetProperty(ref width, value))
                    UpdatePropertiesBasedOnWidth();
            }
        }

        public float Height
        {
            get => height;
            set
            {
                if (SetProperty(ref height, value))
                    UpdatePropertiesBasedOnHeight();
            }
        }

        public float DiagonalLength
        {
            get => diagonalLength;
            set
            {
                if (SetProperty(ref diagonalLength, value))
                    UpdatePropertiesBasedOnDiagonalLength();
            }
        }

        public float Angle
        {
            get => angle;
            set
            {
                if (SetProperty(ref angle, value))
                    UpdatePropertiesBasedOnAngle();
            }
        }

        public float EdgeA
        {
            get => edgeA;
            set
            {
                if (SetProperty(ref edgeA, value))
                    UpdatePropertiesBasedOnEdgeA();
            }
        }

        public float EdgeB
        {
            get => edgeB;
            set
            {
                if (SetProperty(ref edgeB, value))
                    UpdatePropertiesBasedOnEdgeB();
            }
        }

        public float FilletEdgeLength
        {
            get => filletEdgeLength;
            set
            {
                if (SetProperty(ref filletEdgeLength, value))
                {
                    FilletInstance.Angle = Angle;
                    FilletInstance.FilletLength = FilletEdgeLength;
                    FilletInstance.UpdatePropertiesBasedOnFilletLength();
                    UpdateSketch();
                }
            }
        }

        public MyFillet FilletInstance
        {
            get
            {
                if (filletInstance == null)
                    InitializeFilletInstance();

                return filletInstance;
            }
            set
            {
                filletInstance = value;
                OnPropertyChanged(nameof(FilletInstance));
            }
        }

        #endregion Properties

        #region Update Methods

        private void UpdatePropertiesBasedOnAngle()
        {
            Width = CalculateNewWidthBasedOnDiagonalLength();
            Height = CalculateNewHeightBasedOnDiagonalLength();
            NotifyPropertyChanged(nameof(Diagonal));
            NotifyPropertyChanged(nameof(CalculatedAngle));
            UpdateFilletProperties();
            UpdateEdges();
            UpdateSketch();
        }

        private void UpdatePropertiesBasedOnDiagonalLength()
        {
            Width = CalculateNewWidthBasedOnDiagonalLength();
            Height = CalculateNewHeightBasedOnDiagonalLength();
            NotifyPropertyChanged(nameof(Diagonal));
            NotifyPropertyChanged(nameof(CalculatedAngle));
            UpdateFilletProperties();
            UpdateEdges();
            UpdateSketch();
        }

        private void UpdatePropertiesBasedOnWidth()
        {
            Height = CalculateNewHeightBasedOnWidth();
            DiagonalLength = CalculateNewDiagonalLengthBasedOnWidthAndHeight();
            NotifyPropertyChanged(nameof(Diagonal));
            NotifyPropertyChanged(nameof(CalculatedAngle));
            UpdateFilletProperties();
            UpdateEdges();
            UpdateSketch();
        }

        private void UpdatePropertiesBasedOnHeight()
        {
            Width = CalculateNewWidthBasedOnHeight();
            DiagonalLength = CalculateNewDiagonalLengthBasedOnWidthAndHeight();
            NotifyPropertyChanged(nameof(Diagonal));
            NotifyPropertyChanged(nameof(CalculatedAngle));
            UpdateFilletProperties();
            UpdateEdges();
            UpdateSketch();
        }

        private void InitializeFilletInstance()
        {
            FilletInstance = new MyFillet(Angle, FilletEdgeLength);
            FilletInstance.UpdatePropertiesBasedOnFilletLength();
            UpdateSketch();
        }

        private void UpdatePropertiesBasedOnEdgeA()
        {
            UpdateSketch();
        }

        private void UpdatePropertiesBasedOnEdgeB()
        {
            UpdateSketch();
        }

        private void UpdateEdges()
        {
            if (Width < EdgeA)
                EdgeA = Width;

            if (Height < EdgeB)
                EdgeB = Height;
        }

        private float CalculateNewWidthBasedOnDiagonalLength()
        {
            float newWidth = (float)(DiagonalLength * Math.Cos(Angle.ToRad()));
            return newWidth;
        }

        private float CalculateNewHeightBasedOnDiagonalLength()
        {
            float newHeight = (float)(DiagonalLength * Math.Sin(Angle.ToRad()));
            return newHeight;
        }

        private float CalculateNewWidthBasedOnHeight()
        {
            float newWidth = (float)(Height / Math.Tan(Angle.ToRad()));
            return newWidth;
        }

        private float CalculateNewHeightBasedOnWidth()
        {
            float newHeight = (float)(Width * Math.Tan(Angle.ToRad()));
            return newHeight;
        }

        private float CalculateNewDiagonalLengthBasedOnWidthAndHeight()
        {
            float newDiagonal = (float)Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
            return newDiagonal;
        }

        private void UpdateFilletProperties()
        {
            FilletInstance.Angle = Angle;
            FilletInstance.FilletLength = FilletEdgeLength;
            FilletInstance.UpdatePropertiesBasedOnFilletLength();
        }

        #endregion Update Methods
    }
}
