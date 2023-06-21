using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dialogue.CSLists;

namespace Dialogue.Models
{

    public class NPC : ICloneable
    {
        /////////////////  NON-STATIC/LOCAL ELEMENTS (OBJECT-LEVEL ACCESS)   /////////////////

        public NPC_ID NPC_ID { get; set; } = NPC_ID.Unspecified;
        public Sex Sex { get; set; } = Sex.Unspecified;
        public Race Race { get; set; } = Race.Unspecified;
        public Class Class { get; set; } = Class.Unspecified;
        public List<Faction> Factions { get; set; } = new List<Faction>();
        public List<Rank> Ranks { get; set; } = new List<Rank>();
        public Dictionary<InventoryItem, int> Inventory { get; set; } = new Dictionary<InventoryItem, int>(); //Set Inventory Item and it's quantity


        //[Range(0, 100, ErrorMessage ="Value for {0} must be between {1} and {2}")]
        public int Disposition { get; set; } = Global.DispositionDefault;

        /// <summary>
        /// If no attributes are set, this builds a generic NPC. If a Generic NPC gets a particular dialogue, then all NPCs will get that dialogue
        /// </summary>
        private NPC() { }
        public NPC(NPC_ID NPC_ID)
        {
            this.NPC_ID = NPC_ID;
        }

        public object Clone()
        {
            NPC NewCharacter = new NPC()
            {
                NPC_ID = NPC_ID,
                Sex = Sex,
                Race = Race,
                Class = Class,
                Factions = Factions,
                Ranks = Ranks,
                Disposition = Disposition,
                Inventory = new Dictionary<InventoryItem, int>()
            };
            foreach(KeyValuePair<InventoryItem, int> KVP in Inventory)
                NewCharacter.Inventory.Add(KVP.Key, KVP.Value);
            return NewCharacter;
        }





        /////////////////  STATIC/GLOBAL ELEMENTS (CLASS-LEVEL ACCESS)   /////////////////

        //If I can find a way to store all the characters in an external list,
        //then I can link the Enum value with their Game ID and such
        public static Dictionary<NPC_ID, NPC> NPCs { get; set; } = LoadNPCs();
        public static NPC Current { get; set; }  //Set Current NPC from Dictionary of Characters


        /// <summary>
        /// Used to find and load all actual game NPCs and all relevent data. Currently just loads a few example NPCs
        /// </summary>
        /// <returns></returns>
        public static Dictionary<NPC_ID, NPC> LoadNPCs()
        {
            Dictionary<NPC_ID, NPC> retVal = new Dictionary<NPC_ID, NPC>();

            retVal.Add(NPC_ID.SomeGuy27, new NPC()
            {
                NPC_ID = NPC_ID.SomeGuy27,
                Factions = new List<Faction>() { CSLists.Faction.TribunalTemple },
            });

            retVal.Add(NPC_ID.SomeGuy28, new NPC()
            {
                NPC_ID = NPC_ID.SomeGuy28,
            });

            return retVal;
        }

        /// <summary>
        /// Return an NPC object whose attributes match passed-in NPC_ID
        /// </summary>
        /// <param name="NPC_ID">
        ///     ID of the NPC to be returned
        /// </param>
        /// <param name="Disposition">
        ///     Optional Argument. Desired Disposition of returned NPC
        /// </param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static NPC Get(NPC_ID NPC_ID, int? Disposition = null)
        {
            NPC.NPCs.TryGetValue(NPC_ID, out NPC retVal);
            if (retVal == null) throw new Exception($"NPC, {NPC_ID}, is in NPC_ID enum, but has no corresponding entry in the Characters Dictionary, built in Characters.LoadCharacters()");
            retVal.Disposition = Disposition != null && Disposition <= 100 ? (int)Disposition : retVal.Disposition;
            return retVal.Clone() as NPC;
        }



        public static NPC NewNPC()
        {
            return NewNPC(inventory: null);
        }

        /// <summary>
        ///     Returns a new NPC with optional attributes. Allows setting Multiple Factions + Ranks + JournalEntries + InventoryItems
        /// </summary>
        /// <param name="sex">Optional Argument</param>
        /// <param name="race">Optional Argument</param>
        /// <param name="clas">Optional Argument</param>
        /// <param name="faction">Optional Argument</param>
        /// <param name="rank">Optional Argument</param>
        /// <param name="inventory">Optional Argument</param>
        /// <param name="disposition">Optional Argument</param>
        /// <returns>A new Temp NPC with passed-in attributes</returns>
        public static NPC NewNPC(Sex sex = Sex.Unspecified,
                                Race race = Race.Unspecified,
                                Class clas = Class.Unspecified,
                                List<Faction> faction = null,
                                List<Rank> rank = null,
                                Dictionary<InventoryItem, int> inventory = null,
                                 int disposition = 0)
        {
            if (faction == null)
                faction = new List<Faction>();

            if (rank == null)
                rank = new List<Rank>();

            if (inventory == null)
                inventory = new Dictionary<InventoryItem, int>();

            return new NPC()
            {
                NPC_ID = NPC_ID.Unspecified,
                Sex = sex,
                Race = race,
                Class = clas,
                Factions = faction,
                Ranks = rank,
                Inventory = inventory,
                Disposition = disposition,
            };
        }

        /// <summary>
        ///     Returns a new NPC with optional attributes. Only allows setting a Single Faction + Rank + JournalEntry + InventoryItem
        /// </summary>
        /// <param name="sex">Optional Argument</param>
        /// <param name="race">Optional Argument</param>
        /// <param name="clas">Optional Argument</param>
        /// <param name="faction">Optional Argument</param>
        /// <param name="rank">Optional Argument</param>
        /// <param name="inventory">Optional Argument</param>
        /// <param name="disposition">Optional Argument</param>
        /// <returns>A new Temp NPC with passed-in attributes</returns>
        public static NPC NewNPC(Sex sex = Sex.Unspecified,
                                 Race race = Race.Unspecified,
                                Class clas = Class.Unspecified,
                                 Faction faction = Faction.Unspecified,
                                 Rank rank = Rank.Unspecified,
                                 KeyValuePair<InventoryItem, int> inventory = new KeyValuePair<InventoryItem, int>(),
                                 int disposition = Global.DispositionDefault)
        {
            List<Faction> Factions = new List<Faction>();
            if (faction != Faction.Unspecified)
                Factions.Add(faction);

            List<Rank> Ranks = new List<Rank>();
            if (rank != Rank.Unspecified)
                Ranks.Add(rank);

            Dictionary<InventoryItem, int> InventoryItems = new Dictionary<InventoryItem, int>();
            if (inventory.Key != 0 && inventory.Value != 0)
                InventoryItems.Add(inventory.Key, inventory.Value);

            return new NPC()
            {
                NPC_ID = NPC_ID.Unspecified,
                Sex = sex,
                Race = race,
                Class = clas,
                Factions = Factions,
                Ranks = Ranks,
                Inventory = InventoryItems,
                Disposition = disposition,
            };
        }
    }
}
