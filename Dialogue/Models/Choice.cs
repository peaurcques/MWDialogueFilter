using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dialogue.Models
{
    public class Choice
    {
        public int ChoiceID { get; set; }
        public string ChoiceText { get; set; }
        public string Journal { get; set; }
        public Choice() { }

        public Choice(int ChoiceID, string ChoiceText, string Journal = "")
        {
            this.ChoiceID = ChoiceID;
            this.ChoiceText = ChoiceText;
            this.Journal = Journal;

        }
    }
}

