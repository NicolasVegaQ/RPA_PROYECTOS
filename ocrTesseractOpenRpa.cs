string imagePath = "";
// Ruta al ejecutable de Tesseract (puedes usar "tesseract" si está en el PATH del sistema)
string tesseractPath = @"C:\Program Files\Tesseract-OCR\tesseract.exe";

// CONFIGURACION DEL PROCESO DE TESSERACT
System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
startInfo.FileName = tesseractPath; // Ruta al ejecutable de Tesseract
startInfo.Arguments = string.Format("\"{0}\" - -l spa --psm 6", imagePath);
startInfo.RedirectStandardOutput = true; // Redirigir la salida estándar
startInfo.RedirectStandardError = true; // Redirigir los errores estándar
startInfo.UseShellExecute = false; // No usar el shell
startInfo.CreateNoWindow = true; // No crear ventana de consola

// CCREAR PROCESO
System.Diagnostics.Process process = new System.Diagnostics.Process();
process.StartInfo = startInfo;

// INICIAR PROCESO
process.Start();

// RESULTADO OBTENIDO DEL PROCESAMIENTO DE LA IMAGEN
string ocrResult = process.StandardOutput.ReadToEnd();
// Lee los errores (si los hay)
string error = process.StandardError.ReadToEnd();

// ESPERAR A QUE EL PROCESO TERMINE
process.WaitForExit();

// Verifica si hubo errores
if (!string.IsNullOrEmpty(error))
{
    System.Console.WriteLine(string.Format("Error ejecutando Tesseract: {0}", error));
}
else
{
    // Muestra el resultado del OCR
    System.Console.WriteLine(string.Format("Resultado del OCR:\n{0}", ocrResult));
}
