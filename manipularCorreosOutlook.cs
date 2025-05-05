// Crear la aplicación de Outlook (de nuevo, por si ya saliste del contexto anterior)
Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
Microsoft.Office.Interop.Outlook.NameSpace outlookNS = outlookApp.GetNamespace("MAPI");

// Obtener la carpeta raíz (nombre exacto del buzón)
Microsoft.Office.Interop.Outlook.MAPIFolder carpetaRaiz = outlookNS.Folders[direccionCorreo]; // ⚠️ Reemplaza este valor
// Obtener la carpeta destino directamente
Microsoft.Office.Interop.Outlook.MAPIFolder carpetaFacturasProcesadas = carpetaRaiz.Folders["FacturasProcesadasRobot"]; // ⚠️ Asegúrate que el nombre es correcto
Microsoft.Office.Interop.Outlook.MAPIFolder carpetaBandejaSecundaria = carpetaRaiz.Folders["BandejaEntradaSecundaria"];

//FILTRAR SOLO LOS CORREOS CON ADJUNTOS Y QUE SEAN .ZIP Y MOVER LOS QUE NO TIENEN ZIP
//INICIALIZAR LISTA AUXILIARES 
List<Microsoft.Office.Interop.Outlook.MailItem> listaCorreosZip = new List<Microsoft.Office.Interop.Outlook.MailItem>();
List<Microsoft.Office.Interop.Outlook.MailItem> listaCorreosOtros = new List<Microsoft.Office.Interop.Outlook.MailItem>();

boolHayFacturasPorExtraerZip = false;

//ELIMINAR ARCHIVOS ZIP ANTIGUOS
string[] archivosZipProcesados = System.IO.Directory.GetFiles(rutaArchivosZip);
if(archivosZipProcesados.Length != 0){
	  foreach(string zip in archivosZipProcesados){
	   		System.IO.File.Delete(zip);
	  }
}

//ELIMINAR EXCEL EXTRACCION DIARIA
if(!System.IO.File.Exists(rutaBaseDatosFacturasDiarias)){
  	System.IO.File.Delete(rutaBaseDatosFacturasDiarias); 

}

if(listaCorreosRecientes != null){
	
	  // FILTRAS CORREOS QUE SOLO TENGAN .ZIP 
	  foreach (Microsoft.Office.Interop.Outlook.MailItem correo in listaCorreosRecientes)
	  {
	       bool tieneZip = false;
	   
	       if (correo.Attachments != null && correo.Attachments.Count > 0)
	       {
	            for (int i = 1; i <= correo.Attachments.Count; i++) // Empieza en 1 (colección COM)
	            {
	                 Microsoft.Office.Interop.Outlook.Attachment adjunto = correo.Attachments[i];
	                 if (adjunto.FileName.ToLower().EndsWith(".zip"))
	                 {
	                     tieneZip = true;
	                     break;
	                 }
	            }
	       }
	   
	       if (tieneZip)
	       {
	            listaCorreosZip.Add(correo);
	       }
	       else
	       {
	            listaCorreosOtros.Add(correo);
	       }
	  }
	  
	  //DESCARGAS LOS ADJUNTOS DE LA CARPETA QUE CONTIENE LOS .ZIP Y MOVER A CORREOS PROCESADOS
  	  if(listaCorreosZip != null){
			foreach(Microsoft.Office.Interop.Outlook.MailItem correo in listaCorreosZip){
					if(correo.Attachments != null && correo.Attachments.Count != 0){
							for(int i = 1; i <= correo.Attachments.Count; i++){
					                var adjunto = correo.Attachments[i];
					                string rutaDestino = System.IO.Path.Combine(rutaArchivosZip,adjunto.FileName);
					                // Guardar el archivo
					                adjunto.SaveAsFile(rutaDestino);
							}
					}
			
			        try
			        {
			            correo.Move(carpetaFacturasProcesadas);
			            Console.WriteLine("✅ Correo movido:");
			        }
			        catch
			        {
			            Console.WriteLine("❌ Error al mover correo");
			        }
					
			}
  	  
  	  }
  	  
  	  
  	  //MOVER CORREO SIN FACTURAS A BANDEJA SECUNDARIA
  	  if(listaCorreosOtros != null){
			foreach(Microsoft.Office.Interop.Outlook.MailItem correo in listaCorreosOtros){
						        try
			        {
			            correo.Move(carpetaBandejaSecundaria);
			            Console.WriteLine("✅ Correo movido:");
			        }
			        catch
			        {
			            Console.WriteLine("❌ Error al mover correo");
			        }
					
			}
  	  
  	  }
	
}


// Liberar objetos COM
System.Runtime.InteropServices.Marshal.ReleaseComObject(carpetaFacturasProcesadas);
System.Runtime.InteropServices.Marshal.ReleaseComObject(carpetaBandejaSecundaria);
System.Runtime.InteropServices.Marshal.ReleaseComObject(carpetaRaiz);
System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookNS);
System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookApp);
