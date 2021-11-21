using System.Globalization;

namespace Asu
{
    /// <summary>
    /// Proporciona funciones estáticas y generales para trabajar.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Establece la cultura del proceso actual para el uso de puntos decimales en vez de comas. Ideal para el sistema internacional.
        /// </summary>
        public static void ChangeCulture()
        {
            var customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
        }

        /// <summary>
        /// Establece la cultura del proceso actual para el uso de coma en vez de puntos.
        /// </summary>
        public static void RestoreCulture()
        {
            var customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ",";
            Thread.CurrentThread.CurrentCulture = customCulture;
        }

        /// <summary>
        /// Obtiene una cadena con la excepción base y sus mensajes anidados.
        /// </summary>
        /// <param name="e">Excepción base.</param>
        public static string GetExceptionMessages(Exception e)
        {
            return e.Message + "\n" + e.StackTrace + "\n";
        }

        /// <summary>
        /// Obtiene una cadena con los elementos de la lista separados por un caracter.
        /// </summary>
        /// <typeparam name="T">Tipo de la lista.</typeparam>
        /// <param name="list">Lista a separar.</param>
        /// <param name="separator">Separador de los elementos.</param>
        public static string ListToSeparatedString<T>(List<T> list, char separator)
        {
            var text = "";

            for (var i = 0; i < list.Count; i++)
            {
                var elemento = list[i].ToString();

                if (i == 0)
                {
                    text = elemento;
                }
                else
                {
                    text += separator + elemento;
                }
            }

            return text;
        }

        /// <summary>
        /// Obtiene una lista con todos los elementos de una cadena, filtrándolos por su separador.
        /// </summary>
        /// <param name="text">Cadena a listar.</param>
        /// <param name="separator">Separador de los elementos en la cadena.</param>
        public static List<string> StringToList(string text, char separator)
        {
            return text.Split(separator).ToList();
        }
    }
}
