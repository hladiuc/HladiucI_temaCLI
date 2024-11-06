using App.lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    /// <summary>
    /// The main entry point for the application. This class initializes and runs the 3D rendering window.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method, which serves as the entry point for the application.
        /// Initializes a new instance of <see cref="Window3D"/> and starts the rendering loop.
        /// </summary>
        /// <param name="args">Command-line arguments (not used in this application).</param>
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

            //using (Triangle triangle = new Triangle())
            //{
            //    triangle.Run(30.0, 0.0);
            //}

            using (Window3D window = new Window3D()) 
            {
                window.Run(30.0, 0.0);
            }
        }
    }
}
