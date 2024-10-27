using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2
{
    internal class CoordonateTriunghi
    {
        public static Vector3[] LoadCoordinates(string filePath)
        {
            Vector3[] vertices = new Vector3[3];
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length && i < 3; i++)
                {
                    string[] parts = lines[i].Split(' ');
                    float x = float.Parse(parts[0]);
                    float y = float.Parse(parts[1]);
                    float z = float.Parse(parts[2]);
                    vertices[i] = new Vector3(x, y, z);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading coordinates: " + ex.Message);
            }
            return vertices;
        }
    }
}
