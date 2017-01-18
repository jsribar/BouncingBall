using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Vsite.Pood.BouncingBall;
using System.Text.RegularExpressions;

namespace Vsite.Pood.BouncingBallDemo
{
    class StageLoader
    {
        public StageLoader()
        {
            string fileExt = ".lvl";
            levels = Directory.GetFiles(filesPath, "*", SearchOption.AllDirectories).Where(s => fileExt.Equals(Path.GetExtension(s))).ToList();
        }

        public List<string> LoadLevelData(string levelName)
        {
            List<string> lines = new List<string>();
            string levelPath = filesPath + levelName + ".lvl";
            if (levels.Contains(levelPath))
            {
                using (StreamReader reader = new StreamReader(levelPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                for(int i=0;i<lines.Count;i++)
                {
                    //Regex.Replace(lines.ElementAt(i), @"\s+", "");
                    lines.ElementAt(i).Replace(" ", string.Empty);
                }
            }
            return lines;
        }

        public List<Line> GetLevelData(string levelName)
        {
            List<string> levelLines = LoadLevelData(levelName);

            int linenum = levelLines.Count;
            //PointD[,] points= new PointD[linenum, 2];
            List<Line> rectangleDiagonals = new List<Line>();
            double currX = xInitial;
            double currY = yInitial;

            foreach (var line in levelLines)
            {
                currX = xInitial;
                foreach(char c in line)
                {
                    if (c == '1')
                    {
                        rectangleDiagonals.Add(new Line(
                            new PointD(currX, currY), 
                            new PointD(currX + xIncrease, currY + yIncrease)));
                        currX += xIncrease;
                    }
                    else if(c == '0')
                        currX += xIncrease;
                }
                currY += yIncrease;
            }

            return rectangleDiagonals;
        }

        public readonly List<string> levels;
        private string filesPath = Environment.CurrentDirectory + @"\levels\";
        private const double xIncrease = 50;
        private const double yIncrease = 20;
        private const double xInitial = 100;
        private const double yInitial = 100;
    }
}
