using Xunit;
using Dialogue;
using Dialogue.Models;
using Dialogue.CSLists;
using Dialogue.Tests;
using System.Collections.Generic;
using System.Collections;
using NuGet.Frameworks;

namespace Dialogue.Tests
{
    public class Tests
    {
        /// <summary>
        ///     RunAll(...) is run via Visual Studio's "Test Explorer". 
        ///     Parameters are filled by ClassData tag
        ///     Each row of 'Dialogue.TestDataGenerator.TestData' and the data therein represent a unique call to DialogueTest(...) and supply data for it's parameters.
        ///     To perform another test, simply add a new row to 'Dialogue.TestDataGenerator.TestData'
        /// </summary>
        /// <param name="NPC">
        ///     An Actual NPC retreived from a list of NPCs complete with attributes which would appear in-game,
        ///     or a temporary NPC with only attributes supplied at creation.
        ///     NPC data is retrieved/created for each test
        /// </param>
        /// <param name="PC">
        ///     A temporary PC with attributes as generic or specific as the user defines for a given test. 
        ///     A new PC is created for each test
        /// </param>
        /// <param name="ExpectedResponseID">
        ///     DialogueID is unique to this application and does not appear in the CS. 
        ///     It helps simplify tests by allowing you to change the text of a dialogue without disrupting these tests
        /// </param>
        /// <param name="ChoiceID">
        ///     You may supply a ChoiceID, which may cause any Dialogue Topics with a Choice filter to be returned.
        /// </param>
        /// <param name="Journal">
        ///     You may supply Journal Entries. which may cause Dialogue Topics with a Journal Entry filter to be returned.
        /// </param>
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void RunAll(NPC NPC, PC PC, int ExpectedResponseID, int ChoiceID, Dictionary<string, int> Journal) 
        {
            //Set Global PC/NPC to appropriate PC/NPC for this test
            Models.PC.Current = PC;
            NPC.Current = NPC;

            Response ReturnedDialogue= DialogueStack.GetNext(ChoiceID);

            Assert.Equal(ExpectedResponseID, ReturnedDialogue.ResponseID);
        }
    }
}