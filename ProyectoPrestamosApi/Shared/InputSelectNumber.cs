using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPrestamosApi.Shared
{
    public class InputSelectNumber<Generics> : InputSelect<Generics>
    {
        protected override bool TryParseValueFromString(string value, out Generics result, out string validationMessage)
        {
            if (typeof(Generics) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (Generics)(object)resultInt;
                    validationMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationMessage = "No se encuentra disponible";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationMessage);
            }
        }
    }
}
