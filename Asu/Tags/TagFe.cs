using Asu.Constants;
using System.Text.RegularExpressions;

namespace Asu.Tags
{
    /// <summary>
    /// Representa un tag de codificación del formato ASS.
    /// </summary>
    public class TagFe : TagTypeString
    {
        public override string Name => "fe";
        public override AssTag Type => AssTag.Fe;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFe"/> en base a una cadena.
        /// </summary>
        /// <param name="texto"></param>
        public TagFe(string texto)
        {
            var regex = new Regex(RegularExpressions.RegexTagFe);
            var match = regex.Match(texto);
            if (match.Success)
            {
                Argument = match.Groups["arg"].Value;
            }
            else
            {
                Argument = "";
            }
        }
    }
}
