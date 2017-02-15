using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTool
{
    class Survey
    {
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Outro { get; set; }
        public int Version { get; set; }
        public string ReleaseDate { get; set; }
        public List<Question> Questions { get; set; }

        public Survey(string title, string intro, string outro )
        {
            Title = title;
            Intro = intro;
            Outro = outro;
            Version = 1;
            ReleaseDate = DateTime.Today.ToString();
            Questions = new List<Question>();
        }
        public Survey()
        {
            Title = "";
            Intro = "";
            Outro = "";
            Version = 1;
            ReleaseDate = DateTime.Today.ToString();
            Questions = new List<Question>();

        }

    }
}
