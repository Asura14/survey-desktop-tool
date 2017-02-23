using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTool
{
    public class Survey
    {
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Outro { get; set; }
        public int Version { get; set; }
        public string ReleaseDate { get; set; }
        public List<Question> Questions { get; set; }

        public Survey(string title, string intro, string outro)
        {
            Title = title;
            Intro = intro;
            Outro = outro;
            Version = 1;
            ReleaseDate = surveyDate();
            Questions = new List<Question>();
        }

        public Survey()
        {
            Title = "";
            Intro = "";
            Outro = "";
            Version = 1;
            ReleaseDate = surveyDate();
            Questions = new List<Question>();
        }

        private string surveyDate()
        {
            string date = "";
            int month = DateTime.Today.Month;
            switch (month)
            {
                case 1:
                    date += "jan ";
                    break;
                case 2:
                    date += "fev ";
                    break;
                case 3:
                    date += "mar ";
                    break;
                case 4:
                    date += "abr ";
                    break;
                case 5:
                    date += "maio ";
                    break;
                case 6:
                    date += "jun ";
                    break;
                case 7:
                    date += "jul ";
                    break;
                case 8:
                    date += "ago ";
                    break;
                case 9:
                    date += "set ";
                    break;
                case 10:
                    date += "out ";
                    break;
                case 11:
                    date += "nov ";
                    break;
                case 12:
                    date += "dez ";
                    break;
                default:
                    break;
            }
            date += DateTime.Today.Year;
            return date;
        }
    }
}
