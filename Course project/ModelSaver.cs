using System.Diagnostics;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Course_project
{
    public class ModelSaver
    {
        private FractalRenderer fractalRenderer;

        public ModelSaver(FractalRenderer renderer)
        {
            fractalRenderer = renderer;
        }

        public void SaveModelDialog()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "OBJ files (*.obj)|*.obj|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "obj";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName = "fractal.obj"; // Предложенное имя файла по умолчанию

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFilePath = saveFileDialog.FileName;
                        SaveModelToFile(selectedFilePath);
                        MessageBox.Show($"Модель сохранена в файл {selectedFilePath}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка сохранения модели: " + ex.Message);
                    }
                }
            }
        }

        public void SaveBlenderModel()
        {
            try
            {
                string objFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fractalForBlender.obj");
                SaveModelToFile(objFilePath);

                string pythonScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "script.py");
                string blenderPath = @"C:\Program Files\Blender Foundation\Blender 4.1\blender.exe";
                string arguments = $"-b --python \"{pythonScriptPath}\"";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = blenderPath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("Blender завершил выполнение скрипта успешно.");
                        SaveBlenderProject();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при выполнении скрипта в Blender: " + error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при запуске Blender: " + ex.Message);
            }
        }

        private void SaveBlenderProject()
        {
            string sourceBlendFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "my_project.blend");

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Blender files (*.blend)|*.blend|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "blend";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName = "my_project.blend";   

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string destinationBlendFilePath = saveFileDialog.FileName;
                        File.Copy(sourceBlendFilePath, destinationBlendFilePath, true);
                        File.Delete(sourceBlendFilePath);
                        MessageBox.Show($"Проект Blender сохранен в файл {destinationBlendFilePath}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка сохранения проекта Blender: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Сохраняет модель в файл.
        /// </summary>
        /// <param name="filename">Имя файла для сохранения модели.</param>
        public void SaveModelToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Запись вершин
                foreach (var vertex in fractalRenderer.Vertices)
                {
                    writer.WriteLine($"v {vertex.X.ToString(CultureInfo.InvariantCulture)} {vertex.Y.ToString(CultureInfo.InvariantCulture)} {vertex.Z.ToString(CultureInfo.InvariantCulture)}");
                }

                // Запись граней
                foreach (var face in fractalRenderer.Faces)
                {
                    writer.WriteLine($"f {face[0] + 1}//{face[0] + 1} {face[1] + 1}//{face[1] + 1} {face[2] + 1}//{face[2] + 1} {face[3] + 1}//{face[3] + 1}");
                }
            }
        }
    }
}
