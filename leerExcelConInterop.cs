tablaSalidaLocal = new System.Data.DataTable();

var excelApp = new Microsoft.Office.Interop.Excel.Application();
var libro = excelApp.Workbooks.Open(rutaArchivoLocal);
var hoja = libro.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet;

// Obtener última fila con datos en columna A
int ultimaFila = ((Microsoft.Office.Interop.Excel.Range)hoja.Cells[hoja.Rows.Count, 1])
    .End[Microsoft.Office.Interop.Excel.XlDirection.xlUp].Row;

// Crear rango de lectura desde A1 hasta, por ejemplo, columna BG (ajustar si hay más columnas)
string rangoTexto = "A1:BG" + ultimaFila.ToString();
var rangoEspecifico = hoja.Range[rangoTexto];

// Convertir rango a arreglo 2D
object[,] valores = (object[,])rangoEspecifico.Value2;

// Agregar columnas desde fila 1
for (int col = 1; col <= valores.GetLength(1); col++)
{
    string nombreColumna = valores[1, col] != null
        ? valores[1, col].ToString().Trim()
        : "Columna" + col.ToString();

    tablaSalidaLocal.Columns.Add(nombreColumna, typeof(string));
}

// Agregar filas desde fila 2
for (int fila = 2; fila <= valores.GetLength(0); fila++)
{
    var nuevaFila = tablaSalidaLocal.NewRow();
    for (int col = 1; col <= valores.GetLength(1); col++)
    {
        nuevaFila[col - 1] = valores[fila, col] != null
            ? valores[fila, col].ToString()
            : string.Empty;
    }
    tablaSalidaLocal.Rows.Add(nuevaFila);
}

// Cerrar y liberar
libro.Close(false);
excelApp.Quit();

System.Runtime.InteropServices.Marshal.ReleaseComObject(hoja);
System.Runtime.InteropServices.Marshal.ReleaseComObject(libro);
System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
System.GC.Collect();
System.GC.WaitForPendingFinalizers();
