// Ruta del script de Python
string pythonPath = conf["RUTA_PYTHON_EXE"].ToString().Trim(); // Ruta de Python
string scriptPath = conf["RUTA_PYTHON_CREAR_CARPETA_FTP"].ToString().Trim(); // Ruta del script

// Crear el proceso de Python
var startInfo = new System.Diagnostics.ProcessStartInfo()
{
    FileName = pythonPath,
    Arguments = "\"" + scriptPath + "\"",
    RedirectStandardOutput = true,
    RedirectStandardError = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

// Ejecutar el proceso
using (var process = System.Diagnostics.Process.Start(startInfo))
{
    process.WaitForExit();
    string output = process.StandardOutput.ReadToEnd();
    string error = process.StandardError.ReadToEnd();

    // Imprimir la salida y los errores (opcional)
    Console.WriteLine("Salida: " + output);
    Console.WriteLine("Error: " + error);
}
