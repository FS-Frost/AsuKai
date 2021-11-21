using Asu.Constants;
using System.Text.RegularExpressions;

namespace Asu.Tags
{
    /// <summary>
    /// Representa un tag de deformación lateral vertical del formato ASS.
    /// </summary>
    public class TagFay : TagTypeDouble
    {
        public override string Name => "fay";
        public override AssTag Type => AssTag.Fay;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFay"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFay(string texto)
        {
            var regex = new Regex(RegularExpressions.RegexTagFay);
            var match = regex.Match(texto);
            if (match.Success)
            {
                Argument = double.Parse(match.Groups["arg"].Value);
            }
            else
            {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFay"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFay(double arg)
        {
            Argument = arg;
        }
    }
}
