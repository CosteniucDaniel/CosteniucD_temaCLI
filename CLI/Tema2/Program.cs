using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_SimpleCube
{
    class SquareExample : GameWindow
    {
        private float cubePosX = 0.0f;
        private float cubePosY = 0.0f;
        private bool isDragging = false; //variabila pentru a sti dacă cubul este mutat
        private float lastMousePosX, lastMousePosY; //ultima pozitie cunoscută a mouse-ului

        public SquareExample() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            Console.WriteLine("Muta patratul folosind tastele w,a,s,d si mouseul");
            Title = "Mutare patrat în OpenTK";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState keyboard = Keyboard.GetState();
            // Controlul cubului prin apasarea tastelor w,a,s,d
            float speed = 0.1f;
            if (keyboard[Key.W])
            {
                cubePosY += speed;
            }
            if (keyboard[Key.S])
            {
                cubePosY -= speed;
            }
            if (keyboard[Key.A])
            {
                cubePosX -= speed;
            }
            if (keyboard[Key.D])
            {
                cubePosX += speed;
            }
            if (keyboard[Key.Escape])
            {
                Exit();
            }
            MouseState mouse = Mouse.GetState();



            // Controlul mutarii cubului prin mouse
            if (mouse[MouseButton.Left])
            {
                if (!isDragging)
                {
                    
                    isDragging = true;
                    lastMousePosX = mouse.X;
                    lastMousePosY = mouse.Y;
                }
                else
                {
                    
                    float deltaX = (mouse.X - lastMousePosX) * 0.01f;
                    float deltaY = (mouse.Y - lastMousePosY) * 0.01f;

                    cubePosX += deltaX;
                    cubePosY -= deltaY;

                    lastMousePosX = mouse.X;
                    lastMousePosY = mouse.Y;
                }
            }
            else
            {
                
                isDragging = false;
            }

           
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity(); // resetare matrice

            GL.Translate(cubePosX, cubePosY, -10.0f); // Poz camera


            DrawSquare();

            SwapBuffers(); 
        }

        private void DrawSquare()
        {
            GL.Begin(PrimitiveType.Quads);


            GL.Color3(Color.Red);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.End(); 
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SquareExample example = new SquareExample())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
