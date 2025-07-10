string rutaCarpetaDescargas = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile),"Downloads");

if (System.IO.Directory.Exists(rutaCarpetaDescargas))
{
    string[] archivosCarpetaDescargas = System.IO.Directory.GetFiles(rutaCarpetaDescargas);

    System.Console.WriteLine(rutaCarpetaDescargas);

    foreach (string archivo in archivosCarpetaDescargas)
    {
        // Ignora archivos .exe
        if (System.IO.Path.GetExtension(archivo).ToLower() != ".exe")
        {
            try
            {
                System.IO.File.Delete(archivo);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
