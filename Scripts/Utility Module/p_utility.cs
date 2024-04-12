//---------------------------------------------------------------------
/*
    p_utility:

    Core module which provide necessary function to check
    or setup data.

* Note:
* 1. About CheckFollowerFlag() method, there is an issue which "Recruited" flag might be false
*    but companion still exist in warden's party pool.

*    In this function the first part will check this scenario and modify
     Recruited flag if necessary.

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "sys_ambient_h"
#include "utility_h"
#include "sys_chargen_h"
#include "global_objects_2"

//---------Plot for class-------------
#include "plt_gen00pt_list_class"

//---------Plot for each mod----------
#include "plt_gen00pt_main_story"
#include "plt_gen00pt_adopted_dalish"
#include "plt_gen00pt_party_recruit"
#include "plt_dt_act1"
#include "plt_gen00pt_party_lanna"
#include "plt_gen00pt_party_marric"
#include "plt_gen00pt_party_martin"
#include "plt_gen00pt_party_willam"
#include "plt_gen00pt_party_lealion"
#include "plt_enigma_plot1"
#include "plt_gen00pt_ndq_mithra"
#include "plt_sdt_terra"
#include "plt_gen00pt_return_to_kw"
#include "plt_pt_douglas"

//--------Plot for main story character----
#include "plt_pre100pt_darkspn_blood"
#include "plt_pre100pt_ritual"
#include "plt_bed000pt_main"
#include "plt_bed200pt_fenarel"
#include "plt_bed200pt_merrill"

/*******************************************************************************
* Check if a follower with giving tag name is exist in the party pool or not.
*******************************************************************************/
int IsFollowerInPartyPool(string strFTag){

   int Result = TRUE;
   int FollowerState = 0;
   object oFollower= GetObjectByTag(strFTag);

   if(!IsObjectValid(oFollower)){
      Result = FALSE;
   }

   if(IsObjectValid(oFollower)){
       FollowerState = GetFollowerState(oFollower);
       if(FollowerState != FOLLOWER_STATE_ACTIVE &&
          FollowerState != FOLLOWER_STATE_AVAILABLE){
          Result = FALSE;
       }
   }

   return Result;
}


/*******************************************************************************
* Check if a giving mod is installed or not
* by creating a creature that only exist in each mod.
*******************************************************************************/
int IsModInstall(int ModName){

    object oTestCreature;
    string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));
    object oMap = GetObjectByTag(MapTag);
    vector vTent = Vector(0.0f,0.0f,0.0f);
    int Result = TRUE;

    switch( ModName ){

       case Adopted_Dalish:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"ado211_wolf_ghost.utc",Location(oMap, vTent, 0.0f));
          break;
       }

       case Small_Restoration:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"den_herbalist.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Dark_Time:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"dt_fol_dragon_v.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Enigma:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"enigma_highdragon.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Lealion:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"gen00fl_legion.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Party_Recruiting:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"party_arl_eamon.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Raina:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"amazon_01.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Return_to_KW:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"balin.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Tevinter_Warden:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"default_hm_noble_wd.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Warden_Women:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"dalish_elora.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Sapphos_Daughter:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"", Location(oMap, vTent, 0.0f));
          break;
       }

       case Main_Story:
       {
          Result = TRUE;
          break;
       }

    }

    if(ModName != Main_Story){
       if(!IsObjectValid(oTestCreature)) Result = FALSE;

       //Destroy Test Creature
       DestroyObject(oTestCreature);
    }

    return Result;
}

