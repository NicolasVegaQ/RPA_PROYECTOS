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

//CODIGO QUE VERIFICA SI EXISTE ELEMENTO WEB DE INTERES
stringSelectorExisteElementoWeb= String.Format(@"
    // Inicializar la variable 
    var existeElementoWeb = false
    // Construir el XPath dinámico
    var xpath = '{0}';
    // Usar el evaluador de XPath para seleccionar el elemento
    var elemento = document.evaluate(xpath, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
    // Verificar si el elemento existe
    if (elemento) {{
        existeElementoWeb = true;
    }} else {{
        existeElementoWeb = false;
    }}
    // Devuelve el resultado
    existeElementoWeb;
", stringLocalXphat);

//CODIGO QUE SELECCIONA ELEMENTO DE UN ELEMENTO TIPO SELECCION 
codigoJsSeleccionarOpcion = String.Format(@"
    var xpath = '{0}';
    var valorDeseado = '{1}';
    var valorFueSeleccionado = false;

    // Buscar el elemento select por XPath
    var selectElement = document.evaluate(xpath, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;

    if (selectElement) {{
        selectElement.value = valorDeseado;

        // Disparar el evento 'change' como si el usuario lo hubiera hecho
        var event = new Event('change', {{ bubbles: true }});
        selectElement.dispatchEvent(event);
        valorFueSeleccionado = selectElement.value === valorDeseado;
    }}
", stringLocalXphat, stringLocalOpcion);


