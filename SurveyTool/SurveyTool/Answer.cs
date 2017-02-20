using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTool
{
    public class Answer
    {
        public string Title { get; set; }
        public int Jump { get; set; }

        public Answer(string title, int jump)
        {
            Title = title;
            Jump = jump;
        }
        public Answer()
        {
            Title = "";
            Jump = 0;
        }
    }
}
