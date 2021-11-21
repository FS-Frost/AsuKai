using Asu.Constants;
using System.Text.RegularExpressions;

namespace Asu.Tags
{
    /// <summary>
    /// Representa un tag de karaoke "ko" del formato ASS.
    /// </summary>
    public class TagKo : TagTypeInt
    {
        public override string Name => "ko";
        public override AssTag Type => AssTag.Ko;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagKo"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagKo(string texto)
        {
            var regex = new Regex(RegularExpressions.RegexTagKo);
            var match = regex.Match(texto);
            if (match.Success)
            {
                Argument = int.Parse(match.Groups["arg"].Value);
            }
            else
            {
                Argument = 0;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagKo"/> dado su argumento.
        /// </summary>
        /// <param name="arg"></param>
        public TagKo(int arg)
        {
            Argument = arg;
        }
    }
}
