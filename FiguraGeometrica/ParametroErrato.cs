using System;
using System.Runtime.Serialization;

namespace FiguraGeometriche
{
    [Serializable]
    internal class ParametroErrato : Exception
    {
        object param;
        public ParametroErrato()
        {
        }

        public ParametroErrato(object param)
        {
            this.param = param;
        }

        public ParametroErrato(string message) : base(message)
        {
        }

        public ParametroErrato(string message, object param) : base(message)
        {
            this.param = param;
        }

        public ParametroErrato(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParametroErrato(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "Valore parametro: " + this.param;
            return s;
        }
    }
}