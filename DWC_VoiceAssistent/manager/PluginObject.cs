using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWC_VoiceAssistent.manager
{
    class PluginObject
    {

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public string Name { get; }
        public string Description { get; }
        public string Company { get; }
        public string Copyright { get; }
        public string Trademark { get; }
        public Type Type { get; }
        public bool Loaded { get; set; }

        public PluginObject(string name, string description, string company, string copyright, string trademark, Type type, bool loaded)
        {
            Name = name;
            Description = description;
            Company = company;
            Copyright = copyright;
            Trademark = trademark;
            Type = type;
            Loaded = loaded;
        }

    }
}
