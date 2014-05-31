using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AionScanner
{
    class SkillsObject
    {

        public int skillid { get; set; }
        public string skillname { get; set; }
        public int casttime { get; set; }
        public int cooldown { get; set; }
        public int type { get; set; }


    }

    // Type Info
    // 0 = 99
    // SKILLCTG_NONE = 1
    // SKILLCTG_HEAL = 8
    // SKILLCTG_CHAIN_SKILL = 2
    // SKILLCTG_DEATHBLOW = 98 -- Something to do with healing debuff
    // SKILLCTG_DISPELL = 6 -- Remove debuffs
    // SKILLCTG_DRAIN = 97
    // SKILLCTG_MENTAL_DEBUFF = 5 -- Debuffs and cc's (ACT: Seperate out CCs)
    // SKILLCTG_PHYSICAL_DEBUFF = 4 -- Debuffs and cc's (ACT: Seperate out CCs)
    // SKILLCTG_REBIRTH = 9
}