/*******************************************************************************
* Get Mod name by companion
*******************************************************************************/
int GetModNameByCompanion(string strTag){

    int ModName = 10; //Default 10 -> Main story.

    //Small Restoration
         if(strTag == GEN_FL_Moira) ModName = Small_Restoration;

    //In search of Raina
    else if(strTag == GEN_FL_Terra) ModName = Raina;

    //Sapphos Daughter
    else if(strTag == GEN_FL_Gina ) ModName = Sapphos_Daughter;

    //Adopted Dalish
    else if(strTag == GEN_FL_Ilyana || strTag == GEN_FL_Senros ||
            strTag == GEN_FL_Anaise || strTag == GEN_FL_Dominique ||
            strTag == GEN_FL_Merrilyla){
         ModName = Adopted_Dalish;}

    //Party Recruiting
    else if(strTag == GEN_FL_Andrastalla   || strTag == GEN_FL_Troga  ||
            strTag == GEN_FL_Rikku_Templar || strTag == GEN_FL_Duncan ||
            strTag == GEN_FL_Cailan        || strTag == GEN_FL_Anora  ||
            strTag == GEN_FL_Flemeth       || strTag == GEN_FL_Arl_Eamon ||
            strTag == GEN_FL_LadyOfTheForest){
         ModName = Party_Recruiting;}

    //Dark Time
    else if(strTag == GEN_FL_Isaac || strTag == GEN_FL_Miriam){
         ModName = Dark_Time;}

    //Tevinter Warden
    else if(strTag == GEN_FL_Lanna  || strTag == GEN_FL_Marric ||
            strTag == GEN_FL_Martin || strTag == GEN_FL_Willam){
         ModName = Tevinter_Warden;}

    //Lealion
    else if(strTag == GEN_FL_Lealion || strTag == GEN_FL_Legion){
         ModName = Lealion;}

    //Enigma
    else if(strTag == GEN_FL_Vekuul || strTag == GEN_FL_Vishala ||
            strTag == GEN_FL_helperlady){
         ModName = Enigma;}

    //The Warden's Women
    else if(strTag == GEN_FL_Mithra || strTag == GEN_FL_Elora){
         ModName = Warden_Women;}

    //Return to Korcari Wilds
    else if(strTag == GEN_FL_Ariane || strTag == GEN_FL_Douglas ||
            strTag == GEN_FL_Kenneth){
         ModName = Return_to_KW;}

}

/*******************************************************************************
* Identify and assign class base on player's choice.
*******************************************************************************/
void SetJob(object oFollower){

   int    nClass = CLASS_WARRIOR;
   string strTag = GetTag(oFollower);

   if      (WR_GetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_MAGE))    nClass = CLASS_WIZARD;
   else if (WR_GetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_ROGUE))   nClass = CLASS_ROGUE;
   else if (WR_GetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_WARRIOR)) nClass = CLASS_WARRIOR;

   //Add default class to different companion.
   //(For those companion who is difficult to modify dialog file)

   //Return to Korcari Wilds
   else if (strTag == GEN_FL_Douglas) nClass = CLASS_ROGUE;
   else if (strTag == GEN_FL_Kenneth) nClass = CLASS_WARRIOR;
   else if (strTag == GEN_FL_Ariane)  nClass = CLASS_WIZARD;

   //In search of Raina
   else if (strTag == GEN_FL_Terra)   nClass = CLASS_ROGUE;

   Chargen_SelectCoreClass(oFollower,nClass);

   //Reset plot for next usage.
   WR_SetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_MAGE,FALSE);
   WR_SetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_ROGUE,FALSE);
   WR_SetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_WARRIOR,FALSE);
   WR_SetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_ROGUE_WARRIOR,FALSE);

}

/*******************************************************************************
* Calculate specialization point
*******************************************************************************/
float CalculateSPoint(int Warden_Level){
   float intPoint=0.0;

   if(Warden_Level>=7){
      intPoint = intPoint + 1.;
   }

   if(Warden_Level>=14){
      intPoint = intPoint + 1.;
   }

   return intPoint;
}

/*******************************************************************************
* Package function for event ("Addparty")
*******************************************************************************/
void Event_PartyMemberAddProcess(object oFollower){

     //Disable Immortal effect
     SetImmortal(oFollower,0);

     //Set state to active (Add to warden's 4 man party)
     SetFollowerState(oFollower, FOLLOWER_STATE_ACTIVE);

     //Enable Exp Gain
     SetLocalInt(oFollower, CREATURE_REWARD_FLAGS, 0);

     //Enable Ambient system
     SetLocalInt(oFollower, AMBIENT_SYSTEM_STATE, 0);

     //Enable Follower
     SetObjectActive(oFollower,1);

     //Teleport follower to warden's location
     AddCommand(oFollower, CommandJumpToLocation(GetLocation(GetHero())));

}

/*******************************************************************************
* Package function for event ("partydrop")
*******************************************************************************/
void Event_PartyMemberDropProcess(object oFollower){

     //Enable Immortal effect
     SetImmortal(oFollower,1);

     //Set state to avalible (Drop from warden's 4 man party)
     SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE);

}

