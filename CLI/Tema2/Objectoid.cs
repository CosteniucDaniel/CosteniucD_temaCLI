﻿using ConsoleApp4;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2
{
    internal class Objectoid
    {
        private bool visibility;
        private bool isGravityBound;
        private Color colour;
        private List<Vector3> coordList;
        private Randomizer rando;
        private const int GRAVITY_OFFSET = 1;
        
        


        public Objectoid(bool gravity_status)
        {
            rando=new Randomizer();
            visibility = true;
            isGravityBound = gravity_status;
            colour = rando.RandomColor();
            coordList = new List<Vector3>();

            int size_offset = rando.RandomInt(3, 7);
            int height_offset = rando.RandomInt(50, 70);
            int radial_offset = rando.RandomInt(3, 10);

            coordList.Add(new Vector3(0*size_offset+radial_offset,0*size_offset + height_offset,1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset+radial_offset, 0 * size_offset+height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset+radial_offset, 0 * size_offset + height_offset,1 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 0 * size_offset + height_offset,0 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset,1 * size_offset + height_offset,1 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset,1 * size_offset + height_offset,0 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset,1 * size_offset + height_offset,1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset,1 * size_offset + height_offset,0 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));

        }
        public void Draw()
        {
            if (visibility)
            {
                GL.Color3(colour);
                GL.Begin(PrimitiveType.QuadStrip);
                foreach (Vector3 v in coordList)
                {
                    GL.Vertex3(v);
                }
                GL.End();
            }
            
        }

        public bool GroundColisionDetected()
        {
            foreach(Vector3 v in coordList)
            {
                if(v.Y <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdatePosition(bool gravity_status)
        {
            if (visibility && gravity_status && !GroundColisionDetected()) {
                
                    for(int i = 0;i<coordList.Count;i++)
                    {
                    coordList[i] = new Vector3(coordList[i].X, coordList[i].Y - GRAVITY_OFFSET, coordList[i].Z);
                    }
                 
            }
        }
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void ToggleGravity()
        {
            isGravityBound = !isGravityBound;
        }
        public void SetGravity()
        {
            isGravityBound=true;
        }
        public void UnsetGravity() {
            isGravityBound=false;
        }

    }
}
