using Asu.Constants;
using System.Text.RegularExpressions;

namespace Asu
{
    /// <summary>
    /// Proporciona funciones estáticas para trabajar con el formato ASS.
    /// </summary>
    public static class AssFilter
    {
        /// <summary>
        /// Busca la propiedad especificada dentro de la cadena.
        /// </summary>
        /// <param name="texto">Cadena con propiedades del formato ASS.</param>
        /// <param name="propiedad">Propiedad del formato ASS.</param>
        /// <returns>Cadena con la propiedad especificada.</returns>
        public static string FilterProperty(string texto, Property propiedad)
        {
            // Propiedades de una línea.
            var tipo = string.Empty;
            var capa = string.Empty;
            var inicio = string.Empty;
            var fin = string.Empty;
            var estilo = string.Empty;
            var actor = string.Empty;
            var margenI = string.Empty;
            var margenD = string.Empty;
            var margenV = string.Empty;
            var efecto = string.Empty;
            var contenido = string.Empty;

            // Buscando coincidencias.
            var regex = new Regex(RegularExpressions.RegexProperties);
            var match = regex.Match(texto);

            // En caso de haber coincidencias...
            if (match.Success)
            {
                // Se obtienen los resultados.
                tipo = match.Groups["tipo"].Value;
                capa = match.Groups["capa"].Value;
                inicio = match.Groups["inicio"].Value;
                fin = match.Groups["fin"].Value;
                estilo = match.Groups["estilo"].Value;
                actor = match.Groups["actor"].Value;
                margenI = match.Groups["margenI"].Value;
                margenD = match.Groups["margenD"].Value;
                margenV = match.Groups["margenV"].Value;
                efecto = match.Groups["efecto"].Value;
                contenido = match.Groups["contenido"].Value;
            }

            // Entregando la propiedad solicitada.
            return propiedad switch
            {
                Property.Type => tipo,
                Property.Layer => capa,
                Property.Start => inicio,
                Property.End => fin,
                Property.Style => estilo,
                Property.Actor => actor,
                Property.MarginLeft => margenI,
                Property.MarginRight => margenD,
                Property.MarginVertical => margenV,
                Property.Effect => efecto,
                Property.Content => contenido,
                _ => contenido,
            };
        }

        /// <summary>
        /// Busca todas las propiedades del formato ASS dentro de la cadena.
        /// Las propiedades se obtienen con sus nombres: grupos["nombre"].
        /// </summary>
        /// <param name="texto">Cadena donde buscar las propiedades.</param>
        /// <returns>Colección de grupos de búsqueda Regex.</returns>
        public static GroupCollection FilterProperties(string texto)
        {
            var regex = new Regex(RegularExpressions.RegexProperties);
            var match = regex.Match(texto);
            return match.Groups;
        }

        /// <summary>
        /// Busca todos lo grupos de la forma {} dentro de la cadena.
        /// </summary>
        /// <param name="texto">Cadena donde buscar los grupos.</param>
        /// <returns>Lista de grupos de búsqueda Regex.</returns>
        public static List<Group> FilterGroups(string contenido)
        {
            var regex = new Regex(RegularExpressions.RegexGroups);
            var match = regex.Match(contenido);
            var grupos = new List<Group>();

            while (match.Success)
            {
                if (match.Groups["grupo"].Success && match.Groups["grupo"].Value != "")
                {
                    grupos.Add(match.Groups["grupo"]);
                }

                match = match.NextMatch();
            }

            return grupos;
        }

        /// <summary>
        /// Busca la primera coincidencia del tag especificado dentro de la cadena.
        /// </summary>
        /// <param name="texto">Cadena donde buscar el tag.</param>
        /// <param name="tag">Tag a buscar dentro de la cadena.</param>
        /// <returns>Grupo de búsqueda Regex.</returns>
        public static Group SearchTag(string texto, AssTag tag)
        {
            // Caso específico para el tag \t.
            if (tag == AssTag.T)
            {
                var grupos = FilterGroups(texto);
                var texto2 = "";
                foreach (var g in grupos)
                {
                    var s = g.Value;
                    if (s.Contains(@"\t("))
                    {
                        s = s.Substring(s.IndexOf(@"\t("));
                        if (s.Contains(')'))
                        {
                            texto2 = g.Value;
                            break;
                        }
                    }
                }

                // Obteniendo el patrón del tag.
                var patron2 = GetTagPattern(tag);

                // Generando la expresión regular.
                var regex2 = new Regex(patron2);

                // Buscando coincidencias.
                var matches2 = regex2.Match(texto2);

                // Retornando el resultado.
                return matches2.Groups["tag"];
            }

            // Obteniendo el patrón del tag.
            var patron = GetTagPattern(tag);

            // Agregando validación para que el tag esté entre {}.
            var pre = @"\{[^{}]*";
            var post = @"[^{}]*\}";
            patron = string.Format("{0}{1}{2}", pre, patron, post);

            // Generando la expresión regular.
            var regex = new Regex(patron);

            // Buscando coincidencias.
            var match = regex.Match(texto);

            // Retornando el resultado.
            return match.Groups["tag"];
        }

