using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Window : GameWindow
    {
        Vector3 placement = new Vector3(0, 0, -5.0f);
        float moveRate = 0.05f;

        int storedXCoordinate = 0;
        int storedYCoordinate = 0;

        public Window() : base(800, 600, new GraphicsMode(32, 24, 0, 8)) 
        {
            VSync = VSyncMode.On;

            Console.WriteLine("OpenGL version: " + GL.GetString(StringName.Version));
            Title = "OpenGL version: " + GL.GetString(StringName.Version) + " (immediate mode)";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.WhiteSmoke);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            MouseState mouse = Mouse.GetState();

            storedXCoordinate = mouse.X;
            storedYCoordinate = mouse.Y;
        }

        protected override void OnResize(EventArgs e)  
        { 
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(new Vector3(30, 30, 30), Vector3.Zero, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (mouse.X != storedXCoordinate)
            {
                int xDifference = mouse.X - storedXCoordinate;

                storedXCoordinate = mouse.X;

                if( xDifference < 0 )
                {
                    placement.X -= moveRate;
                } else
                {
                    placement.X += moveRate;
                }

            }

            if( mouse.Y != storedYCoordinate )
            {
                int yDifference = mouse.Y - storedYCoordinate;
                storedYCoordinate = mouse.Y;

                if (yDifference < 0)
                {
                    placement.Y += moveRate;
                }
                else
                {
                    placement.Y -= moveRate;
                }
            }

            if (keyboard[ Key.Escape ])
            {
                Exit();
            }
            
            if(keyboard[ Key.W ] )
            {
                placement.Y += moveRate;
            }

            if (keyboard[Key.S])
            {
                placement.Y -= moveRate;
            }

            if (keyboard[Key.A])
            {
                placement.X -= moveRate;
            }

            if (keyboard[Key.D])
            {
                placement.X += moveRate;
            }

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(placement);

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.Blue);
            GL.Vertex2(-0.25, -0.25);
            GL.Vertex2(0.25, -0.25);
            GL.Vertex2(0.25, 0.25);
            GL.Vertex2(-0.25, 0.25);
            GL.End();

            SwapBuffers();
        }

    }
}
