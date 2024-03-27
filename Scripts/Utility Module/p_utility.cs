//---------------------------------------------------------------------
/*
    p_utility: Core module which provide necessary function to check 
    or setup data.

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

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

    }

    if(!IsObjectValid(oTestCreature)){
       DestroyObject(oTestCreature);
       return FALSE;
    }
    DestroyObject(oTestCreature);
    return TRUE;
}

/*******************************************************************************
* Identify and assign class base on player's choice.
*******************************************************************************/
void SetJob(object oFollower){

   int nClass;

   string strTag = GetTag(oFollower);

   if(strTag == GEN_FL_Anaise){
       nClass = CLASS_ROGUE;
       if      (WR_GetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_MAGE))          nClass = CLASS_WIZARD;
       else if (WR_GetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_ROGUE))         nClass = CLASS_ROGUE;
       else if (WR_GetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_WARRIOR))       nClass = CLASS_WARRIOR;

   }else if(strTag == GEN_FL_Moira){
       nClass = CLASS_ROGUE;
       if      (WR_GetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_MAGE))          nClass = CLASS_WIZARD;
       else if (WR_GetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_ROGUE))         nClass = CLASS_ROGUE;
       else if (WR_GetPlotFlag(PLT_GEN00PT_LIST_CLASS,IS_WARRIOR))       nClass = CLASS_WARRIOR;

   }

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

