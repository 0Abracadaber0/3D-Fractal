using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Word = Microsoft.Office.Interop.Word;

/// <summary>
/// Главная форма приложения для рендеринга 3D-фракталов, предоставляющая возможности настройки, сохранения моделей и управления темами.
/// </summary>
namespace Course_project
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Перечисление тем оформления.
        /// </summary>
        private enum Theme
        {
            Light,
            Dark
        }

        /// <summary>
        /// Текущая тема оформления.
        /// </summary>
        private Theme currentTheme = Theme.Dark;
        private Color primaryColor = Color.Black;
        private Color secondaryColor = Color.White;

        private GLControl glControl;
        private FractalRenderer fractalRenderer;
        private ModelSaver modelSaver;
        private ControlEventHandler controlEventHandler;

        private Timer rotationTimer;
        private bool isRotating = false;

        /// <summary>
        /// Конструктор главной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.Text = "3D Fractal";
            this.Size = new Size(800, 800);

            glControl = new GLControl(new GraphicsMode(32, 24, 0, 4));
            glControl.Dock = DockStyle.Fill;
            this.Controls.Add(glControl);

            fractalRenderer = new FractalRenderer(glControl);
            modelSaver = new ModelSaver(fractalRenderer);
            controlEventHandler = new ControlEventHandler(glControl, fractalRenderer);

            rotationTimer = new Timer();
            rotationTimer.Interval = 3;
            rotationTimer.Tick += new EventHandler(RotationTimer_Tick);

            AttachEventHandlers();
        }

        /// <summary>
        /// Обработчик загрузки главной формы.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();  // Применяем тему при загрузке формы
        }

        /// <summary>
        /// Присоединяет обработчики событий.
        /// </summary>
        private void AttachEventHandlers()
        {
            this.Load += MainForm_Load;
            glControl.Paint += fractalRenderer.GLControl_Paint;
            glControl.Load += fractalRenderer.GLControl_Load;
            glControl.Resize += fractalRenderer.GLControl_Resize;
            glControl.MouseDown += controlEventHandler.GLControl_MouseDown;
            glControl.MouseMove += controlEventHandler.GLControl_MouseMove;
            glControl.MouseUp += controlEventHandler.GLControl_MouseUp;
        }

        /// <summary>
        /// Обработчик нажатия кнопки вращения.
        /// </summary>
        private void RotateClick(object sender, EventArgs e)
        {
            isRotating = !isRotating;
            if (isRotating)
            {
                rotationTimer.Start();
                this.Invoke((MethodInvoker)delegate {
                    rotateButton.Text = "Стоп";
                });
            }
            else
            {
                rotationTimer.Stop();
                this.Invoke((MethodInvoker)delegate {
                    rotateButton.Text = "Вращать";
                });
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки сохранения модели.
        /// </summary>
        private void SaveModelClick(object sender, EventArgs e)
        {
            modelSaver.SaveModelDialog();
        }


        /// <summary>
        /// Обработчик нажатия кнопки сохранения модели для Blender.
        /// </summary>
        private void SaveBlenderClick(object sender, EventArgs e)
        {
            modelSaver.SaveBlenderModel();
        }


        /// <summary>
        /// Обработчик нажатия кнопки "Справка".
        /// </summary>
        private void OpenHelpFile(object sender, EventArgs e)
        {
            try
            {
                string helpFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Help.chm");
                if (File.Exists(helpFilePath))
                {
                    Process.Start(helpFilePath);
                }
                else
                {
                    MessageBox.Show("Файл помощи не найден: " + helpFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии файла помощи: " + ex.Message);
            }
        }

        /// <summary>
        /// Обработчик тика таймера вращения.
        /// </summary>
        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                fractalRenderer.Rotate(1f);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во время вращения: " + ex.Message);
            }
        }

        /// <summary>
        /// Обработчик изменения дистанции.
        /// </summary>
        private void ChangedDistance(object sender, EventArgs e)
        {
            if (double.TryParse(((TextBox)sender).Text, out double result))
            {
                if (result < 0)
                {
                    result = 0;
                    distanceTextBox.Text = "0";
                }
                fractalRenderer.Distance = result;
                glControl.Invalidate();
            }
        }

        /// <summary>
        /// Обработчик изменения коэффициента расстояния.
        /// </summary>
        private void ChangedSpacingFactor(object sender, EventArgs e)
        {
            if (double.TryParse(((TextBox)sender).Text, out double result))
            {
                if (result < 0)
                {
                    result = 0;
                    spacingFactorTextBox.Text = "0";
                }
                fractalRenderer.SpacingFactor = result;
                glControl.Invalidate();
            }
        }

        /// <summary>
        /// Обработчик изменения глубины рекурсии.
        /// </summary>
        private void ChangedRecursionDepth(object sender, EventArgs e)
        {
            if (int.TryParse(((TextBox)sender).Text, out int result))
            {
                if (result >= 8)
                {
                    result = 7;
                    recursionDepthTextBox.Text = "7";
                }
                if (result < 0)
                {
                    result = 0;
                    recursionDepthTextBox.Text = "0";
                }
                fractalRenderer.RecursionDepth = result;
                glControl.Invalidate();
            }
        }

        /// <summary>
        /// Обработчик установки светлой темы.
        /// </summary>
        private void SetLightTheme(object sender, EventArgs e)
        {
            lightTheme.Checked = true;
            darkTheme.Checked = false;

            currentTheme = Theme.Light;
            ApplyTheme();
        }

        /// <summary>
        /// Обработчик установки темной темы.
        /// </summary>
        private void SetDarkTheme(object sender, EventArgs e)
        {
            lightTheme.Checked = false;
            darkTheme.Checked = true;

            currentTheme = Theme.Dark;
            ApplyTheme();
        }

        /// <summary>
        /// Применяет текущую тему к интерфейсу.
        /// </summary>
        private void ApplyTheme()
        {
            if (currentTheme == Theme.Dark)
            {
                primaryColor = Color.Black;
                secondaryColor = Color.White;
                fractalRenderer.IsLightTheme = false;

                menuStrip1.Renderer = new ToolStripProfessionalRenderer(new Colors());
            }
            else
            {
                primaryColor = Color.White;
                secondaryColor = Color.Black;
                fractalRenderer.IsLightTheme = true;

                menuStrip1.Renderer = new ToolStripProfessionalRenderer();
            }

            this.BackColor = primaryColor;
            this.ForeColor = secondaryColor;

            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                SetColor(item);
            }

            foreach (Control control in this.Controls)
            {
                ApplyThemeToControl(control);
            }

            fractalRenderer.SetBackgroundColor(primaryColor);
        }

        /// <summary>
        /// Применяет текущую тему к указанному контролу.
        /// </summary>
        private void ApplyThemeToControl(Control control)
        {
            control.BackColor = primaryColor;
            control.ForeColor = secondaryColor;

            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child);
            }
        }

        /// <summary>
        /// Устанавливает цвет для элементов меню.
        /// </summary>
        private void SetColor(ToolStripMenuItem item)
        {
            item.ForeColor = secondaryColor;
            foreach (ToolStripMenuItem it in item.DropDownItems)
            {
                SetColor(it);
            }
        }
    }
}
