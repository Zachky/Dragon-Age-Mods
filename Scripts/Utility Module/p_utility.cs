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

//#include "plt_gen00pt_party_recruit"

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

void SetCompanionAttribute(object oCompanion,int Race){

   object oHero = GetHero();
   int nLevel = GetLevel(oHero);
   float sPoint = 1.0;

   //Select race, otherwise skills tree wont show
   Chargen_SelectRace(oCompanion, Race);

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

   //Cancel Auto level up
   SetAutoLevelUp(oCompanion,0);

}

/* void SetPartyPlotFlagStats(string strTag, string keyword, int stats = FALSE){

    string strPlot = "";
    int intFlag = 0;

    //1. Find Plot Name

    if (strTag == GEN_FL_Andrastalla ||
        strTag == GEN_FL_Troga ||
        strTag == GEN_FL_Rikku_Templar ||
        strTag == GEN_FL_Duncan ||
        strTag == GEN_FL_Cailan ||
        strTag == GEN_FL_Anora ||
        strTag == GEN_FL_Flemeth ||
        strTag == GEN_FL_Arl_Eamon ||
        strTag == GEN_FL_LadyOfTheForest){

        strPlot = "PLT_GEN00PT_PARTY_RECRUIT";
    }
    //else if..for other mod


   //2. Find Flag Number
   if (keyword == "Party"){
        if(strTag == GEN_FL_Andrastalla){ intFlag = GEN_ANDRASTALLA_IN_PARTY; }
   }

   //3. Set Plot Flag
   WR_SetPlotFlag(strPlot,intFlag,stats);
} */
