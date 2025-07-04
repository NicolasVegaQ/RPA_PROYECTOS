//POST PARA PEDIR SOLUCION DE RECAPTCHA V2, SE DEBE ENVIAR EN LA PETISION LA URL DE LA PAGINA Y LA CLAVE DEL CAPTCHA DE LA PAGINA

//LISTA DE ERRORES API QUE NO VALE QUE SE SIGA INTENTANDO
listaExepcionesNegocioApi = new List<string>{
	"ERROR_WRONG_USER_KEY",
	"ERROR_KEY_DOES_NOT_EXIST",
	"ERROR_ZERO_BALANCE",
	"ERROR_PAGEURL",
	"ERROR_BAD_TOKEN_OR_PAGEURL",
	"ERROR_GOOGLEKEY",
	"ERROR_WRONG_GOOGLEKEY",
	"ERROR_BAD_PARAMETERS"
};

//LISTA DE ERRORES API POR CONEXION QUE SE PUEDE SEGUIR INTENTANDO
listaExepcioneSistemaApi = new List<string>{
	"ERROR_POST",
	"ERROR_SERVER_ERROR",
	"ERROR_INTERNAL_SERVER_ERROR",
	"IP_BANNED"
};

captchaId = "";
porqueErrorCaptcha = "";
boolerrorEnvio = false;

try {
    // 🔹 Crear cliente HTTP sin using
    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

    // 🔹 Crear contenido del formulario
    System.Net.Http.FormUrlEncodedContent formData = new System.Net.Http.FormUrlEncodedContent(new[] {
        new System.Collections.Generic.KeyValuePair<string, string>("key", apiKey),
        new System.Collections.Generic.KeyValuePair<string, string>("method", "userrecaptcha"),
        new System.Collections.Generic.KeyValuePair<string, string>("googlekey", siteKey),
        new System.Collections.Generic.KeyValuePair<string, string>("pageurl", pageUrl),
        new System.Collections.Generic.KeyValuePair<string, string>("json", "1")
    });

    try {
        // 🔹 Realizar solicitud POST
        System.Net.Http.HttpResponseMessage response = client.PostAsync(urlApiPostAnticaptcha, formData).Result;
        string responseContent = response.Content.ReadAsStringAsync().Result;

        // 🔹 Analizar JSON
        Newtonsoft.Json.Linq.JObject jsonResponse = Newtonsoft.Json.Linq.JObject.Parse(responseContent);
        if ((int)jsonResponse["status"] == 1)
        {
            captchaId = jsonResponse["request"].ToString();
        }
        else
        {
            boolerrorEnvio = true;
            porqueErrorCaptcha = jsonResponse["request"] == null ? "ERROR_POST" : jsonResponse["request"].ToString();
        }
    } catch (System.Exception ex) {
        boolerrorEnvio = true;
        porqueErrorCaptcha = "ERROR_POST";
    } finally {
        client.Dispose();
    }

} catch (System.Exception ex) {
    boolerrorEnvio = true;
    porqueErrorCaptcha = "ERROR_POST";
}
