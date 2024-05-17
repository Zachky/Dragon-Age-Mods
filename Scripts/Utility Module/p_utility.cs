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
#include "party_h"
#include "global_objects_2"

//---------Plot for class-------------
#include "plt_gen00pt_list_class"

//---------Plot for each mod----------
#include "plt_gen00pt_party"
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
#include "plt_gen00pt_ndq_elora"
#include "plt_sdt_mod_raina"
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
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"gina_ma.utc", Location(oMap, vTent, 0.0f));
          break;
       }

       case Lady_Orand:
       {
          oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"orand_wizserenity.utc", Location(oMap, vTent, 0.0f));
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

    //Orand Serenity
    else if(strTag == GEN_FL_Serenity) ModName = Lady_Orand;

    //In search of Raina
    else if(strTag == GEN_FL_Terra) ModName = Raina;
    else if(strTag == GEN_FL_Raina) ModName = Raina;

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

    return ModName;
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
void AdjustPlotFlag(string strFlagType, int nValue, string strFollowerTag = "", int nCallScript = FALSE, int AllAtOnce = FALSE){

   if(strFlagType == PlotType_Party){

      //Main Story Follower
      if(strFollowerTag == GEN_FL_Alistair || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_ALISTAIR_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Dog      || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_DOG_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Leliana  || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_LELIANA_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Loghain  || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_LOGHAIN_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Morrigan || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_MORRIGAN_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Oghren   || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_OGHREN_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Shale    || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_SHALE_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Sten     || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_STEN_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Wynne    || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_WYNNE_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Zervan   || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_ZEVRAN_IN_PARTY, nValue, nCallScript);

      //Raina
      if(strFollowerTag == GEN_FL_Terra   || AllAtOnce) WR_SetPlotFlag(PLT_SDT_MOD_RAINA, GEN_TERRA_IN_PARTY, nValue, nCallScript);

      //Return to Korcari Wilds
      if(strFollowerTag == GEN_FL_Ariane  || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Douglas || AllAtOnce) WR_SetPlotFlag(PLT_PT_DOUGLAS, PARTY_DOUGLAS_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Kenneth || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_IN_PARTY, nValue, nCallScript);

      //Core Story
      if(strFollowerTag == GEN_FL_Daveth  || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_DAVETH_IN_PARTY  , nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Jory    || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_JORY_IN_PARTY    , nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Fenarel || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_FENAREL_IN_PARTY , nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Merrill || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_IN_PARTY , nValue, nCallScript);

      //Small Restoration
      if(strFollowerTag == GEN_FL_Moira   || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_MOIRA_IN_PARTY   , nValue, nCallScript);

      //Adopted Dalish
      if(strFollowerTag == GEN_FL_Ilyana    || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_ILYANA_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Senros    || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_SENROS_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Anaise    || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_ANAISE_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Dominique || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_DOMINIQUE_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Merrilyla || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_MERRILYLA_IN_PARTY, nValue, nCallScript);

      //Dark Time
      if(strFollowerTag == GEN_FL_Isaac     || AllAtOnce) WR_SetPlotFlag(PLT_DT_ACT1, GEN_ISAAC_IN_PARTY , nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Miriam    || AllAtOnce) WR_SetPlotFlag(PLT_DT_ACT1, GEN_MIRIAM_IN_PARTY, nValue, nCallScript);

      //Enigma
      if(strFollowerTag == GEN_FL_Vekuul     || AllAtOnce) WR_SetPlotFlag(PLT_ENIGMA_PLOT1, GEN_VEKUUL_IN_PARTY,     nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Vishala    || AllAtOnce) WR_SetPlotFlag(PLT_ENIGMA_PLOT1, GEN_VISHALA_IN_PARTY,    nValue, nCallScript);
      if(strFollowerTag == GEN_FL_helperlady || AllAtOnce) WR_SetPlotFlag(PLT_ENIGMA_PLOT1, GEN_HELPERLADY_IN_PARTY, nValue, nCallScript);

      //Lealion
      if(strFollowerTag == GEN_FL_Lealion || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Legion  || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_PARTY , nValue, nCallScript);

      //Tevinter Warden
      if(strFollowerTag == GEN_FL_Lanna  || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_LANNA,  GEN_LANNA_IN_PARTY , nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Marric || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Martin || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Willam || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_WILLAM, GEN_WILLAM_IN_PARTY, nValue, nCallScript);

      //Warden's women
      if(strFollowerTag == GEN_FL_Mithra || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_NDQ_MITHRA, GEN_MITHRA_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Elora  || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_NDQ_ELORA,  GEN_ELORA_IN_PARTY,  nValue, nCallScript);

      //Party Recruiting
      if(strFollowerTag == GEN_FL_Andrastalla     || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ANDRASTALLA_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Troga           || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_TROGA_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Rikku_Templar   || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_RIKKU_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Duncan          || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_DUNCAN_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Cailan          || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_CAILAN_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Anora           || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ANORA_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Flemeth         || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_FLEMETH_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_Arl_Eamon       || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ARL_EAMON_IN_PARTY, nValue, nCallScript);
      if(strFollowerTag == GEN_FL_LadyOfTheForest || AllAtOnce) WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_LADYOFTHEFOREST_IN_PARTY, nValue, nCallScript);

   }
}

