using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialogue.Models
{
    public class Response
    {
        public int ResponseID { get; set; } //not used except for checking to make sure the correct Response is returned on tests.
        public string ResponseText { get; set; } = "String.Empty";
        public List<Choice> Choices { get; set; } = new List<Choice>();



        public Response() { }
        public Response(int ResponseID)
        {
            this.ResponseID = ResponseID;
        }

        public Choice GetChoice(int ChoiceID)
        {
            foreach (Choice choice in Choices)
                if (choice.ChoiceID == ChoiceID)
                    return choice;
            return null;
        }
    }
}
