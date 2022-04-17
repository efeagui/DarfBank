using System;
using System.Collections.Generic;
using System.Text;

namespace DarfBank.Setting
{
    public class DireccionesServidor
    {
        public static string ip_server = "https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back";

        //GuardarUsuario
        public static string saveUser = "https://" + ip_server + "/Usuarios/CrearUsuario.php";

        //Listar_Usuario
        public static string ListarUser = "https://" + ip_server + "/Usuarios/ListaUsuario.php";

        //Eliminar_Usuario
        public static string DeleteSitios = "https://" + ip_server + "/Usuarios/EliminarUsuario.php";

        //Update_Usuario
        public static string UpdateSitios = "https://" + ip_server + "/Usuarios/ModificarUsuario.php";

        //Login
        public static string ListarLogin = "https://" + ip_server + "/Usuarios/Usuarios/getUsuario.php";

        public const string client_id = "VJMKF4LTPUGX5LYESDTNFJ51TGFYO5GPHDHCN3UBR0PGKRHE";
        public const string client_secret = "PRXJ0FEJY3HBHCQBCIMBX0EJWRACCOXSRWWKYYU1SKPBXYZV";
        public const string EndPointFoursquare = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";

        public static String getUrl(double latitud, double longitud)
        {
            var url = String.Format(EndPointFoursquare, latitud, longitud,
                 client_id, client_secret, DateTime.Now.ToString("yyyyMMdd"));

            return url;
        }
    }
}
