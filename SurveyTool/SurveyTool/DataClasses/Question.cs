using System.Collections.Generic;

namespace SurveyTool
{
    /// <summary>
    ///  Question Class.
    /// </summary>
    public class Question
    {
        public int Id { get; set; }
        /// <summary>
        ///  Question's Title.
        ///  Typically the question itself.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  Question's Type.
        ///  One of the availavble types.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///  Question's Answers.
        ///  List of answers that might be 1 or 1 or more, depending on the type.
        /// </summary>
        public List<Answer> Answers {get; set; }
        
        public Question(int id, string title, string type)
        {
            Id = id;
            Title = title;
            Type = type;
            Answers = new List<Answer>();
        }
    }
}
