🧩 1. Configuraciones de sesión y pantalla
🔒 Desactivar bloqueo automático de sesión:
Ir a: Computer Configuration > Administrative Templates > System > Power Management > Button Settings / Sleep Settings


⏰ 2. Desactivar temporizador de inactividad en políticas de grupo
Estas configuraciones las haces en el Editor de directivas de grupo local:

Ejecuta gpedit.msc desde el menú Inicio o Win + R.
| **Directiva**                                                  | **Estado recomendado** | **Motivo**                                                                                                 |
| -------------------------------------------------------------- | ---------------------- | ---------------------------------------------------------------------------------------------------------- |
| **Specify the system sleep timeout (plugged in)**              | Enabled, valor = 0     | Impide que el sistema entre en **modo suspensión** mientras está enchufado.                                |
| **Specify the system hibernate timeout (plugged in)**          | Enabled, valor = 0     | Impide que el sistema entre en **hibernación** al estar enchufado.                                         |
| **Turn off hybrid sleep (plugged in)**                         | Enabled                | Desactiva el **modo híbrido** (combinación de suspensión + hibernación) que puede causar errores visuales. |
| **Allow applications to prevent automatic sleep (plugged in)** | Enabled                | Permite que tu aplicación RPA (como un bot con Selenium) **evite que el sistema duerma**.                  |
| **Require a password when a computer wakes (plugged in)**      | Disabled               | Al volver del modo suspensión, no pedirá contraseña, evitando bloqueos que detienen el RPA.                |
| **Specify the unattended sleep timeout (plugged in)**          | Enabled, valor = 0     | Previene suspensión del sistema cuando está **sin usuario activo**, ideal para bots.                       |

