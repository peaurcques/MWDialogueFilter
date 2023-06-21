using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialogue.CSLists
{
    public enum Rank
    {
        //Indicates NPC could be any Rank
        Unspecified = 0,

        //Vanilla Faction Ranks
        //Ashlanders
        Ashlander_00_Unspecified                    = 0009,
        Ashlander_01_Clanfriend                     = 0010,
        Ashlander_02_Hearthfriend                   = 0020,
        Ashlander_03_Brother                        = 0030,
        Ashlander_04_Initiate                       = 0040,
        Ashlander_05_Clanholder                     = 0050,
        Ashlander_06_Guide                          = 0060,
        Ashlander_07_Champion                       = 0070,
        Ashlander_08_Gulakhan                       = 0080,
        Ashlander_09_Farseer                        = 0090,
        Ashlander_10_Ashkhan                        = 0100,

        //Blades                                         
        Blades_00_Unspecified                       = 0109,
        Blades_01_Novice                            = 0110,
        Blades_02_Apprentice                        = 0120,
        Blades_03_Journeyman                        = 0130,
        Blades_04_Finder                            = 0140,
        Blades_05_Traveller                         = 0150,
        Blades_06_Operative                         = 0160,
        Blades_07_Agent                             = 0170,
        Blades_08_Spy                               = 0180,
        Blades_09_Spymaster                         = 0190,
        Blades_10_GrandSpymaster                    = 0200,
                                                         
        //Commona Tong         
        CamonnaTong_00_Unspecified                  = 0209,                          
        CamonnaTong_01_Bully                        = 0210,
        CamonnaTong_02_Tough                        = 0220,
        CamonnaTong_03_Thug                         = 0230,
        CamonnaTong_04_Brute                        = 0240,
        CamonnaTong_05_Lifetaker                    = 0250,
        CamonnaTong_06_Chiller                      = 0260,
        CamonnaTong_07_Hammer                       = 0270,
        CamonnaTong_08_OldMan                       = 0280,
        CamonnaTong_09_Strongman                    = 0290,
        CamonnaTong_10_Kingpin                      = 0300,
                                                         
        //Census and Excise                           
        CemsicExcise_00_Unspecified                 = 0309,
        CencusExcise_01_Novice                      = 0310,
        CencusExcise_02_Apprentice                  = 0320,
        CencusExcise_03_Clerk                       = 0330,
        CencusExcise_04_Taxman                      = 0340,
        CencusExcise_05_Taxtaker                    = 0350,
        CencusExcise_06_Operative                   = 0360,
        CencusExcise_07_Agent                       = 0370,
        CencusExcise_08_ExciseOfficer               = 0380,
        CencusExcise_09_Inspector                   = 0390,
        CencusExcise_10_GrandInspector              = 0400,
                                                         
        //Clan Aundae                                    
        ClanAundae_00_Unspecified                   = 0409,
        CLanAundae_01_Cattle                        = 0410,
        CLanAundae_02_Neonate                       = 0420,
        CLanAundae_03_Minion                        = 0430,
        CLanAundae_04_Servant                       = 0440,
        CLanAundae_05_Stalker                       = 0450,
        CLanAundae_06_Bloodkin                      = 0460,
        CLanAundae_07_Reaver                        = 0470,
        CLanAundae_08_Lord                          = 0480,
        CLanAundae_09_Elder                         = 0490,
        CLanAundae_10_Ancient                       = 0500,
                                                         
        //Clan Berne                                     
        ClanBerne_00_Unspecified                    = 0509,
        ClanBerne_01_Cattle                         = 0510,
        ClanBerne_02_Neonate                        = 0520,
        ClanBerne_03_Minion                         = 0530,
        ClanBerne_04_Servant                        = 0540,
        ClanBerne_05_Stalker                        = 0550,
        ClanBerne_06_Bloodkin                       = 0560,
        ClanBerne_07_Reaver                         = 0570,
        ClanBerne_08_Lord                           = 0580,
        ClanBerne_09_Elder                          = 0590,
        ClanBerne_10_Ancient                        = 0600,
                                                         
        //Clan Quarra                                    
        ClanQuarra_00_Unspecified                   = 0609,
        ClanQuarra_01_Cattle                        = 0610,
        ClanQuarra_02_Neonate                       = 0620,
        ClanQuarra_03_Minion                        = 0630,
        ClanQuarra_04_Servant                       = 0640,
        ClanQuarra_05_Stalker                       = 0650,
        ClanQuarra_06_Bloodkin                      = 0660,
        ClanQuarra_07_Reaver                        = 0670,
        ClanQuarra_08_Lord                          = 0680,
        ClanQuarra_09_Elder                         = 0690,
        ClanQuarra_10_Ancient                       = 0700,
                                                         
        //Fighters Guild                                 
        FightersGuild_00_Unspecified                = 0709,
        FightersGuild_01_Associate                  = 0710,
        FightersGuild_02_Apprentice                 = 0720,
        FightersGuild_03_Journeyman                 = 0730,
        FightersGuild_04_Swordsman                  = 0740,
        FightersGuild_05_Protector                  = 0750,
        FightersGuild_06_Defender                   = 0760,
        FightersGuild_07_Warder                     = 0770,
        FightersGuild_08_Guardian                   = 0780,
        FightersGuild_09_Champion                   = 0790,
        FightersGuild_10_Master                     = 0800,

        //House Hlaalu                                   
        HouseHlaalu_00_Unspecified                  = 0809,
        HouseHlaalu_01_Hireling                     = 0810,
        HouseHlaalu_02_Retainer                     = 0820,
        HouseHlaalu_03_Oathman                      = 0830,
        HouseHlaalu_04_Lawman                       = 0840,
        HouseHlaalu_05_Kinsman                      = 0850,
        HouseHlaalu_06_HouseCousin                  = 0860,
        HouseHlaalu_07_HouseBrother                 = 0870,
        HouseHlaalu_08_HouseFather                  = 0880,
        HouseHlaalu_09_Councilman                   = 0890,
        HouseHlaalu_10_Grandmaster                  = 0900,
                                                         
        //House Redoran                                  
        HouseRedoran_00_Unspecified                 = 0909,
        HouseRedoran_01_Hireling                    = 0910,
        HouseRedoran_02_Retainer                    = 0920,
        HouseRedoran_03_Oathman                     = 0930,
        HouseRedoran_04_Lawman                      = 0940,
        HouseRedoran_05_Kinsman                     = 0950,
        HouseRedoran_06_HouseCousin                 = 0960,
        HouseRedoran_07_HouseBrother                = 0970,
        HouseRedoran_08_HouseFather                 = 0980,
        HouseRedoran_09_Councilman                  = 0990,
        HouseRedoran_10_Archmaster                  = 1000,
                                                         
        //House Telvanni            
        HouseTelvanni_00_Unspecified                = 1009,                    
        HouseTelvanni_01_Hireling                   = 1010,
        HouseTelvanni_02_Retainer                   = 1020,
        HouseTelvanni_03_Oathman                    = 1030,
        HouseTelvanni_04_Lawman                     = 1040,
        HouseTelvanni_05_Mouth                      = 1050,
        HouseTelvanni_06_Spellwright                = 1060,
        HouseTelvanni_07_Wizard                     = 1070,
        HouseTelvanni_08_Master                     = 1080,
        HouseTelvanni_09_Magister                   = 1090,
        HouseTelvanni_10_Archmagister               = 1100,
                                                         
        //Imperial Cult                                  
        ImperialCult_00_Unspecified                 = 1109,
        ImperialCult_01_Layman                      = 1110,
        ImperialCult_02_Novice                      = 1120,
        ImperialCult_03_Initiate                    = 1130,
        ImperialCult_04_Acolyte                     = 1140,
        ImperialCult_05_Adept                       = 1150,
        ImperialCult_06_Disciple                    = 1160,
        ImperialCult_07_Oracle                      = 1170,
        ImperialCult_08_Invoker                     = 1180,
        ImperialCult_09_Theurgist                   = 1190,
        ImperialCult_10_Primate                     = 1200,
                                                         
        //Imperial Knights                               
        ImperialKnights_00_Unspecified              = 1209,
        ImperialKnights_01_Aspirant                 = 1210,
        ImperialKnights_02_Squire                   = 1220,
        ImperialKnights_03_Gallant                  = 1230,
        ImperialKnights_04_Chevalier                = 1240,
        ImperialKnights_05_Keeper                   = 1250,
        ImperialKnights_06_KnightBrother            = 1260,
        ImperialKnights_07_Commander                = 1270,
        ImperialKnights_08_Marshal                  = 1280,
        ImperialKnights_09_Seneschal                = 1290,
        ImperialKnights_10_Paladin                  = 1300,

        //Imperial Legion                                
        ImperialLegion_00_Unspecified               = 1309,
        ImperialLegion_01_Recruit                   = 1310,
        ImperialLegion_02_Spearman                  = 1320,
        ImperialLegion_03_Trooper                   = 1330,
        ImperialLegion_04_Agent                     = 1340,
        ImperialLegion_05_Champion                  = 1350,
        ImperialLegion_06_KnightErrant              = 1360,
        ImperialLegion_07_KnightBachelor            = 1370,
        ImperialLegion_08_KnightProtector           = 1380,
        ImperialLegion_09_KnightoftheGarland        = 1390,
        ImperialLegion_10_KnightoftheImperialDragon = 1400,
                                                         
        //MagesGuild                                   
        MagesGuild_00_Unspecified                   = 1409,  
        MagesGuild_01_Associate                     = 1410,
        MagesGuild_02_Apprentice                    = 1420,
        MagesGuild_03_Journeyman                    = 1430,
        MagesGuild_04_Evoker                        = 1440,
        MagesGuild_05_Conjurer                      = 1450,
        MagesGuild_06_Magician                      = 1460,
        MagesGuild_07_Warlock                       = 1470,
        MagesGuild_08_Wizard                        = 1480,
        MagesGuild_09_MasterWizard                  = 1490,
        MagesGuild_10_ArchMage                      = 1500,
                                                         
        //Morag Tong                    
        MoragTong_00_Unspecified                    = 1509,                 
        MoragTong_01_Associate                      = 1510,
        MoragTong_02_BlindThrall                    = 1520,
        MoragTong_03_Thrall                         = 1530,
        MoragTong_04_WhiteThrall                    = 1540,
        MoragTong_05_Thinker                        = 1550,
        MoragTong_06_Brother                        = 1560,
        MoragTong_07_Knower                         = 1570,
        MoragTong_08_Master                         = 1580,
        MoragTong_09_ExaltedMaster                  = 1590,
        MoragTong_10_Grandmaster                    = 1600,
                                                         
        //ThievesGuild                                   
        ThievesGuild_00_Unspecified                 = 1609,
        ThievesGuild_01_Toad                        = 1610,
        ThievesGuild_02_WetEar                      = 1620,
        ThievesGuild_03_Footpad                     = 1630,
        ThievesGuild_04_Blackcap                    = 1640,
        ThievesGuild_05_Operative                   = 1650,
        ThievesGuild_06_Bandit                      = 1660,
        ThievesGuild_07_Captain                     = 1670,
        ThievesGuild_08_Ringleader                  = 1680,
        ThievesGuild_09_Mastermind                  = 1690,
        ThievesGuild_10_MasterThief                 = 1700,
                                                         
        //Tribunal                                       
        TribunalTemple_00_Unspecified               = 1709,
        TribunalTemple_01_Layman                    = 1710,
        TribunalTemple_02_Novice                    = 1720,
        TribunalTemple_03_Initiate                  = 1730,
        TribunalTemple_04_Acolyte                   = 1740,
        TribunalTemple_05_Adept                     = 1750,
        TribunalTemple_06_Curate                    = 1760,
        TribunalTemple_07_Disciple                  = 1770,
        TribunalTemple_08_Diviner                   = 1780,
        TribunalTemple_09_Master                    = 1790,
        TribunalTemple_10_Patriarch                 = 1800,

        //Mod-Added Faction Ranks
        //Abide by the following naming standard for ease of use
        //{Faction}_{RankNumber 1-10}_{RankName} = NextNumberInSequence
    }
}