/*******************************************************************************
* Package function for feature (Companion Addparty). The character's class will be
  the default setting if intClass is not 999, otherwise it will call SetJob() to assign
  new class, depend on player's choice.
*******************************************************************************/
void SetCompanionAttribute(object oCompanion,int Race, int intClass=999){

   object oHero = GetHero();
   int nLevel = GetLevel(oHero);
   float sPoint = 1.0;

   //Select race, otherwise skills tree wont show
   Chargen_SelectRace(oCompanion, Race);

   /*Set Class--
     If 999 -> Follower will use default class created by author.
     If 997(Custom_Class) -> Follower will use class which is selected by player.
     If not 999 nor 997 -> Follower will use class which is picked by developer.
   */
   if(intClass != 999){
      if(intClass == 997) SetJob(oCompanion);
      else Chargen_SelectCoreClass(oCompanion,intClass);
   }

   //Recalculate the number of tactics slots a creature should have based on level and skills
   Chargen_SetNumTactics(oCompanion);

   //Enabling proper tactics presets based on class (might change at levelup)
   Chargen_EnableTacticsPresets(oCompanion);

   //Add specialization point
   sPoint = CalculateSPoint(nLevel);
   SetCreatureProperty(oCompanion,38,sPoint);

   //Scale up the lvl of armor and weapon base on main character's level
   ScaleEquippedItems(oCompanion, nLevel);

   //Enable approval bar
   SetFollowerApprovalEnabled(oCompanion, TRUE);
   SetFollowerApprovalDescription(oCompanion, 371487);

   //Allow the follower to gain xp
   SetLocalInt(oCompanion, CREATURE_REWARD_FLAGS, 0);

   //Enable Ambient system
   SetLocalInt(oCompanion, AMBIENT_SYSTEM_STATE, 0);

   //Cancel Auto level up
   SetAutoLevelUp(oCompanion,0);

}


/*******************************************************************************
* Package function for adjust plot flag value
*******************************************************************************/
void AdjustPlotFlag(string strFollowerTag, string strFlagType, int nValue, int nCallScript = FALSE){

   if(strFlagType == PlotType_Party){

      //Raina
      if(strFollowerTag == GEN_FL_Terra) WR_SetPlotFlag(PLT_SDT_TERRA, SDT_TERRA_IN_PARTY, nValue, nCallScript);

      //Return to Korcari Wilds
      else if(strFollowerTag == GEN_FL_Ariane)  WR_SetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_IN_PARTY, nValue, nCallScript);
      else if(strFollowerTag == GEN_FL_Douglas) WR_SetPlotFlag(PLT_PT_DOUGLAS, PARTY_DOUGLAS_IN_PARTY, nValue, nCallScript);
      else if(strFollowerTag == GEN_FL_Kenneth) WR_SetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_IN_PARTY, nValue, nCallScript);

   }
}

/*******************************************************************************
* Check "Recruited" flag and modify it if necessary. Also activate the follower
if Recruited == True.
*******************************************************************************/
void CheckFollowerFlag(object oFollower, string strPlot, int FlagRecruited, int FlagCamp){

//-------------------------Check recruited state first--------------------------

   if( WR_GetPlotFlag(strPlot, FlagRecruited) == FALSE &&
        (GetFollowerState(oFollower) == FOLLOWER_STATE_ACTIVE ||
         GetFollowerState(oFollower) == FOLLOWER_STATE_AVAILABLE )
      ){WR_SetPlotFlag(strPlot, FlagRecruited, TRUE);}

//---------------------------Set Follower state---------------------------------

   if( WR_GetPlotFlag(strPlot, FlagRecruited) == TRUE )
    {
        WR_SetPlotFlag(strPlot, FlagCamp, TRUE, TRUE);
        WR_SetObjectActive(oFollower, TRUE);
        SetFollowerState(oFollower,FOLLOWER_STATE_AVAILABLE);
    }

//---------------Change flag value for specific companion-----------------------

   string strTag = GetTag(oFollower);

   if(strTag == GEN_FL_Jory) {
       WR_SetPlotFlag(PLT_PRE100PT_RITUAL, PRE_RITUAL_START, FALSE);
       WR_SetPlotFlag(PLT_PRE100PT_DARKSPN_BLOOD, PRE_BLOOD_PLOT_ACCEPTED, TRUE);
   }
   else if(strTag == GEN_FL_Fenarel){
       WR_SetPlotFlag(PLT_BED000PT_MAIN, BED_MAIN_KEEPER_AT_ARAVEL, FALSE);
       WR_SetPlotFlag(PLT_BED200PT_FENAREL, BED_FENAREL_IN_PARTY, TRUE);
   }
   else if(strTag == GEN_FL_Merrill){
       WR_SetPlotFlag(PLT_BED000PT_MAIN, BED_MAIN_KEEPER_AT_ARAVEL, FALSE);
       WR_SetPlotFlag(PLT_BED200PT_MERRILL, BED_MERRILL_IN_PARTY, TRUE);
   }

}

