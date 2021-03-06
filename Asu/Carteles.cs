using Asu.Constants;
using Asu.Tags;
using System.Text.RegularExpressions;

namespace Asu
{
    /// <summary>
    /// Proporciona funciones estáticas para trabajar carteles.
    /// </summary>
    public static class Carteles
    {
        /// <summary>
        /// Devuelve una lista con los valores interpolados entre dos colores dada una cantidad de intervalos.
        /// </summary>
        /// <param name="colorInicial">Color inicial.</param>
        /// <param name="colorFinal">Color final.</param>
        /// <param name="intervalos">Intervalos para interpolar.</param>
        public static List<string> InterpolateColors(TagTypeColor colorInicial, TagTypeColor colorFinal, int intervalos)
        {
            // Lista para valores interpolados.
            var coloresInterpolados = new List<string>();

            // Interpolando cada factor.
            var azulInterpolado = Maths.Interpolate(colorInicial.Blue, colorFinal.Blue, intervalos);
            var verdeInterpolado = Maths.Interpolate(colorInicial.Green, colorFinal.Green, intervalos);
            var rojoInterpolado = Maths.Interpolate(colorInicial.Red, colorFinal.Red, intervalos);

            // Generando lista con colores interpolados.
            var azul = string.Empty;
            var verde = string.Empty;
            var rojo = string.Empty;

            for (var i = 0; i < azulInterpolado.Count; i++)
            {
                // Obteniendo factores interpolados.
                azul = Maths.IntToHex(azulInterpolado[i], 2);
                verde = Maths.IntToHex(verdeInterpolado[i], 2);
                rojo = Maths.IntToHex(rojoInterpolado[i], 2);

                // Limitando el hexadecimal a FF (255 decimal).
                if (azul.Length > 2)
                {
                    azul = "FF";
                }

                if (verde.Length > 2)
                {
                    verde = "FF";
                }

                if (rojo.Length > 2)
                {
                    rojo = "FF";
                }

                // Agregando color interpolado.
                var color = string.Format("&H{0:00}{1:00}{2:00}&", azul, verde, rojo);
                coloresInterpolados.Add(color);
            }

            return coloresInterpolados;
        }

        /// <summary>
        /// Devuelve una lista con todos los hexadecimales dado un rango decimal.
        /// </summary>
        /// <param name="inicio">Valor inicial.</param>
        /// <param name="fin">Valor final.</param>
        public static List<string> GenerateHexList(int inicio, int fin)
        {
            var lista = new List<string>();

            for (var i = inicio; i < fin; i++)
            {
                lista.Add(Maths.IntToHex(i));
            }

            return lista;
        }

        /// <summary>
        /// Devuelve una instancia de <see cref="TagTypeColor"/> con los colores en formato rrggbb de una cadena.
        /// </summary>
        /// <param name="arg">Cadena donde filtrar los colores.</param>
        public static TagTypeColor FilterColors(string arg)
        {
            var resultado = new TagTypeColor();
            var regexColor = new Regex(RegularExpressions.RegexColor);
            var matches = regexColor.Match(arg);

            if (!matches.Success)
            {
                return resultado;
            }

            var blue = matches.Groups["blue"].Value;
            var green = matches.Groups["green"].Value;
            var red = matches.Groups["red"].Value;

            if (blue != "")
            {
                resultado.Blue = Maths.HexToInt(blue);
            }
            else
            {
                resultado.Blue = 0;
            }

            if (green != "")
            {
                resultado.Green = Maths.HexToInt(green);
            }
            else
            {
                resultado.Green = 0;
            }

            if (red != "")
            {
                resultado.Red = Maths.HexToInt(red);
            }
            else
            {
                resultado.Red = 0;
            }

            return resultado;
        }
    }
}
