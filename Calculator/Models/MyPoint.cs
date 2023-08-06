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
        private double _x {  get; set; }
        private double _y { get; set; }
        public double X
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged("X");
                }
            }
        }
        public double Y
        {
            get { return _y; }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged("Y");
                }
            }
        }
    }
}
