using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class Program
    {
        static void Main()
        {
            //using (Window window = new Window())
            //{
            //    window.Run(30.0, 0.0);
            //}

            //using (Axis axis = new Axis())
            //{
            //    axis.Run(30.0, 0.0);
            //}

            using (Triangle triangle = new Triangle())
            {
                triangle.Run(30.0, 0.0);
            }
        }
    }
}
