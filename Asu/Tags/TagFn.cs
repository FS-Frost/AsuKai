using Asu.Constants;
using System.Text.RegularExpressions;

namespace Asu.Tags
{
    /// <summary>
    /// Representa un tag de fuente del formato ASS.
    /// </summary>
    public class TagFn : TagTypeString
    {
        public override string Name => "fn";
        public override AssTag Type => AssTag.Fn;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFn"/> en base a una cadena.
        /// </summary>
        /// <param name="texto"></param>
        public TagFn(string texto)
        {
            var regex = new Regex(RegularExpressions.RegexTagFn);
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
