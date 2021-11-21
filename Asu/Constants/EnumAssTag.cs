namespace Asu.Constants
{
    /// <summary>
    /// Especifica tags del formato ASS documentados en Aegisub.
    /// </summary>
    public enum AssTag
    {
        I,
        B,
        U,
        S,
        Bord,
        BordX,
        BordY,
        Shad,
        ShadX,
        ShadY,
        Be,
        Blur,
        Fn,
        Fs,
        Fscx,
        Fscy,
        Fsp,
        Frz,
        Frx,
        Fry,
        Fax,
        Fay,
        Fe,
        Color1,
        Color2,
        Color3,
        Color4,
        Alpha,
        Alpha1,
        Alpha2,
        Alpha3,
        Alpha4,
        A,
        An,
        K,
        Kf,
        Ko,
        Q,
        Fx,
        R,
        Pos,
        Move,
        Org,
        Fade,
        Fad,
        T,
        ClipI,
        Clip,
        P,
        Pbo
    }

    /// <summary>
    /// Proporciona funciones estáticas para trabajar con enumerables <see cref="AssTag"/>.
    /// </summary>
    public static class TagsInfo
    {
        /// <summary>
        /// Devuelve una cadena con la escritura textual del tag especificado.
        /// </summary>
        /// <param name="tag"></param>
        public static string TagToString(AssTag tag)
        {
            switch (tag)
            {
                case AssTag.I:
                    return "i";
                case AssTag.B:
                    return "b";
                case AssTag.U:
                    return "u";
                case AssTag.S:
                    return "s";
                case AssTag.Bord:
                    return "bord";
                case AssTag.BordX:
                    return "xbord";
                case AssTag.BordY:
                    return "ybord";
                case AssTag.Shad:
                    return "shad";
                case AssTag.ShadX:
                    return "xshad";
                case AssTag.ShadY:
                    return "yshad";
                case AssTag.Be:
                    return "be";
                case AssTag.Blur:
                    return "blur";
                case AssTag.Fn:
                    return "fn";
                case AssTag.Fs:
                    return "fs";
                case AssTag.Fscx:
                    return "fscx";
                case AssTag.Fscy:
                    return "fscy";
                case AssTag.Fsp:
                    return "fsp";
                case AssTag.Frz:
                    return "frz";
                case AssTag.Frx:
                    return "frx";
                case AssTag.Fry:
                    return "fry";
                case AssTag.Fax:
                    return "fax";
                case AssTag.Fay:
                    return "fay";
                case AssTag.Fe:
                    return "fe";
                case AssTag.Color1:
                    return "c1";
                case AssTag.Color2:
                    return "c2";
                case AssTag.Color3:
                    return "c3";
                case AssTag.Color4:
                    return "c4";
                case AssTag.Alpha:
                    return "alpha";
                case AssTag.Alpha1:
                    return "1a";
                case AssTag.Alpha2:
                    return "2a";
                case AssTag.Alpha3:
                    return "3a";
                case AssTag.Alpha4:
                    return "4a";
                case AssTag.A:
                    return "a";
                case AssTag.An:
                    return "an";
                case AssTag.K:
                    return "k";
                case AssTag.Kf:
                    return "kf";
                case AssTag.Ko:
                    return "ko";
                case AssTag.Q:
                    return "q";
                case AssTag.Fx:
                    return "-";
                case AssTag.R:
                    return "r";
                case AssTag.Pos:
                    return "pos";
                case AssTag.Move:
                    return "move";
                case AssTag.Org:
                    return "org";
                case AssTag.Fade:
                    return "fade";
                case AssTag.Fad:
                    return "fad";
                case AssTag.T:
                    return "t";
                case AssTag.ClipI:
                    return "iclip";
                case AssTag.Clip:
                    return "clip";
                case AssTag.P:
                    return "p";
                case AssTag.Pbo:
                    return "pbo";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Devuelve el tag correspondiende a la cadena especificada.
        /// </summary>
        /// <param name="tag">Escritura textual del tag.</param>
        /// <returns></returns>
        public static AssTag StringToTag(string tag)
        {
            switch (tag)
            {
                case "a":
                    return AssTag.A;
                case "alpha":
                    return AssTag.Alpha;
                case "1a":
                    return AssTag.Alpha1;
                case "2a":
                    return AssTag.Alpha;
                case "3a":
                    return AssTag.Alpha;
                case "4a":
                    return AssTag.Alpha;
                case "an":
                    return AssTag.An;
                case "b":
                    return AssTag.B;
                case "be":
                    return AssTag.Be;
                case "blur":
                    return AssTag.Blur;
                case "bord":
                    return AssTag.Bord;
                case "xbord":
                    return AssTag.BordX;
                case "ybord":
                    return AssTag.BordY;
                case "clip":
                    return AssTag.Clip;
                case "iclip":
                    return AssTag.ClipI;
                case "1c":
                    return AssTag.Color1;
                case "2c":
                    return AssTag.Color2;
                case "3c":
                    return AssTag.Color3;
                case "4c":
                    return AssTag.Color4;
                case "fad":
                    return AssTag.Fad;
                case "fade":
                    return AssTag.Fade;
                case "fax":
                    return AssTag.Fax;
                case "fay":
                    return AssTag.Fay;
                case "fe":
                    return AssTag.Fe;
                case "fn":
                    return AssTag.Fn;
                case "frx":
                    return AssTag.Frx;
                case "fry":
                    return AssTag.Fry;
                case "frz":
                    return AssTag.Frz;
                case "fs":
                    return AssTag.Fs;
                case "fscx":
                    return AssTag.Fscx;
                case "fscy":
                    return AssTag.Fscy;
                case "fsp":
                    return AssTag.Fsp;
                case "fx":
                    return AssTag.Fx;
                case "i":
                    return AssTag.I;
                case "k":
                    return AssTag.K;
                case "kf":
                    return AssTag.Kf;
                case "ko":
                    return AssTag.Ko;
                case "move":
                    return AssTag.Move;
                case "org":
                    return AssTag.Org;
                case "p":
                    return AssTag.P;
                case "pbo":
                    return AssTag.Pbo;
                case "pos":
                    return AssTag.Pos;
                case "q":
                    return AssTag.Q;
                case "r":
                    return AssTag.R;
                case "s":
                    return AssTag.S;
                case "shad":
                    return AssTag.Shad;
                case "xshad":
                    return AssTag.ShadX;
                case "yshad":
                    return AssTag.ShadY;
                case "t":
                    return AssTag.T;
                case "u":
                    return AssTag.U;
                default:
                    throw new ArgumentOutOfRangeException("s", tag, "El tag debe ser soportado por Aegisub.");
            }
        }
    }
}
