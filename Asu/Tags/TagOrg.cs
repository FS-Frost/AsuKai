using Asu.Constants;
using System.Text.RegularExpressions;

namespace Asu.Tags
{
    /// <summary>
    /// Representa un tag de origen del formato ASS.
    /// </summary>
    public class TagOrg : Tag
    {
        public override string Name => "org";
        public override AssTag Type => AssTag.Org;

        /// <summary>
        /// Obtiene o establece el factor horizontal.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Obtiene o establece el factor vertical.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagOrg"/> dados sus argumentos.
        /// </summary>
        /// <param name="x">Factor horizontal.</param>
        /// <param name="y">Factor vertical.</param>
        public TagOrg(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref=""/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagOrg(string texto)
        {
            var regex = new Regex(RegularExpressions.RegexTagOrg);
            var match = regex.Match(texto);
            if (match.Success)
            {
                var regex2 = new Regex(RegularExpressions.RegexArgsPos);
                var match2 = regex2.Match(match.Groups["arg"].Value);
                if (match2.Success)
                {
                    X = double.Parse(match2.Groups["x"].Value);
                    Y = double.Parse(match2.Groups["y"].Value);
                }
                else
                {
                    X = 0;
                    Y = 0;
                }
            }
        }

        /// <summary>
        /// Devuelve una cadena con formato: \org(x,y).
        /// </summary>
        public override string ToString()
        {
            return string.Format("\\{0}({1},{2})", Name, X, Y);
        }
    }
}
