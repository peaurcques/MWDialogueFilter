using Dialogue.CSLists;
using Dialogue.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialogue.Models
{
    public class PC
    {
        /////////////////  NON-STATIC/LOCAL ELEMENTS (OBJECT-LEVEL ACCESS)   /////////////////
        /// <summary>
        ///     Player Sex
        /// </summary>
        public Sex Sex { get; set; } = Sex.Unspecified;
        /// <summary>
        ///     Player Race
        /// </summary>
        public Race Race { get; set; } = Race.Unspecified;
        /// <summary>
        ///     Player Class
        /// </summary>
        public Class Class { get; set; } = Class.Unspecified;
        /// <summary>
        ///     Collection of all Factions to which the player belongs
        /// </summary>
        public List<Faction> Factions { get; set; } = new List<Faction>();
        /// <summary>
        ///     Collection of all Current Ranks of the player. Should only contain the maximun Rank attained for each Faction to which the player belongs
        /// </summary>
        public List<Rank> Ranks { get; set; } = new List<Rank>();

        /// <summary>
        ///     Collection of all current Journal Entries and current Indices(Indexes)
        /// </summary>
        public Dictionary<JournalItems, int> Journal { get; set; } = SetJournal();

        /// <summary>
        ///     Collection of all current Inventory Items and associated Quantities
        /// </summary>
        public Dictionary<InventoryItem, int> Inventory { get; set; } = new Dictionary<InventoryItem, int>(); //Set Inventory Item and it's quantity

        private PC() { }









        /////////////////  STATIC/GLOBAL ELEMENTS (CLASS-LEVEL ACCESS)   /////////////////

        public static PC Current { get; set; } = NewPC();

        /// <summary>
        ///     Returns generic PC, with no attributes specified.
        /// </summary>
        /// <returns></returns>
        public static PC NewPC()
        {
            return NewPC(inventory: new Dictionary<InventoryItem, int>());
        }

        /// <summary>
        ///     Returns a new PC with optional attributes. Allows setting Multiple Factions + Ranks + JournalEntries + InventoryItems
        /// </summary>
        /// <param name="sex">Optional Argument</param>
        /// <param name="race">Optional Argument</param>
        /// <param name="clas">Optional Argument</param>
        /// <param name="faction">Optional Argument</param>
        /// <param name="rank">Optional Argument</param>
        /// <param name="journal">Optional Argument</param>
        /// <param name="inventory">Optional Argument. Empty by default</param>
        /// <returns>A new Temp PC with passed-in attributes</returns>
        public static PC NewPC( Sex sex = Sex.Unspecified,
                                Race race = Race.Unspecified,
                                Class clas = Class.Unspecified,
                                List<Faction> faction = null,
                                List<Rank> rank = null,
                                Dictionary<JournalItems, int> journal = null,
                                Dictionary<InventoryItem, int> inventory = null)
        {
            if (faction == null) 
                faction = new List<Faction>();

            if (rank == null) 
                rank = new List<Rank>();                    

            if (inventory == null) 
                inventory = new Dictionary<InventoryItem, int>();

            PC pc = new PC()
            {
                Sex = sex,
                Race = race,
                Class = clas,
                Factions = faction,
                Ranks = rank,
                Inventory = inventory,
            };

            if (journal != null)
                foreach (KeyValuePair<JournalItems, int> kvp in journal)
                    pc.Journal[kvp.Key] = kvp.Value;
            return pc;

        }

        /// <summary>
        ///     Returns a new PC with optional attributes. Only allows setting a Single Faction + Rank + JournalEntry + InventoryItem
        /// </summary>
        /// <param name="sex">Optional Argument</param>
        /// <param name="race">Optional Argument</param>
        /// <param name="clas">Optional Argument</param>
        /// <param name="faction">Optional Argument</param>
        /// <param name="rank">Optional Argument</param>
        /// <param name="journal">Optional Argument</param>
        /// <param name="inventory">Optional Argument</param>
        /// <returns>A new Temp PC with passed-in attributes</returns>
        public static PC NewPC( Sex sex = Sex.Unspecified,
                                Race race = Race.Unspecified,
                                Class clas = Class.Unspecified,
                                Faction faction = Faction.Unspecified,
                                Rank rank = Rank.Unspecified,
                                KeyValuePair<JournalItems, int> journal = new KeyValuePair<JournalItems, int>(),
                                KeyValuePair<InventoryItem, int> inventory = new KeyValuePair<InventoryItem, int>())
        {
            List<Faction> Factions = new List<Faction>();
            if (faction != Faction.Unspecified) 
                Factions.Add(faction);

            List<Rank> Ranks = new List<Rank>();
            if (rank != Rank.Unspecified) 
                Ranks.Add(rank);

            Dictionary<JournalItems, int> JournalItems = new Dictionary<JournalItems, int>();
            if (journal.Key != 0 && journal.Value != 0) 
                JournalItems.Add(journal.Key, journal.Value);

            Dictionary<InventoryItem, int> InventoryItems = new Dictionary<InventoryItem, int>();
            if (inventory.Key != 0 && inventory.Value != 0) 
                InventoryItems.Add(inventory.Key, inventory.Value);

            PC pc = new PC()
            {
                Sex = sex,
                Race = race,
                Class = clas,
                Factions = Factions,
                Ranks = Ranks,
                Inventory = InventoryItems,
            };

            if (journal.Key != 0 && journal.Value != 0)
                pc.Journal[journal.Key] = journal.Value;
            return pc;
        }

        private static Dictionary<JournalItems, int> SetJournal()
        {
            Dictionary<JournalItems, int> retVal = new Dictionary<JournalItems, int>();
            foreach (int JournalItem in Enum.GetValues<JournalItems>())
                retVal.Add((JournalItems)JournalItem, 0);
            return retVal;
        }
    }
}
