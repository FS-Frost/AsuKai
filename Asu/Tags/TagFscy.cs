using Asu.Constants;
using System.Text.RegularExpressions;

namespace Asu.Tags
{
    /// <summary>
    /// Representa un tag de escala vertical de fuente del formato ASS.
    /// </summary>
    public class TagFscy : TagTypeDouble
    {
        public override string Name => "fscy";
        public override AssTag Type => AssTag.Fscy;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TagFscy"/> en base a una cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag.</param>
        public TagFscy(string texto)
        {
            var regex = new Regex(RegularExpressions.RegexTagFscy);
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
        /// Inicializa una nueva instancia de la clase <see cref="TagFscy"/> dado su argumento.
        /// </summary>
        /// <param name="arg">Argumento del tag.</param>
        public TagFscy(double arg)
        {
            Argument = arg;
        }
    }
}
