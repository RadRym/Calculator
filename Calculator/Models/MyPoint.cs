using Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class MyPoint : MainViewModel
    {
        public MyPoint(double x, double y) 
        {
            X = x; 
            Y = y;
        }
        private double x {  get; set; }
        private double y { get; set; }
        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }
        public double Y
        {
            get { return y; }
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }
        }
    }
}
