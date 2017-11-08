namespace SurveyTool
{
    /// <summary>
    ///  Answer Class
    /// </summary>
    public class Answer
    {
        /// <summary>
        ///  Title of the answer.
        ///  Can either be an option or a hint.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  jump for the answer.
        ///  The question the user should jump to in case he answers/picks this answer.
        /// </summary>
        public int Jump { get; set; }

        public Answer(string title, int jump)
        {
            Title = title;
            Jump = jump;
        }

        public Answer()
        {
            Title = string.Empty;
            Jump = 0;
        }
    }
}