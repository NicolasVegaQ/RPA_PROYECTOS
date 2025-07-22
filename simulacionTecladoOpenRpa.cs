//Usando codigo c#
System.Threading.Thread.Sleep(1000);
System.Windows.Forms.SendKeys.SendWait(strRutaPdfs);
System.Threading.Thread.Sleep(500);
System.Windows.Forms.SendKeys.SendWait("{ENTER}");

//Usando AutoHokey
SetKeyDelay, 100, 50
Send {Tab}
SendInput %usuarioWorldOffice%
Send {Tab}
SendInput %passWorldOffice%
Send {Tab}
Send {Enter}
