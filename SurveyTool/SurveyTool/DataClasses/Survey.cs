using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SurveyTool
{
    /// <summary>
    ///  Survey Class
    /// </summary>
    public class Survey
    {
        /// <summary>
        ///  Survey Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  Survey Intro.
        ///  Small text which the inquirer says in the begining.
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        ///  Survey Outro.
        ///  Small text which the inquirer says in the end.
        /// </summary>
        public string Outro { get; set; }

        /// <summary>
        ///  Survey version.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        ///  Survey code, used as filename and what the App users use to open a specific survey.
        /// </summary>
        [JsonIgnore]
        public string Code { get; set; }

        /// <summary>
        ///  Survey Release Date.
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        ///  Survey Questions.
        ///  List of survey's questions, has to be 1 or more.
        /// </summary>
        public List<Question> Questions { get; set; }

        public Survey(string title, string intro, string outro)
        {
            Title = title;
            Intro = intro;
            Outro = outro;
            Version = 1;
            ReleaseDate = SurveyDate();
            Questions = new List<Question>();
        }

        public Survey()
        {
            Title = "";
            Intro = "";
            Outro = "";
            Version = 1;
            ReleaseDate = SurveyDate();
            Questions = new List<Question>();
        }

        /// <summary>
        ///  Obtains survey's month in the intended format.
        /// </summary>
        private string SurveyDate()
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
