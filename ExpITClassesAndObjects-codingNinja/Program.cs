using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class CodingNinja
    {
        int level;
        // will default to zero after construction
        string name;
        public CodingNinja()
        {

        }
        public CodingNinja(string n)
        {
            name = n;
        }

        public string Rank()
        {
            switch (level / 5)
            {
                case 0:
                    return "beginner";
                    break;
                case 1:
                    return "Grasshopper";
                    break;
                case 2:
                    return "Journeymen";
                    break;
                case 3:
                    return "Rock star";
                    break;
                case 4:
                    return "Ninja";
                    break;
                case 5:
                    return "Jedi";
                    break;

                default:
                    return "Sith Lord";
                    break;
            }
        }

        public bool gotToMaxRank()
        {
            if (this.Rank() == "Jedi")
                return true;
            else
                return false;

        }


        private void addLevel()
        {
            this.level++;
        }
        public void programCorrect()
        {
            addLevel();
        }
        public void helpedPeer()
        {
            addLevel();
            addLevel();
        }
        public void print()
        {
            Console.WriteLine(" Ninja " + name + " is rank " + this.Rank() + " and level " + level);
        }

    }

    class Team
    {
        List<CodingNinja> teamList = new List<CodingNinja>();

        public Team()
        {

        }
        public Team(string[] names)
        {
            foreach (string n in names)
            {
                CodingNinja cn = new CodingNinja(n);
                teamList.Add(cn);
            }
        }
        public bool checkMaxTeamRank()
        {
            foreach (CodingNinja cn in this.teamList)
            {
                if (cn.gotToMaxRank())
                    return true;
            }

            return false;
        }
        public void printTeamStatus()
        {
            foreach (CodingNinja n in teamList)
            {
                n.print();
            }

        }

        private void completeProject(List<CodingNinja> cn)
        {
            for (int i = 1; i < cn.Count; i++)
            {
                cn[i].helpedPeer();
            }
            cn[0].programCorrect();
        }

        public void completeProjectByID(int[] ids)
        {
            List<CodingNinja> ourList = new List<CodingNinja>();

            foreach (int i in ids)
            {
                ourList.Add(this.teamList[i]);
            }
            this.completeProject(ourList);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // CodingNinja ninja = new CodingNinja("rick");
            // ninja.print();

            // string[] names = { "Tim", "Jeff", "Billy", "Julie", "Samantha" };
            // Team OurTeam = new Team(name
            // OurTeam.printTeamStatus();
            

            string[] codeNames = { "Cold Shadows", "Cherydactyl", "Slient Death", "Sunny" };
            Team ourTeam = new Team(codeNames);

            int[] teamOrder = { 0, 1, 2, 3 };

            do
            {
                ourTeam.completeProjectByID(teamOrder);
                ourTeam.printTeamStatus();
            } while (!ourTeam.checkMaxTeamRank());

            Console.ReadKey();
        }
    }
}
