using Asu.Constants;

namespace Asu.Tags
{
    /// <summary>
    /// Representa un tag genérico en formato ASS.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Obtiene el nombre del tag.
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// Obtiene el tipo del tag.
        /// </summary>
        public virtual AssTag Type { get; }
    }
}
