string carpetaDescargas = System.IO.Path.Combine(
    System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile),
    "Downloads"
);

string[] archivos = System.IO.Directory.GetFiles(carpetaDescargas)
    .Where(f => f.EndsWith(".xlsx") || f.EndsWith(".xls"))
    .ToArray();

if (archivos != null && archivos.Length > 0)
{
    string rutaExcel = archivos[0];
    System.Data.DataTable tablaDatos = new System.Data.DataTable();

    // Crear instancia de Excel
    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel.Workbook libro = excelApp.Workbooks.Open(rutaExcel);
    Microsoft.Office.Interop.Excel.Worksheet hoja = (Microsoft.Office.Interop.Excel.Worksheet)libro.Sheets[1];

    Microsoft.Office.Interop.Excel.Range usedRange = hoja.UsedRange;
    int filas = usedRange.Rows.Count;
    int columnas = usedRange.Columns.Count;

    // Leer cabeceras (fila 1)
    for (int col = 1; col <= columnas; col++)
    {
        object celda = (usedRange.Cells[1, col] as Microsoft.Office.Interop.Excel.Range).Value2;
        string nombreColumna = celda != null ? celda.ToString().Trim() : "Columna_" + col;
        tablaDatos.Columns.Add(nombreColumna);
    }

    // Leer los datos (desde fila 2)
    for (int fila = 2; fila <= filas; fila++)
    {
        System.Data.DataRow nuevaFila = tablaDatos.NewRow();
        for (int col = 1; col <= columnas; col++)
        {
            object celda = (usedRange.Cells[fila, col] as Microsoft.Office.Interop.Excel.Range).Value2;
            nuevaFila[col - 1] = celda ?? System.DBNull.Value;
        }
        tablaDatos.Rows.Add(nuevaFila);
    }

    // Cerrar y liberar
    libro.Close(false);
    excelApp.Quit();

    System.Runtime.InteropServices.Marshal.ReleaseComObject(hoja);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(libro);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

    // Inicializar tabla final
    if (tablaDatos.Rows.Count == 0)
    {
        tablaRemisionesDiarias = new System.Data.DataTable();
    }
    else
    {
        tablaRemisionesDiarias = tablaDatos.Copy();
    }
}
