using Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public static class Tools
    {
        public static float ToRad(this float degrees)
        {
            return (float)(degrees * (Math.PI / 180.0));
        }
    }
}
