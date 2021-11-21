using Asu.Constants;
using System.Text.RegularExpressions;

namespace Asu.Tags
{
    /// <summary>
    /// Representa un tag de espaciado de fuente del formato ASS.
    /// </summary>
    public class TagFsp : TagTypeDouble
    {
        public override string Name => "fsp";
        public override AssTag Type => AssTag.Fsp;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFsp"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFsp(string texto)
        {
            var regex = new Regex(RegularExpressions.RegexTagFsp);
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
        /// Inicializa una nueva instancia de la clase <see cref=""/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFsp(double arg)
        {
            Argument = arg;
        }
    }
}