int GetPlotFlag(string strFlagType, string strFollowerTag){

   int Result = FALSE;

   if(strFlagType == PlotType_Party){

      //Main Story Follower
      if(strFollowerTag == GEN_FL_Alistair && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_ALISTAIR_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Dog      && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_DOG_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Leliana  && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_LELIANA_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Loghain  && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_LOGHAIN_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Morrigan && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_MORRIGAN_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Oghren   && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_OGHREN_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Shale    && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_SHALE_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Sten     && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_STEN_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Wynne    && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_WYNNE_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Zervan   && WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_ZEVRAN_IN_PARTY)) Result = TRUE;

      //Raina
      if(strFollowerTag == GEN_FL_Terra    && WR_GetPlotFlag(PLT_SDT_MOD_RAINA, GEN_TERRA_IN_PARTY)) Result = TRUE;

      //Return to Korcari Wilds
      if(strFollowerTag == GEN_FL_Ariane   && WR_GetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Douglas  && WR_GetPlotFlag(PLT_PT_DOUGLAS, PARTY_DOUGLAS_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Kenneth  && WR_GetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_IN_PARTY)) Result = TRUE;

      //Core Story
      if(strFollowerTag == GEN_FL_Daveth   && WR_GetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_DAVETH_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Jory     && WR_GetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_JORY_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Fenarel  && WR_GetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_FENAREL_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Merrill  && WR_GetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_IN_PARTY)) Result = TRUE;

      //Small Restoration
      if(strFollowerTag == GEN_FL_Moira    && WR_GetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_MOIRA_IN_PARTY)) Result = TRUE;

      //Adopted Dalish
      if(strFollowerTag == GEN_FL_Ilyana    && WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_ILYANA_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Senros    && WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_SENROS_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Anaise    && WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_ANAISE_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Dominique && WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_DOMINIQUE_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Merrilyla && WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_MERRILYLA_IN_PARTY)) Result = TRUE;

      //Dark Time
      if(strFollowerTag == GEN_FL_Isaac     && WR_GetPlotFlag(PLT_DT_ACT1, GEN_ISAAC_IN_PARTY))  Result = TRUE;
      if(strFollowerTag == GEN_FL_Miriam    && WR_GetPlotFlag(PLT_DT_ACT1, GEN_MIRIAM_IN_PARTY)) Result = TRUE;

      //Enigma
      if(strFollowerTag == GEN_FL_Vekuul     && WR_GetPlotFlag(PLT_ENIGMA_PLOT1, GEN_VEKUUL_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Vishala    && WR_GetPlotFlag(PLT_ENIGMA_PLOT1, GEN_VISHALA_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_helperlady && WR_GetPlotFlag(PLT_ENIGMA_PLOT1, GEN_HELPERLADY_IN_PARTY)) Result = TRUE;

      //Lealion
      if(strFollowerTag == GEN_FL_Lealion && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Legion  && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_PARTY)) Result = TRUE;

      //Tevinter Warden
      if(strFollowerTag == GEN_FL_Lanna  && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LANNA, GEN_LANNA_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Marric && WR_GetPlotFlag(PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Martin && WR_GetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Willam && WR_GetPlotFlag(PLT_GEN00PT_PARTY_WILLAM, GEN_WILLAM_IN_PARTY)) Result = TRUE;

      //Warden's women
      if(strFollowerTag == GEN_FL_Mithra && WR_GetPlotFlag(PLT_GEN00PT_NDQ_MITHRA, GEN_MITHRA_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Elora  && WR_GetPlotFlag(PLT_GEN00PT_NDQ_ELORA, GEN_ELORA_IN_PARTY)) Result = TRUE;

      //Party Recruiting
      if(strFollowerTag == GEN_FL_Andrastalla     && WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ANDRASTALLA_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Troga           && WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_TROGA_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Rikku_Templar   && WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_RIKKU_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Duncan          && WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_DUNCAN_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Cailan          && WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_CAILAN_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Anora           && WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ANORA_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Flemeth         && WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_FLEMETH_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_Arl_Eamon       && WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ARL_EAMON_IN_PARTY)) Result = TRUE;
      if(strFollowerTag == GEN_FL_LadyOfTheForest && WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_LADYOFTHEFOREST_IN_PARTY)) Result = TRUE;

   }

   return Result;
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
        else if(sTag == GEN_FL_Raina)            nAnim   =   9;

        //Return to Korcari Wild
        else if(sTag == GEN_FL_Ariane)           nAnim   =   37;
        else if(sTag == GEN_FL_Douglas)          nAnim   =   85;
        else if(sTag == GEN_FL_Kenneth)          nAnim   =   71;

        //Orand Serenity
        else if(sTag == GEN_FL_Serenity)         nAnim   =   37;

        //Other Mod Companions...


        Ambient_Start(oFollower, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, nAnim, AMBIENT_ANIM_FREQ_ORDERED);

        Log_Trace(LOG_CHANNEL_PLOT, "Starting Ambient Animations for: " + sTag, "Playing Animation: " + IntToString(nAnim));

    }
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