        /// <summary>
        /// Reemplaza la primera coincidencia del tag especificado dentro de la cadena.
        /// </summary>
        /// <param name="texto">Cadena con el tag a reemplazar.</param>
        /// <param name="tagOriginal">Tag a reemplazar.</param>
        /// <param name="textoNuevo">Cadena a insertar en lugar del tag. Idealmente otro tag.</param>
        /// <returns>Cadena con el tag reemplazado.</returns>
        public static string ReplaceTag(string texto, AssTag tagOriginal, string textoNuevo)
        {
            if (!TagExists(texto, tagOriginal))
            {
                return texto;
            }

            // Obteniendo el patrón del tag original.
            var regex = GetTagPattern(tagOriginal);

            // Obteniendo tag original.
            var match = new Regex(regex).Match(texto);
            var tag = match.Groups["tag"].Value;

            // Quitando el tag original.
            var texto2 = texto.Remove(match.Index, match.Length);

            // Insertando el tag nuevo en la posición donde iniciaba el original.
            texto2 = texto2.Insert(match.Index, textoNuevo);

            return texto2;
        }

        /// <summary>
        /// Verifica si un tag existe dentro de una cadena.
        /// </summary>
        /// <param name="texto">Cadena donde verificar el tag.</param>
        /// <param name="tag">Tag a verificar.</param>
        /// <returns></returns>
        public static bool TagExists(string texto, AssTag tag)
        {
            // Obteniendo el patrón del tag.
            var patron = GetTagPattern(tag);

            // Generando expresión regular.
            var regex = new Regex(patron);
            var match = regex.Match(texto);

            return match.Success;
        }

        /// <summary>
        /// Busca el patrón Regex del tag especificado.
        /// </summary>
        /// <param name="tag">Tag del cual obtener el patrón.</param>
        /// <returns>Cadena con el patrón de tag.</returns>
        public static string GetTagPattern(AssTag tag)
        {
            return tag switch
            {
                AssTag.I => RegularExpressions.RegexTagI,
                AssTag.B => RegularExpressions.RegexTagB,
                AssTag.U => RegularExpressions.RegexTagU,
                AssTag.S => RegularExpressions.RegexTagS,
                AssTag.Bord => RegularExpressions.RegexTagBord,
                AssTag.BordX => RegularExpressions.RegexTagBordX,
                AssTag.BordY => RegularExpressions.RegexTagBordY,
                AssTag.Shad => RegularExpressions.RegexTagShad,
                AssTag.ShadX => RegularExpressions.RegexTagShadX,
                AssTag.ShadY => RegularExpressions.RegexTagShadY,
                AssTag.Be => RegularExpressions.RegexTagBe,
                AssTag.Blur => RegularExpressions.RegexTagBlur,
                AssTag.Fn => RegularExpressions.RegexTagFn,
                AssTag.Fs => RegularExpressions.RegexTagFs,
                AssTag.Fscx => RegularExpressions.RegexTagFscx,
                AssTag.Fscy => RegularExpressions.RegexTagFscy,
                AssTag.Fsp => RegularExpressions.RegexTagFsp,
                AssTag.Frz => RegularExpressions.RegexTagFrz,
                AssTag.Frx => RegularExpressions.RegexTagFrx,
                AssTag.Fry => RegularExpressions.RegexTagFry,
                AssTag.Fax => RegularExpressions.RegexTagFax,
                AssTag.Fay => RegularExpressions.RegexTagFay,
                AssTag.Fe => RegularExpressions.RegexTagFe,
                AssTag.Color1 => RegularExpressions.RegexTagColor1,
                AssTag.Color2 => RegularExpressions.RegexTagColor2,
                AssTag.Color3 => RegularExpressions.RegexTagColor3,
                AssTag.Color4 => RegularExpressions.RegexTagColor4,
                AssTag.Alpha => RegularExpressions.RegexTagAlpha,
                AssTag.Alpha1 => RegularExpressions.RegexTagAlpha1,
                AssTag.Alpha2 => RegularExpressions.RegexTagAlpha2,
                AssTag.Alpha3 => RegularExpressions.RegexTagAlpha3,
                AssTag.Alpha4 => RegularExpressions.RegexTagAlpha4,
                AssTag.A => RegularExpressions.RegexTagA,
                AssTag.An => RegularExpressions.RegexTagAn,
                AssTag.K => RegularExpressions.RegexTagK,
                AssTag.Kf => RegularExpressions.RegexTagKf,
                AssTag.Ko => RegularExpressions.RegexTagKo,
                AssTag.Q => RegularExpressions.RegexTagQ,
                AssTag.Fx => RegularExpressions.RegexTagFx,
                AssTag.R => RegularExpressions.RegexTagR,
                AssTag.Pos => RegularExpressions.RegexTagPos,
                AssTag.Move => RegularExpressions.RegexTagMove,
                AssTag.Org => RegularExpressions.RegexTagOrg,
                AssTag.Fade => RegularExpressions.RegexTagFade,
                AssTag.Fad => RegularExpressions.RegexTagFad,
                AssTag.T => RegularExpressions.RegexTagT,
                AssTag.ClipI => RegularExpressions.RegexTagClipI,
                AssTag.Clip => RegularExpressions.RegexTagClip,
                AssTag.P => RegularExpressions.RegexTagP,
                AssTag.Pbo => RegularExpressions.RegexTagPbo,
                _ => "",
            };
        }

        /// <summary>
        /// Establece si un texto es un grupo de la forma {};
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static bool IsTagGroup(string texto)
        {
            return texto.StartsWith("{") && texto.EndsWith("}");
        }

        /// <summary>
        /// Establece si un texto es un grupo con al menos un tag de karaoke.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static bool IsKaraokeGroup(string texto)
        {
            if (!IsTagGroup(texto))
            {
                return false;
            }

            var tagsKaraoke = new AssTag[] { AssTag.K, AssTag.Kf, AssTag.Ko };
            var isKaraokeGroup = false;

            foreach (var tag in tagsKaraoke)
            {
                if (TagExists(texto, tag))
                {
                    isKaraokeGroup = true;
                    break;
                }
            }

            return isKaraokeGroup;
        }
    }
}
