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

