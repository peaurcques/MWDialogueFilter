using Dialogue.CSLists;
using Dialogue.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialogue.Models
{
    public class TestData
    { 
        /// <summary>
        ///     NPC to use for this test
        /// </summary>
        public NPC NPC { get; set; }
        /// <summary>
        ///     PC to use for this test
        /// </summary>
        public PC PC { get; set; }
        /// <summary>
        ///     Stores any current Player Journal Indices relevant Journal That the Dialogue Stack may take into account. 
        /// </summary>
        public Dictionary<string, int> Journal { get; set; } = new Dictionary<string, int>();   //Include any relevant Journal entries for a particular dialog entry, then 
        /// <summary>
        ///     Unique to this program. Just a way to quickly determine if the correct Dialogue is returned, while allowing for dialogue edits
        /// </summary>
        public int ExpectedDialogID { get; set; }
        /// <summary>
        ///     The ID of the choice selected. Used to determine the next dialogue returned
        /// </summary>
        public int ChoiceID { get; set; } = Global.ChoiceDefault;

        /// <summary>
        /// DONT USE. Required to have for Unit Testing
        /// </summary>
        public TestData() { }

        /// <summary>
        /// Creates a new set of TestData for use with Unit Tests.
        /// </summary>
        /// <param name="NPC_ID"></param>
        /// <param name="ExpectedDialogueID"></param>
        /// <param name="PC"></param>
        /// <param name="Disp"></param>
        /// <param name="ChoiceID"></param>
        public TestData(int ExpectedDialogueID, NPC_ID NPC_ID, PC PC = null, int Disp = Global.DispositionDefault, int ChoiceID = Global.ChoiceDefault)
        {
            if (PC == null) this.PC = PC.NewPC();
            else this.PC = PC;
            this.NPC = NPC.Get(NPC_ID, Disp);
            this.ExpectedDialogID = ExpectedDialogueID;
            this.ChoiceID = ChoiceID;
        }

        /// <summary>
        /// Creates a new set of TestData for use with Unit Tests
        /// </summary>
        /// <param name="ExpectedDialogueID"></param>
        /// <param name="PC"></param>
        /// <param name="NPC"></param>
        /// <param name="Disp"></param>
        /// <param name="ChoiceID"></param>
        /// <param name="Journal"></param>
        public TestData(int ExpectedDialogueID, NPC NPC = null, PC PC = null, int Disp = Global.DispositionDefault, int ChoiceID = Global.ChoiceDefault,  Dictionary<string, int> Journal = null)
        {
            if (PC == null) this.PC = PC.NewPC();
            else this.PC = PC;
            if (NPC == null) this.NPC = NPC.NewNPC();
            else this.NPC = NPC;
            this.NPC.Disposition = Disp;
            this.ExpectedDialogID = ExpectedDialogueID;
            this.ChoiceID = ChoiceID;
            if (Journal == null) this.Journal = new Dictionary<string, int>();
            else this.Journal = Journal;
        }

        public object[] ToObjArr() => new object[] { this.NPC, this.PC, this.ExpectedDialogID, this.ChoiceID, this.Journal };
    }
}
