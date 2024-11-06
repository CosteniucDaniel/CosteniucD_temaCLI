namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Window3D wnd = new Window3D();
            wnd.Run(30.0, 0.0);

        }
    }
}




/*using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_SimpleTriangle
{
    
    class TriangleExample : GameWindow
    {
        Random random = new Random();
        MouseState mouseState;
        KeyboardState keyboardState;
        float r=1,g=0,b=0.5f;
        private const int XYZ_SIZE = 75;
        private float cameraAngleX = 30;
        private float cameraAngleY = 30;
        private float mouseSensitivity = 0.2f;
        private MouseState lastMouseState;
        private Vector3[] triangleVertices;

        public TriangleExample() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            Title = "Triunghi fix în OpenTK";
            Meniu();
        }
        public void Meniu()
        {
            Console.Clear();
            Console.WriteLine("***************MENIU*************");
            Console.WriteLine("ESC - iesire din program");
            Console.WriteLine("A - schimba culoarea random");
            Console.WriteLine("R - reseteaza culoarea");
            Console.WriteLine("H - help");
            Console.WriteLine();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);
            string filePath = "D:\\temeEGC\\CLI\\Tema2\\coordonate.txt";
            triangleVertices = Tema2.CoordonateTriunghi.LoadCoordinates(filePath);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 1000);
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
            MouseState mouse = Mouse.GetState();

            if (mouse != lastMouseState)
            {
                float deltaX = mouse.X - lastMouseState.X;
                float deltaY = mouse.Y - lastMouseState.Y;

                cameraAngleX += deltaX * mouseSensitivity;
                cameraAngleY += deltaY * mouseSensitivity;

                cameraAngleY = MathHelper.Clamp(cameraAngleY, -89, 89); 

                lastMouseState = mouse;
            }


            if (keyboard[Key.Escape] && !keyboardState[Key.Escape])
            {
                Exit();
            }
            //if (mouse[MouseButton.Left] && !mouseState[MouseButton.Left])
            if (keyboard[Key.A] && !keyboardState[Key.A])

            {
                Console.Clear();
                Meniu();
                RandomColor();
                   Console.WriteLine($"Vertex 1: R = {r:F2}, G = {g:F2}, B = {b:F2}");
                   Console.WriteLine($"Vertex 2: R = {g:F2}, G = {r:F2}, B = {b:F2}");
                   Console.WriteLine($"Vertex 3: R = {b:F2}, G = {g:F2}, B = {r:F2}");
                   Console.WriteLine();
                
                
            }
            if (keyboard[Key.R] && !keyboardState[Key.R])
            {
                r = 1;
                g = 0;
                b = 0.5f;
            }
            if (keyboard[Key.H] && !keyboardState[Key.H])
            {
                Meniu();
            }
            mouseState = mouse;
            keyboardState = Keyboard.GetState();
        }
        private void RandomColor()
        {
            r = (float)random.NextDouble();
            g = (float)random.NextDouble();
            b = (float)random.NextDouble();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();

            //schimbarea unghiului de camera
            Matrix4 lookat = Matrix4.LookAt(
                30 * (float)Math.Cos(MathHelper.DegreesToRadians(cameraAngleY)) * (float)Math.Cos(MathHelper.DegreesToRadians(cameraAngleX)),
                30 * (float)Math.Sin(MathHelper.DegreesToRadians(cameraAngleY)),
                30 * (float)Math.Cos(MathHelper.DegreesToRadians(cameraAngleY)) * (float)Math.Sin(MathHelper.DegreesToRadians(cameraAngleX)),
                0, 0, 0,
                0, 1, 0
            );

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            DrawTriangle();
            SwapBuffers();
        }

        private void DrawTriangle()
        {

            // Desenează axa Ox (cu roșu).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);
            GL.End();

            // Desenează axa Oy (cu galben).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0); ;
            GL.End();

            // Desenează axa Oz (cu verde).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();

            if (triangleVertices != null && triangleVertices.Length == 3)
            {
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(r, g, b);
                GL.Vertex3(triangleVertices[0]);

                GL.Color3(g, r, b);
                GL.Vertex3(triangleVertices[1]);

                GL.Color3(b, g, r);
                GL.Vertex3(triangleVertices[2]);
                GL.End();
            }
        }


        [STAThread]
        static void Main(string[] args)
        {
            using (TriangleExample example = new TriangleExample())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
*/