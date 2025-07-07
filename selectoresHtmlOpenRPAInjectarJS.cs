boolErrorSeleccionUf = false;
// Filtrar filas que NO contengan '*'
System.Collections.Generic.IEnumerable<System.Data.DataRow> filasFiltradasEnumerable = tablaUfSeleccionado.AsEnumerable()
    .Where(row => !row.Field<System.String>(0).Contains("*"));
if(filasFiltradasEnumerable != null){
   // Verificar si hay filas filtradas antes de convertir a DataTable
   System.Data.DataTable filasFiltradas = filasFiltradasEnumerable.Any() ? filasFiltradasEnumerable.CopyToDataTable() : new System.Data.DataTable();
   // Si no hay filas filtradas, asigna "ACRE", de lo contrario, asigna el primer valor filtrado
   nombreUfSeleccionado = filasFiltradas.Rows[0][0].ToString().Trim();
   Console.WriteLine(nombreUfSeleccionado+" NOMBRE DE UF SELECCIONADO");
    
   //scriptJsSelectorUf = string.Format("document.getElementById('{0}').click();",selectoUf);
   
   // SELECTOR DE UF DEPENDIENDO DEL ARCHIVO CSV UF
   // Mapeo de estados con su número de índice en el XPath
   System.Collections.Generic.Dictionary<string, int> mapeoUf = new System.Collections.Generic.Dictionary<string, int>
   {
       { "ACRE", 2 }, { "ALAGOAS", 3 }, { "AMAPÁ", 5 }, { "AMAZONAS", 4 }, { "BAHIA", 6 },
       { "CEARÁ", 7 }, { "DISTRITO FEDERAL", 8 }, { "ESPÍRITO SANTO", 9 }, { "GOIÁS", 10 },
       { "MARANHÃO", 11 }, { "MATO GROSSO", 12 }, { "MATO GROSSO DO SUL", 13 }, { "MINAS GERAIS", 14 },
       { "PARANÁ", 15 }, { "PARAÍBA", 16 }, { "PARÁ", 17 }, { "PERNAMBUCO", 18 }, { "PIAUÍ", 19 },
       { "RIO DE JANEIRO", 20 }, { "RIO GRANDE DO NORTE", 21 }, { "RIO GRANDE DO SUL", 24 },
       { "RONDÔNIA", 22 }, { "RORAIMA", 23 }, { "SANTA CATARINA", 25 }, { "SERGIPE", 26 },
       { "SÃO PAULO", 27 }, { "TOCANTINS", 28 }
   };

   // Verificar si el estado existe en el diccionario
   int numeroLista = mapeoUf.ContainsKey(nombreUfSeleccionado) ? mapeoUf[nombreUfSeleccionado] : 1;
   // Construcción dinámica del XPath
   selectorUfSeleccionado = string.Format("/html/body/div[6]/div/ul/li[{0}]", numeroLista);
   // Mostrar el resultado
   System.Console.WriteLine(selectorUfSeleccionado);
 
   
   // Construir el script en JavaScript con String.Format()
   scriptJsClickSelectorUf = System.String.Format(@"
       // Evaluar el XPath y seleccionar el elemento
       var xpath = ""{0}"";
       var elemento = document.evaluate(xpath, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
   
       // Verificar si el elemento existe y hacer clic
       if (elemento) {{
           elemento.click(); // Hacer clic en el elemento
       }} else {{
   
       }}
   ", selectorUfSeleccionado);


}else{
  boolErrorSeleccionUf = true;
}

boolErrorSeleccionUf = false;
// Filtrar filas que NO contengan '*'
System.Collections.Generic.IEnumerable<System.Data.DataRow> filasFiltradasEnumerable = tablaUfSeleccionado.AsEnumerable()
    .Where(row => !row.Field<System.String>(0).Contains("*"));

if (filasFiltradasEnumerable != null)
{
    // Verificar si hay filas filtradas antes de convertir a DataTable
    System.Data.DataTable filasFiltradas = filasFiltradasEnumerable.Any() ? filasFiltradasEnumerable.CopyToDataTable() : new System.Data.DataTable();
    // Si no hay filas filtradas, asigna "ACRE", de lo contrario, asigna el primer valor filtrado
    nombreUfSeleccionado = filasFiltradas.Rows[0][0].ToString().Trim();
    Console.WriteLine(nombreUfSeleccionado + " NOMBRE DE UF SELECCIONADO");

    // Mapeo de estados con su ID del elemento en el HTML
    System.Collections.Generic.Dictionary<string, string> mapeoUfId = new System.Collections.Generic.Dictionary<string, string>
    {
        { "ACRE", "ufLista_1" }, { "ALAGOAS", "ufLista_2" }, { "AMAZONAS", "ufLista_3" }, { "AMAPÁ", "ufLista_4" },
        { "BAHIA", "ufLista_5" }, { "CEARÁ", "ufLista_6" }, { "DISTRITO FEDERAL", "ufLista_7" },
        { "ESPÍRITO SANTO", "ufLista_8" }, { "GOIÁS", "ufLista_9" }, { "MARANHÃO", "ufLista_10" },
        { "MINAS GERAIS", "ufLista_11" }, { "MATO GROSSO DO SUL", "ufLista_12" }, { "MATO GROSSO", "ufLista_13" },
        { "PARÁ", "ufLista_14" }, { "PARAÍBA", "ufLista_15" }, { "PERNAMBUCO", "ufLista_16" }, { "PIAUÍ", "ufLista_17" },
        { "PARANÁ", "ufLista_18" }, { "RIO DE JANEIRO", "ufLista_19" }, { "RIO GRANDE DO NORTE", "ufLista_20" },
        { "RONDÔNIA", "ufLista_21" }, { "RORAIMA", "ufLista_22" }, { "RIO GRANDE DO SUL", "ufLista_23" },
        { "SANTA CATARINA", "ufLista_24" }, { "SERGIPE", "ufLista_25" }, { "SÃO PAULO", "ufLista_26" },
        { "TOCANTINS", "ufLista_27" }
    };

    string idElementoUf = mapeoUfId.ContainsKey(nombreUfSeleccionado) ? mapeoUfId[nombreUfSeleccionado] : "ufLista_0";

    scriptJsClickSelectorUf = System.String.Format(@"
        var elemento = document.getElementById('{0}');
        if (elemento) {{
            elemento.click();
        }} else {{
            console.log('Elemento no encontrado');
        }}
    ", idElementoUf);

    System.Console.WriteLine(scriptJsClickSelectorUf);
}
else
{
    boolErrorSeleccionUf = true;
}

//SCRIPT PARA VERIFICAR SI EXISTE UN ELEMENTO WEB EN EL DOM DE LA PAGINA A AUTOMATIZAR

//Para que funcione el nombre que se le coloque a la variable de salida "estaBtnSalirPanelPrincipal" se debe colocar en el out de injectar codigo js
scritJsBtnSalirPanelPrincipal = @"
// Inicializar la variable 
var estaBtnSalirPanelPrincipal = false;

// Construir el XPath dinámico
var xpath = '/html/body/form[1]/nav/div/div[2]/ul/li[3]';


// Usar el evaluador de XPath para seleccionar el elemento
var elemento = document.evaluate(xpath, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;

// Verificar si el elemento existe
if (elemento) {
    estaBtnSalirPanelPrincipal = true;
} else {
    estaBtnSalirPanelPrincipal = false;
}

// Devuelve el resultado
estaBtnSalirPanelPrincipal;
";
