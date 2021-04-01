using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;

namespace Flask
{
    public class ConnectingKompas
    {
        public KompasObject Kompas { get; set; }

        public void OpenKompas()
        {
            if (Kompas == null)
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                Kompas = (KompasObject)Activator.CreateInstance(type);
            }
            Kompas.Visible = true;
            Kompas.ActivateControllerAPI();
        }


    }
}
