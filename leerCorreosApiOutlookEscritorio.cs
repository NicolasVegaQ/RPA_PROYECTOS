int cantidadMaxima = 100;
int contador = 0;
// Declarar lista de salida
List<Microsoft.Office.Interop.Outlook.MailItem> listaCorreosPersonalizada = new List<Microsoft.Office.Interop.Outlook.MailItem>();

// Crear la aplicación de Outlook 
Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();

// Obtener el espacio de nombres MAPI
Microsoft.Office.Interop.Outlook.NameSpace outlookNS = outlookApp.GetNamespace("MAPI");

// Buscar la cuenta
string nombreCuenta = direccionCorreo;
Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;

foreach (Microsoft.Office.Interop.Outlook.MAPIFolder folder in outlookNS.Folders)
{
    // Aquí comparamos el nombre de la cuenta (parte izquierda del árbol)
    if (folder.Name.Contains(nombreCuenta))
    {
        inboxFolder = folder.Folders["Bandeja de entrada"]; // Usa el nombre exacto en español
        break;
    }
}

if (inboxFolder != null)
{
    Microsoft.Office.Interop.Outlook.Items mailItems = inboxFolder.Items;
    mailItems.Sort("[ReceivedTime]", true);

    foreach (object item in mailItems)
    {
        if (item is Microsoft.Office.Interop.Outlook.MailItem)
        {
            listaCorreosPersonalizada.Add((Microsoft.Office.Interop.Outlook.MailItem)item);
        }
        
        if(contador >= cantidadMaxima){
        	break;
        }
        contador = contador + 1;
    }

    System.Runtime.InteropServices.Marshal.ReleaseComObject(mailItems);
}

System.Runtime.InteropServices.Marshal.ReleaseComObject(inboxFolder);
System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookNS);
System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookApp);

// Asignar a la variable de salida
listaCorreosRecientes = listaCorreosPersonalizada;
