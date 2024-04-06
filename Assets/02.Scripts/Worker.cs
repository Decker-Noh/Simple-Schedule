using System.Collections.Generic;
using System;
namespace sgSchedule
{
    [Serializable]
    public class Worker
    {
        public string name;
        public List<int> weekScore = new List<int>()
        {
            0,//"mon"
            0,//"tues"
            0,//"wednes"
            0,//"thurs"
            0,//"fri"
            0,//"satur"
            0,//"sun"
            0,//"holi"
            0//"annual
        };
        public List<string> mon = new List<string>();
        public List<string> tues = new List<string>();
        public List<string> wednes = new List<string>();
        public List<string> thurs = new List<string>();
        public List<string> fri = new List<string>();
        public List<string> satur = new List<string>();
        public List<string> sun = new List<string>();
        public List<string> holi = new List<string>();

        public List<string> vacationData = new List<string>();
        public string _name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public void SetWeekScore(string day, int num)
        {
            switch(day)
            {
                case "mon":
                    weekScore[0] = num;
                    break;
                case "tues":
                    weekScore[1] = num;
                    break;
                case "wednes":
                    weekScore[2] = num;
                    break;
                case "thurs":
                    weekScore[3] = num;
                    break;
                case "fri":
                    weekScore[4] = num;
                    break;
                case "satur":
                    weekScore[5] = num;
                    break;
                case "sun":
                    weekScore[6] = num;
                    break;
                case "holi":
                    weekScore[7] = num;
                    break;
                case "annual":
                    weekScore[8] = num;
                    break;
                default:
                    break;
            }
        }
        public int GetWeekScore(string day)
        {
            switch(day)
            {
                case "mon":
                    return weekScore[0];
                case "tues":
                    return weekScore[1];
                case "wednes":
                    return weekScore[2];
                case "thurs":
                    return weekScore[3];
                case "fri":
                    return weekScore[4];
                case "satur":
                    return weekScore[5];
                case "sun":
                    return weekScore[6];
                case "holi":
                    return weekScore[7];
                case "annual":
                    return weekScore[8];
                default:
                    return -1;
            }
        }
    }
    [Serializable]
    public class WorkerList
    {
        public List<Worker> workerList = new List<Worker>();
    }
}