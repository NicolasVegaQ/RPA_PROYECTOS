🧩 1. Configuraciones de sesión y pantalla
🔒 Desactivar bloqueo automático de sesión:
Ir a: Configuración > Cuentas > Opciones de inicio de sesión

Desactiva: Requerir inicio de sesión tras inactividad

⏰ Desactivar temporizador de inactividad en políticas de grupo:
Ejecuta gpedit.msc y navega a:
Qué debes configurar para evitar interrupciones en el RPA:
Te recomiendo modificar manualmente estas directivas. Aquí están las más importantes y cómo configurarlas:

Opción	Estado recomendado	Motivo
Specify the system sleep timeout (plugged in)	Enabled, valor = 0	Evita que el sistema entre en suspensión
Specify the system hibernate timeout (plugged in)	Enabled, valor = 0	Previene hibernación cuando está conectado
Turn off hybrid sleep (plugged in)	Enabled	El modo híbrido puede generar pantallas negras
Allow applications to prevent automatic sleep (plugged in)	Enabled	Permite que el RPA impida suspensión automática
Require a password when a computer wakes (plugged in)	Disabled	Evita que el sistema se bloquee tras suspenderse
Specify the unattended sleep timeout (plugged in)	Enabled, valor = 0	Previene suspensión cuando está desatendido
