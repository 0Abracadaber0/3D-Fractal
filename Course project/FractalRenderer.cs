using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Course_project
{
    public class FractalRenderer
    {
        private GLControl glControl;
        private List<Vector3> vertices = new List<Vector3>();
        private List<int[]> faces = new List<int[]>();

        public IReadOnlyList<Vector3> Vertices => vertices;
        public IReadOnlyList<int[]> Faces => faces;

        public float RotationX { get; set; } = 0f;
        public float RotationY { get; set; } = 0f;
        public double Distance { get; set; } = 10.0;
        public double SpacingFactor { get; set; } = 1;
        public int RecursionDepth { get; set; } = 4;
        public bool IsLightTheme { get; set; } = false;

        public FractalRenderer(GLControl glControl)
        {
            this.glControl = glControl;
        }

        public void GLControl_Load(object sender, EventArgs e)
        {
            try
            {
                glControl.MakeCurrent();
                GL.ClearColor(Color.Black);
                SetupViewport();
                GL.Enable(EnableCap.DepthTest);
                GL.Enable(EnableCap.Multisample);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка инициализации OpenGL: " + ex.Message);
            }
        }

        private void SetupViewport()
        {
            try
            {
                int w = glControl.Width;
                int h = glControl.Height;
                GL.Viewport(0, 0, w, h);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                float aspectRatio = (float)w / h;
                float near = 0.1f;
                float far = 500f;
                float fov = 45f;
                float top = (float)Math.Tan(fov * 0.5 * Math.PI / 180.0) * near;
                float bottom = -top;
                float left = aspectRatio * bottom;
                float right = aspectRatio * top;
                GL.Frustum(left, right, bottom, top, near, far);
                GL.MatrixMode(MatrixMode.Modelview);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка настройки вьюпорта: " + ex.Message);
            }
        }

        public void GLControl_Resize(object sender, EventArgs e)
        {
            SetupViewport();
        }

        public void GLControl_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                glControl.MakeCurrent();
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.LoadIdentity();
                GL.Translate(0.0, 0.0, -Distance);
                GL.Rotate(RotationX, 1, 0, 0);
                GL.Rotate(RotationY, 0, 1, 0);
                vertices.Clear();
                faces.Clear();
                DrawFractal(0, 0, 0, 1, RecursionDepth);
                glControl.SwapBuffers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка рендеринга: " + ex.Message);
            }
        }

        private void DrawFractal(double x, double y, double z, double size, int depth)
        {
            if (depth == 0) return;

            Vector3[] cubeVertices = new Vector3[]
            {
                new Vector3((float)(x - size / 2), (float)(y - size / 2), (float)(z + size / 2)),
                new Vector3((float)(x + size / 2), (float)(y - size / 2), (float)(z + size / 2)),
                new Vector3((float)(x + size / 2), (float)(y + size / 2), (float)(z + size / 2)),
                new Vector3((float)(x - size / 2), (float)(y + size / 2), (float)(z + size / 2)),
                new Vector3((float)(x - size / 2), (float)(y - size / 2), (float)(z - size / 2)),
                new Vector3((float)(x + size / 2), (float)(y - size / 2), (float)(z - size / 2)),
                new Vector3((float)(x + size / 2), (float)(y + size / 2), (float)(z - size / 2)),
                new Vector3((float)(x - size / 2), (float)(y + size / 2), (float)(z - size / 2))
            };

            int baseIndex = vertices.Count;
            vertices.AddRange(cubeVertices);

            int[][] cubeFaces = new int[][]
            {
                new int[] { baseIndex, baseIndex + 1, baseIndex + 2, baseIndex + 3 },
                new int[] { baseIndex + 4, baseIndex + 5, baseIndex + 6, baseIndex + 7 },
                new int[] { baseIndex, baseIndex + 1, baseIndex + 5, baseIndex + 4 },
                new int[] { baseIndex + 2, baseIndex + 3, baseIndex + 7, baseIndex + 6 },
                new int[] { baseIndex + 1, baseIndex + 2, baseIndex + 6, baseIndex + 5 },
                new int[] { baseIndex, baseIndex + 3, baseIndex + 7, baseIndex + 4 }
            };

            faces.AddRange(cubeFaces);

            GL.Begin(PrimitiveType.Quads);
            Color[] faceColors = new Color[] { Color.Blue, Color.Green, Color.Yellow, Color.White, Color.Orange, Color.Red };
            if (IsLightTheme)
            {
                faceColors[3] = Color.Black;
            }
            for (int i = 0; i < cubeFaces.Length; i++)
            {
                GL.Color3(faceColors[i]);
                foreach (int vertexIndex in cubeFaces[i])
                {
                    Vector3 vertex = vertices[vertexIndex];
                    GL.Vertex3(vertex);
                }
            }
            GL.End();

            double newSize = size / 2;
            double offset = size * SpacingFactor;

            DrawFractal(x - offset, y, z, newSize, depth - 1);
            DrawFractal(x + offset, y, z, newSize, depth - 1);
            DrawFractal(x, y - offset, z, newSize, depth - 1);
            DrawFractal(x, y + offset, z, newSize, depth - 1);
            DrawFractal(x, y, z - offset, newSize, depth - 1);
            DrawFractal(x, y, z + offset, newSize, depth - 1);
        }

        public void Rotate(float angle)
        {
            RotationY += angle;
            if (RotationY > 360.0f) RotationY -= 360.0f;
            RotationX = RotationY - 5;
            glControl.Invalidate();
        }

        public void SetBackgroundColor(Color color)
        {
            try
            {
                glControl.MakeCurrent();
                GL.ClearColor(color);
                glControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка установки цвета фона: " + ex.Message);
            }
        }
    }
}
