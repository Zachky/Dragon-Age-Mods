//---------------------------------------------------------------------
/*
     Note:

        1. Race list in the file "2da_constants_h.nss"
        2. The max value of Spec point is 2

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "sys_chargen_h"
#include "global_objects_2"

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
* Package function for feature (Companion Addparty)
*******************************************************************************/
void SetCompanionAttribute(object oCompanion,int Race, int intClass=999){

   object oHero = GetHero();
   int nLevel = GetLevel(oHero);
   float sPoint = 1.0;

   //Select race, otherwise skills tree wont show
   Chargen_SelectRace(oCompanion, Race);

   //Select class if specified:
   if(intClass != 999){
      Chargen_SelectCoreClass(oCompanion,intClass);
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

