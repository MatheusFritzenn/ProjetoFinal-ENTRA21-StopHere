using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Functions
{
    public static class ResolveView
    {
        public static bool ResolveCheckBoxBinding(string valor)
        {
            return valor == "on";
        }
    }
}
