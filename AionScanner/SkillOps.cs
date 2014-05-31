using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AionScanner
{
    class SkillOps
    {

        public static List<SkillsObject> SkillsInit()
        {
            SkillsObject tempobject = new SkillsObject();

            List<SkillsObject> listobj = new List<SkillsObject>();

            var csvobject = File.ReadAllLines("4Skills.csv").Select(x => x.Split(',')).Select(x => new {
                          skillid = x[0],
                          skillname = x[1],
                          casttime = x[2],
                          cooldown = x[3],
                          type = x[4]
                      });

            foreach (var tempvar in csvobject)
            {
                tempobject.skillid = Convert.ToInt32(tempvar.skillid);
                tempobject.skillname = tempvar.skillname;
                tempobject.casttime = Convert.ToInt32(tempvar.casttime);
                tempobject.cooldown = Convert.ToInt32(tempvar.cooldown);
                tempobject.type = Convert.ToInt32(tempvar.type);

                listobj.Add(new SkillsObject { skillid = tempobject.skillid, skillname = tempobject.skillname, casttime = tempobject.casttime, cooldown = tempobject.cooldown, type = tempobject.type });

            }
            return listobj;
        }


        public static string getIDbyID(List<SkillsObject> Slist, int searchid)
        {
            string skillname = string.Empty;
            int i = 0;

            if (searchid == 0)
            {
                return "999999";
            }

            foreach (var skill in Slist)
            {
                if (skill.skillid.Equals(searchid))
                {
                    return (skill.skillid).ToString();
                }
                i++;
            }

            skillname = "999999";
            return skillname;
        }


        public static string SearchByID(List<SkillsObject> Slist, int searchid)
        {
            string skillname = string.Empty;
            int i = 0;

            if (searchid == 0)
            {
                return "No Skill";
            }

            foreach (var skill in Slist)
            {
                if (skill.skillid.Equals(searchid))
                {
                    return skill.skillname + " " + skill.casttime + " " + skill.cooldown;
                }
                i++;
            }

            skillname = "nf " + searchid + " " + i;
            return skillname;
        }



    }
}
