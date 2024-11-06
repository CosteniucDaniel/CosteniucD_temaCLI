using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using Tema2;

namespace ConsoleApp4
{
    class Window3D : GameWindow
    {

        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private Randomizer rando;
        private Triangle3D firstTriangle;
        private Axes ax;
        private bool GRAVITY = true;

        private List<Objectoid> rainOfObject;
     

        // CONST
        private Color DEFAULT_BACK_COLOR = Color.LightSteelBlue;


        public Window3D() : base(1280, 768, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            rando = new Randomizer();
            firstTriangle = new Triangle3D(rando);

            ax = new Axes();
            rainOfObject = new List<Objectoid>();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            previousMouse = Mouse.GetState();


            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // setare fundal
            GL.ClearColor(DEFAULT_BACK_COLOR);

            // setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // setare proiectie/con vizualizare
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // setare ochi
            Matrix4 ochi = Matrix4.LookAt(100, 110, 80, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref ochi);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);


            // LOGIC CODE
            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();
            //MouseState mouse = Mouse.GetState();


            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }

            if (currentKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                DisplayHelp();
            }

            if (currentKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BACK_COLOR);
            }

            if (currentKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(rando.GenerateColor());
            }

            // triangle manipulation
            if (currentKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
                firstTriangle.ToggleVisibility();
            }

            if (currentKeyboard[Key.X] && !previousKeyboard[Key.X])
            {
                firstTriangle.DiscoMode();
            }


            if (currentKeyboard[Key.P] && !previousKeyboard[Key.P])
            {
                firstTriangle.TogglePolygonMode();
            }

            if (currentKeyboard[Key.M] && !previousKeyboard[Key.M])
            {
                firstTriangle.Morph();
            }

            if (currentKeyboard[Key.N])
            {
                firstTriangle.Morph2();
            }
            if (currentMouse[MouseButton.Left] && !previousMouse[MouseButton.Left])
            {
                var newObject = new Objectoid(GRAVITY);
                rainOfObject.Add(newObject);
                //Console.WriteLine($"Objectoid adăugat. Total obiecte: {rainOfObject.Count}");
            }

            if (currentMouse[MouseButton.Right] && !previousMouse[MouseButton.Right])
            {
                var newObject = new Objectoid(GRAVITY);
                rainOfObject.Clear();
                //Console.WriteLine($"Objectoid adăugat. Total obiecte: {rainOfObject.Count}");
            }
            if (currentKeyboard[Key.G] && !previousKeyboard[Key.G])
            {
                GRAVITY = !GRAVITY;
            }


            foreach (Objectoid obj in rainOfObject)
            {
                obj.UpdatePosition(GRAVITY);
            }
            previousMouse = currentMouse;
            previousKeyboard = currentKeyboard;
            // END logic code
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // RENDER CODE
            //firstTriangle.Draw();
            ax.Draw();
            
            
            foreach (Objectoid obj in rainOfObject)
            {
                obj.Draw();
            }
            // END render code
            SwapBuffers();

        }

        private void DisplayHelp()
        {
            Console.WriteLine("\n     MENU");
            Console.WriteLine(" H - meniu ajutor");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" R - resetare scena");
            Console.WriteLine(" B - schimbare culoare de fundal");
            Console.WriteLine(" Clik stanga - adaugare obiect");
            Console.WriteLine(" Clik dreapta - sterge obiectele");
            Console.WriteLine(" G - Opreste/porneste gravitatia");
            
        }

    }
}