/*******************************************************************************
* Start the animation for each follower.
*******************************************************************************/
void Camp_FollowerAmbient(object oFollower, int bStart)
{

    string  sTag    =   GetTag(oFollower);
    string  sArea   =   GetTag(GetArea(oFollower));
    int nAnim = 4;

    // Log Record
    Log_Trace(LOG_CHANNEL_PLOT, "Follower: " + sTag, "Found in Area: " + sArea);

    // Set Follower in no-movement phase, just animation.
    SetLocalInt(oFollower, AMBIENT_ANIM_STATE, AMBIENT_ANIM_RESET);

    // Assign ambient variables
    if(!bStart){
        Ambient_Stop(oFollower);
    }else{

        //Main Story
        if     (sTag == GEN_FL_Daveth)           nAnim   =   24;
        else if(sTag == GEN_FL_Jory)             nAnim   =   37;
        else if(sTag == GEN_FL_Fenarel)          nAnim   =   9;
        else if(sTag == GEN_FL_Merrill)          nAnim   =   85;
        else if(sTag == GEN_FL_Moira)            nAnim   =   9;

        //Adopted Dalish
        else if(sTag == GEN_FL_Ilyana)           nAnim   =   37;
        else if(sTag == GEN_FL_Senros)           nAnim   =   100;
        else if(sTag == GEN_FL_Anaise)           nAnim   =   100;
        else if(sTag == GEN_FL_Dominique)        nAnim   =   85;
        else if(sTag == GEN_FL_Merrilyla)        nAnim   =   37;

        //Party Recruiting Mod
        else if(sTag == GEN_FL_Duncan)           nAnim   =   100;
        else if(sTag == GEN_FL_Cailan)           nAnim   =   85;
        else if(sTag == GEN_FL_Andrastalla)      nAnim   =   37;
        else if(sTag == GEN_FL_Anora)            nAnim   =   37;
        else if(sTag == GEN_FL_Flemeth)          nAnim   =   4;
        else if(sTag == GEN_FL_Arl_Eamon)        nAnim   =   71;
        else if(sTag == GEN_FL_Troga)            nAnim   =   70;
        else if(sTag == GEN_FL_Rikku_Templar)    nAnim   =   100;
        else if(sTag == GEN_FL_LadyOfTheForest)  nAnim   =   37;

        //Dark Time Act 1
        else if(sTag == GEN_FL_Isaac)            nAnim   =   100;
        else if(sTag == GEN_FL_Miriam)           nAnim   =   37;
        else if(sTag == GEN_FL_Marukhan)         nAnim   =   85;

        //Tevinter Warden
        else if(sTag == GEN_FL_Lanna)            nAnim   =   100;
        else if(sTag == GEN_FL_Marric)           nAnim   =   71;
        else if(sTag == GEN_FL_Martin)           nAnim   =   70;
        else if(sTag == GEN_FL_Willam)           nAnim   =   48;

        //Lealion
        else if(sTag == GEN_FL_Lealion)          nAnim   =   37;
        else if(sTag == GEN_FL_Legion)           nAnim   =   4;

        //Enigma
        else if(sTag == GEN_FL_Vekuul)           nAnim   =   100;
        else if(sTag == GEN_FL_Vishala)          nAnim   =   70;
        else if(sTag == GEN_FL_helperlady)       nAnim   =   37;

        //Warden's women
        else if(sTag == GEN_FL_Mithra)           nAnim   =   48;
        else if(sTag == GEN_FL_Elora)            nAnim   =   71;

        //In search of Raina
        else if(sTag == GEN_FL_Terra)            nAnim   =   24;

        //Return to Korcari Wild
        else if(sTag == GEN_FL_Ariane)           nAnim   =   37;
        else if(sTag == GEN_FL_Douglas)          nAnim   =   85;
        else if(sTag == GEN_FL_Kenneth)          nAnim   =   71;

        //Other Mod Companions...


        Ambient_Start(oFollower, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, nAnim, AMBIENT_ANIM_FREQ_ORDERED);

        Log_Trace(LOG_CHANNEL_PLOT, "Starting Ambient Animations for: " + sTag, "Playing Animation: " + IntToString(nAnim));

    }
}

/**********************************************************************
Temporary dismiss warden's party and record member name in the global
variable.
***********************************************************************/
void RemovePartyMember(){

}

/**********************************************************************
Resummon companion as party member. There might be a situation which
player uninstall other mod while companion is still in the warden's party,
This method will check if mod is install first.
***********************************************************************/
void ReSummonPartyMember(string strName){

     object oFollower;

     if(strName != "" ){
        if(IsModInstall(GetModNameByCompanion(strName))){
            oFollower = Party_GetFollowerByTag(strName);
            Event_PartyMemberAddProcess(oFollower);
        }
     }
}
