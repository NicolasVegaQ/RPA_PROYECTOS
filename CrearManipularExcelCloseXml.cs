//CREAR EXCEL SI NO EXISTE
if(!System.IO.File.Exists(rutaCsvItemsAsistidos)){
    //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(rutaCsvItemsAsistidos)){}
	using (ClosedXML.Excel.XLWorkbook workbook = new ClosedXML.Excel.XLWorkbook())
	{
	    // Crear hojas de trabajo
	    ClosedXML.Excel.IXLWorksheet hoja1 = workbook.Worksheets.Add("Hoja1");
	    //ClosedXML.Excel.IXLWorksheet hoja2 = workbook.Worksheets.Add("Hoja2");
	
	    // Guardar el archivo
	    workbook.SaveAs(rutaCsvItemsAsistidos);
	}
}

//ESCRIBIR SOBRE EL LIBRO EXCEL CREADO
using (var libro = new ClosedXML.Excel.XLWorkbook(rutaExcelTemporal))
{
    // Crear o acceder a una hoja con el nombre especificado
    var hoja = libro.Worksheet("Hoja1");

    // Escribir las cabeceras en la primera fila de Excel
    for (int col = 0; col < tablaPedidoFiltrada.Columns.Count; col++)
    {
        hoja.Cell(1, col + 1).Value = tablaPedidoFiltrada.Columns[col].ColumnName;
    }

    // Escribir los datos del DataTable celda por celda
    for (int fila = 0; fila < tablaPedidoFiltrada.Rows.Count; fila++)
    {
        for (int col = 0; col < tablaPedidoFiltrada.Columns.Count; col++)
        {
            // Escribir el valor en la celda correspondiente
            hoja.Cell(fila + 2, col + 1).Value = tablaPedidoFiltrada.Rows[fila][col];
        }
    }

    // Ajustar el ancho de las columnas
    hoja.Columns().AdjustToContents();

    // Guardar el archivo Excel
    libro.SaveAs(rutaExcelTemporal);
}



// Ruta del archivo Excel
string rutaExcel = rutaCsvItemsAsistidos;
// Crear un DataTable para almacenar los datos
System.Data.DataTable tablaDatos = new System.Data.DataTable();
// Leer el archivo Excel usando ClosedXML
using (var libro = new ClosedXML.Excel.XLWorkbook(rutaExcel))
{
		// Acceder a la hoja de trabajo
		var hoja = libro.Worksheet("Hoja1"); // Cambia el nombre de la hoja si es necesario
		
		// Definir el rango específico para la fila
		var ultimaFilaUsada = hoja.LastRowUsed();
		int ultimaFila = ultimaFilaUsada != null ? ultimaFilaUsada.RowNumber() : 1; // Si está vacío, usa fila 1
		//Definir rango especifico para la columna 
		var ultimaColUsada = hoja.LastColumnUsed();
		string ultimaCol = ultimaColUsada != null ? ultimaColUsada.ColumnLetter() : "A";
		
		// Definir el rango dinámico solo si hay datos
		var rango = hoja.Range("A1:"+ultimaCol + ultimaFila.ToString());
		
		// Leer las cabeceras desde la primera fila
		foreach (var celda in rango.FirstRow().Cells())
		{
		    string nombreColumna = celda.Value.ToString().Trim();
		    if (string.IsNullOrWhiteSpace(nombreColumna))
		        nombreColumna = "Columna_" + celda.Address.ColumnNumber.ToString();
		    tablaDatos.Columns.Add(nombreColumna);
		}
		
		// Leer los datos restantes (desde la fila 2 en adelante)
		foreach (var fila in rango.RowsUsed().Skip(1))
		{
		    System.Data.DataRow nuevaFila = tablaDatos.NewRow();
		    int columnaIndex = 0;
		
		    foreach (var celda in fila.Cells(1, tablaDatos.Columns.Count))
		    {
		        nuevaFila[columnaIndex] = celda.Value ?? System.DBNull.Value; // Manejar valores nulos
		        columnaIndex++;
		    }
		
		    tablaDatos.Rows.Add(nuevaFila);
		}
}

//SE INICIALIZA O COPIA LA TABLA
if(tablaDatos.Rows.Count == 0){
	tablaItemsAsistidos = new DataTable();
	tablaItemsAsistidos.Columns.Add("factura", typeof(string));
	tablaItemsAsistidos.Columns.Add("agregarItem", typeof(string));
	tablaItemsAsistidos.Columns.Add("proveedor", typeof(string));  
	tablaItemsAsistidos.Columns.Add("detalle", typeof(string));
}else{
	tablaItemsAsistidos = tablaDatos.Copy();
}
