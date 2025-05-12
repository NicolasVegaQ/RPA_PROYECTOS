//1. ELIMINAR FILAS DE DATOS CON ID REPETIDOS
var idsProcesados = tablaIdPersonasHechos
    .AsEnumerable()
    .Select(r => r[0].ToString().TrimStart('0')) // quita ceros a la izquierda
    .ToHashSet();

//2. ELIMINAR DE UNA FILA LOS DATOS QUE ESTEN EN LA FILA A COMPARAR Y CONVERTIRLO A TABLA
var filasRestantesEnumerable = TablaDatosPersonas
    .AsEnumerable()
    .Where(r =>
        r[1] != null &&
        r[1] != System.DBNull.Value &&
        !idsProcesados.Contains(r[1].ToString().Trim())
    );
TablaDatosPersonas = filasRestantesEnumerable.Any()
    ? filasRestantesEnumerable.CopyToDataTable()
    : TablaDatosPersonas.Clone();
