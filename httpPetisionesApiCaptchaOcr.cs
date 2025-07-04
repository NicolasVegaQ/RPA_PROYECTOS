listaErrorCaptchaRecupera = new List<string>{
    "ERROR_SERVER_ERROR",
    "ERROR_INTERNAL_SERVER_ERROR"
};

listaErrorCaptchaNoRecupera = new List<string>{
    "ERROR_WRONG_USER_KEY",
    "ERROR_KEY_DOES_NOT_EXIST",
    "ERROR_ZERO_BALANCE",
};

boolErrorNoHayImg = false;
porqueErrorCaptcha = "";
// 🔹 Ruta de la imagen CAPTCHA
try{
    string rutaImagen = rutaImagenCaptcha;
    if(System.IO.File.Exists(rutaImagen)){
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
                porqueErrorCaptcha = jsonResponse["request"] == null ? "400":jsonResponse["request"].ToString();
            }
        }
        catch (System.Exception ex){
        
            solucionCaptcha = "400";
            
        }finally{
            // 🔹 Cerrar cliente HTTP manualmente
            client.Dispose();
        }
        
    }else{
       boolErrorNoHayImg = true; //ERROR NO EXISTE RUTA
    
    }
}catch (Exception ex){
    boolErrorNoHayImg = true;  //ERROR SE PRODUCE POR NO PODER CONVERTIR LA IMAGEN A BASE 64
}
