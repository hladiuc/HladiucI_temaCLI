using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public struct Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }

        public Point(float x, float y,Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
    public class Triangle : GameWindow
    {

        private List<Point> triangleCoordinates = new List<Point>();
        private float rotation = 0;

        public Triangle() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            Title = "Triangle";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "coordinates.txt";
            string filePath = Path.Combine(currentDirectory, fileName);

            if (File.Exists(filePath)) {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] list = line.Split(' ');
                            Point point = new Point( float.Parse(list[0] ) , float.Parse(list[1] ) , Color.Red );
                            triangleCoordinates.Add(point);
                        }
                    }
                    Console.WriteLine("Coordinates copied!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            } else
            {
                // hard-coded if file does not exist
                triangleCoordinates.Add(new Point(-0.5f, -0.5f, Color.Red));
                triangleCoordinates.Add(new Point(0.5f, -0.5f, Color.Red));
                triangleCoordinates.Add(new Point(0.0f, 0.5f, Color.Red));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (keyboard[Key.Escape])
            {
                Exit();
            }

            if (keyboard[Key.X])
            {
                Random rand = new Random();
                for (int index = 0; index < triangleCoordinates.Count; index++)
                {
                    triangleCoordinates[index] = new Point(triangleCoordinates[index].X, triangleCoordinates[index].Y, GetRandomColor(rand));
                }

                triangleCoordinates.ForEach(triangle => {
                    Console.WriteLine($"X = {triangle.X} Y = {triangle.Y} Color = {triangle.Color.ToString()}");
                });

            }

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                rotation += 0.01f * mouse.X;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0, 0, 0);
            GL.Rotate(rotation, 0, 0, 1);

            GL.Begin(PrimitiveType.Triangles);

            triangleCoordinates.ForEach(triangle => {
                GL.Color3(triangle.Color);
                GL.Vertex2(triangle.X , triangle.Y);
            });

            GL.End();

            SwapBuffers();
        }

        private Color GetRandomColor(Random rand)
        {
            int r = rand.Next(0, 256);
            int g = rand.Next(0, 256);
            int b = rand.Next(0, 256);

            return Color.FromArgb(r, g, b);
        }
    }
}
