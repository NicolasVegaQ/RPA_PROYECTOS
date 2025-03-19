/*######################  OMO ENVIAR PETICIONES POST A LA API USANDO CAPTCHA IA #################################  */
string apiKey = APIKEY; // Tu clave API

try
{
    // Crear cliente HTTP manualmente
    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

    try
    {
        // Crear los datos del formulario
        System.Net.Http.MultipartFormDataContent formData = new System.Net.Http.MultipartFormDataContent();
        formData.Add(new System.Net.Http.StringContent(apiKey), "key");
        formData.Add(new System.Net.Http.StringContent("base64"), "method");
        formData.Add(new System.Net.Http.StringContent(base64Image), "body"); // Imagen en formato Base64
        formData.Add(new System.Net.Http.StringContent("1"), "json"); // Solicitar respuesta en JSON

        // Realizar la solicitud POST
        string url = "https://ocr.captchaai.com/in.php";
        System.Net.Http.HttpResponseMessage response = client.PostAsync(url, formData).Result;
        string responseContent = response.Content.ReadAsStringAsync().Result;

        // Procesar la respuesta
        dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
        if (jsonResponse.status == 1)
        {
            string captchaId = jsonResponse.request; // Retorna el ID del CAPTCHA

            if (!string.IsNullOrEmpty(captchaId))
            {
                respuestaPost = captchaId;

                // Realiza la solicitud GET para consultar la solución
                //GetCaptchaSolution(apiKey, captchaId);
            }
        }
        else
        {
            respuestaPost = "ERROR";
        }
    }
    finally
    {
        // Liberar recursos manualmente
        client.Dispose();
    }
}
catch (System.Exception ex)
{
    respuestaPost = "ERROR";
}


/* ########################################### PETICION GET OBTENER EL RESULTADO DEL CAPTCHA ########################################### */
string apiKey = APIKEY; // Tu clave API
string googleKey = GOOGLEKEY; // Reemplaza con el data-sitekey de la página
string pageUrl = PAGEURL; // URL donde está el CAPTCHA

try
{
    if (!string.IsNullOrEmpty(respuestaPost) || !respuestaPost.Equals("ERROR"))
    {
        // Crear cliente HTTP manualmente
        System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        try
        {
            // Crear los datos del formulario
            System.Net.Http.MultipartFormDataContent formData = new System.Net.Http.MultipartFormDataContent();
            formData.Add(new System.Net.Http.StringContent(apiKey), "key");
            formData.Add(new System.Net.Http.StringContent("get"), "action");
            formData.Add(new System.Net.Http.StringContent(respuestaPost), "id");
            formData.Add(new System.Net.Http.StringContent("1"), "json"); // Solicitar respuesta en JSON

            string url = "https://ocr.captchaai.com/res.php"; // Endpoint para consultar el resultado

            // Realizar la solicitud POST
            System.Net.Http.HttpResponseMessage response = client.PostAsync(url, formData).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;

            // Procesar la respuesta
            dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
            respuestaGet = jsonResponse.request; // Retorna la solución
        }
        finally
        {
            // Liberar recursos manualmente
            client.Dispose();
        }
    }
}
catch (System.Exception ex)
{
    respuestaGet = "ERROR";
}
