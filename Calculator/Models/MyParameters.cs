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

        public float Diagonal => (float)Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
        public float CalulatedAngle => (float)(Math.Atan(Height / Width) * (180 / Math.PI));
        public MyParameters()
        {
            width = CalculateNewWidthBasedOnDiagonalLength();
            height = CalculateNewHeightBasedOnDiagonalLength();
            edgeA = width;
            edgeB = height;
        }
        private void UpdatePropertiesBasedOnAngle()
        {
            Width = CalculateNewWidthBasedOnDiagonalLength();
            Height = CalculateNewHeightBasedOnDiagonalLength();
            NotifyPropertyChanged(nameof(Diagonal));
            NotifyPropertyChanged(nameof(CalulatedAngle));
            UpdateEdges();
            UpdateSketch();
        }
        private void UpdatePropertiesBasedOnDiagonalLength()
        {
            Width = CalculateNewWidthBasedOnDiagonalLength();
            Height = CalculateNewHeightBasedOnDiagonalLength();
            NotifyPropertyChanged(nameof(Diagonal));
            NotifyPropertyChanged(nameof(CalulatedAngle));
            UpdateEdges();
            UpdateSketch();
        }
        private void UpdatePropertiesBasedOnWidth()
        {
            Height = CalculateNewHeightBasedOnWidth();
            DiagonalLength = CalculateNewDiagonalLengthBasedOnWidthAndHeigth();
            NotifyPropertyChanged(nameof(Diagonal));
            NotifyPropertyChanged(nameof(CalulatedAngle));
            UpdateEdges();
            UpdateSketch();
        }
        private void UpdatePropertiesBasedOnHeight()
        {
            Width = CalculateNewWidthBasedOnHeight();
            DiagonalLength = CalculateNewDiagonalLengthBasedOnWidthAndHeigth();
            NotifyPropertyChanged(nameof(Diagonal));
            NotifyPropertyChanged(nameof(CalulatedAngle));
            UpdateEdges();
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
            if(Width < EdgeA)
                EdgeA = width;
            if (Height < EdgeB)
                EdgeB = height;
        }
        private void UpdatePropertiesBasedFillet()
        {
            UpdateSketch();
        }
        private float CalculateNewWidthBasedOnDiagonalLength()
        {
            float newWidth = (float)(DiagonalLength * Math.Cos(Angle.ToRad()));
            return newWidth;
        }
        private float CalculateNewHeightBasedOnDiagonalLength()
        {
            float newHeigth = (float)(DiagonalLength * Math.Sin(Angle.ToRad()));
            return newHeigth;
        }
        private float CalculateNewWidthBasedOnHeight()
        {
            float newWidth = (float)(Height / Math.Tan(Angle.ToRad()));
            return newWidth;
        }
        private float CalculateNewHeightBasedOnWidth()
        {
            float newHeigth = (float)(Width * Math.Tan(Angle.ToRad()));
            return newHeigth;
        }
        private float CalculateNewDiagonalLengthBasedOnWidthAndHeigth()
        {
            float newDiagonal = (float)Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
            return newDiagonal;
        }

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
    }
}
