/*
git remote add origin https://github.com/NicolasVegaQ/RPA_PROYECTOS.git
git branch -M main
git push -u origin main
/*

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


/* #################################### VERSION QUE SOLO USA LA PETICION POST PARA OBTENER DE UNA VEZ LA SOLUCION ########################*/
// 🔹 Ruta de la imagen CAPTCHA
string rutaImagen = @"C:\Users\venic\Downloads\captcha.png";

// 🔹 Convertir la imagen a Base64 (todo en una secuencia sin métodos)
byte[] imagenBytes;
string base64Image = "";
imagenBytes = System.IO.File.ReadAllBytes(rutaImagen);
base64Image = System.Convert.ToBase64String(imagenBytes);


// 🔹 URL del servicio CaptchaAI
string url = urlCaptchaIa;

// 🔹 Cliente HTTP sin using
System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

// 🔹 Crear el contenido de la solicitud
System.Net.Http.MultipartFormDataContent formData = new System.Net.Http.MultipartFormDataContent();
formData.Add(new System.Net.Http.StringContent(apiKey), "key");
formData.Add(new System.Net.Http.StringContent("base64"), "method");
formData.Add(new System.Net.Http.StringContent(base64Image), "body");
formData.Add(new System.Net.Http.StringContent("1"), "json"); // Pedimos respuesta en JSON

try
{
    // 🔹 Hacer la solicitud POST
    System.Net.Http.HttpResponseMessage response = client.PostAsync(url, formData).Result;
    string responseContent = response.Content.ReadAsStringAsync().Result;

    // 🔹 Procesar la respuesta JSON sin métodos
    jsonResponse = Newtonsoft.Json.Linq.JObject.Parse(responseContent);

    if ((int)jsonResponse["status"] == 1)
    {
        solucionCaptcha = jsonResponse["request"] == null ? "400":jsonResponse["request"].ToString();
    }
    else
    {
        solucionCaptcha = "400";
    }
}
catch (System.Exception ex){

    solucionCaptcha = "400";
    
}finally{
    // 🔹 Cerrar cliente HTTP manualmente
    client.Dispose();
}
