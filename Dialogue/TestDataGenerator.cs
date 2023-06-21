using Dialogue.CSLists;
using Dialogue.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialogue
{
    /// <summary>
    /// Compile a list of all the Tests+Test Data you need to run the gamut of tests. 
    /// To add a new test, simply add a new line to the _data list.
    /// For NPC: You can either supply a particular NPC_ID, and it will pull all the data for that NPC, 
    /// OR: You can build a brand new NPC with custom attributes if an existing NPC does not meet your criteria
    /// </summary>
    public class TestDataGenerator : IEnumerable<object[]>
    {
        /// <summary>
        ///     Enter all your data for each test here
        ///     For a new test, add a new row
        /// </summary>
        private static List<TestData> TestData { get; set; } = new List<TestData>()
        {
            new TestData(270000, NPC_ID.SomeGuy27, PC: PC.NewPC(journal: new KeyValuePair<JournalItems, int>(JournalItems.PRQ_MOTT_1, 23))),
            new TestData(270010, NPC_ID.SomeGuy27, ChoiceID: 2701001),
            new TestData(270020, NPC_ID.SomeGuy27, ChoiceID: 2701002),
            new TestData(270030, NPC_ID.SomeGuy27, ChoiceID: 2701003),
            new TestData(270040, NPC_ID.SomeGuy27, ChoiceID: 2701004),
            new TestData(270050, NPC_ID.SomeGuy27, ChoiceID: 2701005),
            new TestData(270060, NPC_ID.SomeGuy27, PC: PC.NewPC(faction: Faction.TribunalTemple, rank: Rank.TribunalTemple_09_Master)),
            new TestData(270070, NPC_ID.SomeGuy27, PC: PC.NewPC(faction: Faction.TribunalTemple, rank: Rank.TribunalTemple_10_Patriarch)),
            new TestData(270090, NPC_ID.SomeGuy27, PC: PC.NewPC(faction: Faction.TribunalTemple), Disp: 80),
            new TestData(270080, NPC_ID.SomeGuy27, PC: PC.NewPC(faction: Faction.TribunalTemple)),
            new TestData(270100, NPC_ID.SomeGuy27),
            new TestData(100010, NPC.NewNPC(faction: Faction.TribunalTemple, rank: Rank.TribunalTemple_09_Master), PC.NewPC(faction: Faction.TribunalTemple, rank: Rank.TribunalTemple_10_Patriarch)),
            new TestData(100020, NPC.NewNPC(faction: Faction.TribunalTemple, rank: Rank.TribunalTemple_09_Master), PC.NewPC(faction: Faction.TribunalTemple)),
            new TestData(100030, NPC.NewNPC(faction: Faction.TribunalTemple, rank: Rank.TribunalTemple_09_Master)),
            new TestData(000001),
            new TestData(000000, ChoiceID: 0),
            new TestData(000000, ChoiceID: 999999999),
        };






        //Required for Unit Tests to work with the data above
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        //Unit Tests pull their test data from here, one row per test
        private readonly List<object[]> _data = FillTests();

        /// <summary>
        /// Fills TestDataGenerator._data with test data formatted so Unit Tests can consume the data
        /// </summary>
        /// <returns></returns>
        public static List<object[]> FillTests()
        {
            var list = new List<object[]>();
            foreach (TestData _TestData in TestData)
                list.Add(_TestData.ToObjArr());
            return list;
        }



    }
}
