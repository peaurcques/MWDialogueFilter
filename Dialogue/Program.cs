using Dialogue;
using Dialogue.CSLists;
using Dialogue.Models;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;


//ENTRY POINT of the .exe, similar to Main()
//The purpose of this is to debug a single test. 
//This allows you to determine why any given test may not be working the way you expect

//Creating requisite data for running a single test. 
//Can just copy & Paste a row from the TestDataGenerator.TestData List to replace the following object instantiation
//TestData SingleTest = new TestData()
//{
//    NPC = new Character(),
//    PC = Character.NewPC(),
//    Journal = new Dictionary<string, int>(),
//    ExpectedDialogID = 270010,
//    ChoiceID = Global.ChoiceDefault,
//};

List<object[]> _data = new List<object[]>();
List<TestData> TestData = new List<TestData>()
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

foreach (TestData _TestData in TestData)
    _data.Add(_TestData.ToObjArr());




//TestData SingleTest =
//            new TestData(NPC_ID.SomeGuy27, 270090, PC: Character.NewPC(faction: Faction.TribunalTemple), Disp: 80);
foreach (object[] _datum in _data)
{
    //Set Global PC/NPC to appropriate PC/NPC for this test
    NPC.Current = (NPC)_datum[0];
    PC.Current = (PC)_datum[1];
    Dictionary<string, int> _jouranl = (Dictionary<string, int>)_datum[4];

    //Get the next Dialogue Response for the conditions set in the TestData object above
    Response ReturnedResponse = DialogueStack.GetNext((int)_datum[3]);

    Console.WriteLine($"Expected: {(int)_datum[2]}");
    Console.WriteLine($"Actual:   {ReturnedResponse.ResponseID}");
    Console.WriteLine($"Text:     {ReturnedResponse.ResponseText}");
    Console.WriteLine((int)_datum[2] == ReturnedResponse.ResponseID ? "TEST PASSED\n" : "TEST FAILED\n");
}

Console.WriteLine("Press any key to continue");
Console.ReadKey();


