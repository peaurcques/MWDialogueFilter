using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dialogue.CSLists;
using Dialogue.Models;

namespace Dialogue
{
    public class DialogueStack
    {
        /// <summary>
        /// Given certain 
        /// </summary>
        /// <param name="Choice">
        ///     Optional Argument. A ChoiceID may be required to return the correct response. 
        /// </param>
        /// <returns></returns>
        public static Response GetNext(int Choice = Global.ChoiceDefault)
        {
            /////////SomeGuy27
            if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && PC.Current.Journal[JournalItems.PRQ_MOTT_1] == 23)
                return new Response(270000)
                {
                    ResponseText = "First Journal Response",
                 };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && Choice == 2701001)
                return new Response(270010)
                {
                    ResponseText = "[With eyes nervously wandering] Uh, I apologize, but if you’ll excuse me, I should see to my duties.",
                };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && Choice == 2701002)
                return new Response(270020)
                {
                    ResponseText = "Yes, I’m sure you’re right. Thank you.",
                };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && Choice == 2701003)
                return new Response(270030)
                {
                    ResponseText = "I really just don’t like dealing with people and their problems. If there was a good way to perform Mercies without having to deal with the people involved, that would be ideal.",
                    Choices = new List<Choice>()
                    {
                        new Choice (2701001, "[Say Nothing]"),
                        new Choice (2701002, "Good Luck with that. You’ll grow into it eventually."),
                        new Choice (2701004, "So, a Mercy able to be performed without any social interaction would interest you?")
                    }
                };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && Choice == 2701004)
                return new Response(270040)
                {
                    ResponseText = "I, uh, yes! That would be perfect!  I just don’t think that’s going to happen. I mean, I would have to go in search of such a Mercy, and that means talking to lots of people",
                    Choices = new List<Choice>()
                    {
                        new Choice (2701001, "Well, that is quite the conundrum. Good luck, I guess. I don't envy you."),
                        new Choice (2701002, "Yes, I can see why that would be hard. But, I believe in you. You can do it!"),
                        new Choice (2701005, "Well, if I see any Mercies come up that could be done without any excess social interaction, I’ll be sure to send them your way."),
                    }
                };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && Choice == 2701005)
                return new Response(270050)
                {
                    ResponseText = "Thank you! That would be fantastic!",
                };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && PC.Current.Factions.Contains(Faction.TribunalTemple) && PC.Current.Ranks.Contains(Rank.TribunalTemple_09_Master))
                return new Response(270060)
                {
                    ResponseText = "I know I’m behind on my Mercies, Master. I will work harder.",
                    Choices = new List<Choice>()
                    {
                        new Choice (2701001, "[Say Nothing, Sternly]"),
                        new Choice (2701002, $"I trust you will do your best, {NPC.Current.NPC_ID}"),
                        new Choice (2701003, "Is there anything I can do to help you?"),
                    }
                };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && PC.Current.Factions.Contains(Faction.TribunalTemple) && PC.Current.Ranks.Contains(Rank.TribunalTemple_10_Patriarch))
                return new Response(270070)
                {
                    ResponseText = "I know I’m behind on my Mercies, Patriarch. I will work harder.",
                    Choices = new List<Choice>()
                    {
                        new Choice (2701001, "[Say Nothing, Sternly]"),
                        new Choice (2701002, $"I trust you will do your best, {NPC.Current.NPC_ID}"),
                        new Choice (2701003, "Is there anything I can do to help you?"),
                    }
                };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && PC.Current.Factions.Contains(Faction.TribunalTemple) && NPC.Current.Disposition <= 70)
                return new Response(270080)
                {
                    ResponseText = "[Sigh] I know, I’m behind on my Mercies. You’re doing so much better than me. It’s not that hard, so why can’t I just man up and do it. I’ve heard it all before, and I’m a little sick of it, so please let’s not bring it up yet again.",
                };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27 && PC.Current.Factions.Contains(Faction.TribunalTemple) && NPC.Current.Disposition > 70)
                return new Response(270090)
                {
                    ResponseText = "I really dislike performing Mercies. I know we are supposed to emulate our Lord Vivec, but I just don’t like doing them.",
                    Choices = new List<Choice>()
                    {
                        new Choice (2701001, "[Say Nothing, Accusingly]"),
                        new Choice (2701002, $"I’m sure if you keep trying, it will get easier, {NPC.Current.NPC_ID}"),
                        new Choice (2701003, "What makes you dislike them?"),
                    }
                };
            else if (NPC.Current.NPC_ID == NPC_ID.SomeGuy27)
                return new Response(270100)
                {
                    ResponseText = "[Sigh] Thank you for asking. Is there some Mercy I can perform for you? Perhaps I can point you to our Temple Master, so she can point you in the right direction?"
                };



            /////////SomeGuy 28
            else if (NPC.Current.Factions.Contains(Faction.TribunalTemple) && NPC.Current.Ranks.Contains(Rank.TribunalTemple_09_Master) &&
                     PC.Current.Factions.Contains(Faction.TribunalTemple) && PC.Current.Ranks.Contains(Rank.TribunalTemple_10_Patriarch))
                return new Response(100010)
                {
                    ResponseText = "Patriarch, our clergy are fervently performing the Mercies of ALMSIVI upon the faithful",
                };
            else if (NPC.Current.Factions.Contains(Faction.TribunalTemple) && NPC.Current.Ranks.Contains(Rank.TribunalTemple_09_Master) &&
                     PC.Current.Factions.Contains(Faction.TribunalTemple))
                return new Response(100020)
                {
                    ResponseText = "Temple clergy are required to perform Mercies upon the faithful in the name of ALMSIVI. The Mercies of ALMSIVI must be performed selflessly, free from Pride. No Act of Mercy is beneath you, as Lord Vivec himself showed in his Grace of Humility. Go and find those in need of the Mercies of ALMSIVI.",
                };
            else if (NPC.Current.Factions.Contains(Faction.TribunalTemple) && NPC.Current.Ranks.Contains(Rank.TribunalTemple_09_Master))
                return new Response(100030)
                {
                    ResponseText = "The Mercies of the Tribunal are performed upon the faithful in the example of our Lord Vivec's Grace of Humility. If you require the Mercy of ALMSIVI, you have but to ask.",
                };



            /////////Error and No Response 
            else if (Choice != Global.ChoiceDefault) return new Response(0)
            {
                ResponseText = $"ERROR: No Appropriate Response Found Choice: {Choice}"
            };
            else return new Response(1)
            {
                ResponseText = "No Dialogue for this NPC Found for this topic"
            };
        }
    }
}

