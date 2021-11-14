using Bootcamp.Workshop.Business.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Workshop.Business.Engines.Implementations
{
    public class SuBardak : IBardak
    {
        public string Drink()
        {
            return "Su içildi";
        }
    }
}
