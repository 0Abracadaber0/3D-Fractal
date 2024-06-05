using System.Drawing;
using System.Windows.Forms;
using OpenTK;

namespace Course_project
{
    /// <summary>
    /// Обрабатывает события управления для GLControl.
    /// </summary>
    public class ControlEventHandler
    {
        private GLControl glControl;
        private FractalRenderer fractalRenderer;
        private bool isMouseDown = false;
        private Point lastMousePos = new Point();

        /// <summary>
        /// Инициализирует новый экземпляр класса ControlEventHandler.
        /// </summary>
        /// <param name="glControl">GLControl для обработки событий.</param>
        /// <param name="fractalRenderer">Рендерер фрактала.</param>
        public ControlEventHandler(GLControl glControl, FractalRenderer fractalRenderer)
        {
            this.glControl = glControl;
            this.fractalRenderer = fractalRenderer;
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки мыши для GLControl.
        /// </summary>
        public void GLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                lastMousePos = e.Location;
            }
        }

        /// <summary>
        /// Обрабатывает событие перемещения мыши для GLControl.
        /// </summary>
        public void GLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                float deltaX = e.X - lastMousePos.X;
                float deltaY = e.Y - lastMousePos.Y;

                fractalRenderer.RotationX += deltaY * 0.5f;
                fractalRenderer.RotationY += deltaX * 0.5f;

                lastMousePos = e.Location;
                glControl.Invalidate();
            }
        }

        /// <summary>
        /// Обрабатывает событие отпускания кнопки мыши для GLControl.
        /// </summary>  
        public void GLControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
    }
}
