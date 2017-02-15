using System;
using System.Windows.Forms;

namespace SurveyTool
{
    class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FirstForm firstForm = new FirstForm();
            Application.Run(firstForm);
            

        }
    }
}
