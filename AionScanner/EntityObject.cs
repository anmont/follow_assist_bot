using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionScanner
{
    class EntityObject
    {
        public string eName { get; set; }
        public uint eGUID { get; set; }
        public uint eLevel { get; set; }
        public uint eHealthPercent { get; set; }
        public uint eType { get; set; }
        public uint eTarget { get; set; }
        public uint eReact { get; set; }
        public uint eBuffCount { get; set; }
        public uint eBuffArray { get; set; }
        public uint eBuffSize { get; set; }

    }
}
