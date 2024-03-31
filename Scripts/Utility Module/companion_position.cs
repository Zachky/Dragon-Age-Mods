//---------------------------------------------------------------------
/*
     This module response for placing companion at different map when they
     are not being hired by warden.

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------
#include "wrappers_h"
#include "global_objects_2"
#include "p_utility"

//--------Plot for main story character----
#include "plt_pre100pt_darkspn_blood"
#include "plt_pre100pt_ritual"
#include "plt_bed000pt_main"
#include "plt_bed200pt_fenarel"
#include "plt_bed200pt_merrill"

const string RC_FOLLOWER_PREFIX = "rc_";

struct FCoordinate{
    float x,y,z,angle;
};

struct FCoordinate Position(float fx, float fy, float fz, float fangle){

    struct FCoordinate p;

    p.x = fx;
    p.y = fy;
    p.z = fz;
    p.angle = fangle;

    return p;
}

/*******************************************************************************
* Return a set of position for different companion.
*******************************************************************************/
struct FCoordinate GetFollowerPosition(string strTag){

    struct FCoordinate FollowerPosition = Position(0.0,0.0,0.0,0.0);

         if(strTag == GEN_FL_Ariane)    FollowerPosition = Position(1110.775, 800.5671, 12.52761,139.9);

    //Small Restoration
    else if(strTag == GEN_FL_Moira)     FollowerPosition = Position(55.7662,50.631 ,0.0960027,45.0);

    //Core Story
    else if(strTag == GEN_FL_Daveth)    FollowerPosition = Position(58.181 ,50.6084,0.198706 ,45.0);
    else if(strTag == GEN_FL_Jory)      FollowerPosition = Position(58.2371,44.4582,0.348582 ,139.9);
    else if(strTag == GEN_FL_Fenarel)   FollowerPosition = Position(60.557 ,50.6131,0.187916 ,45.0);
    else if(strTag == GEN_FL_Merrill)   FollowerPosition = Position(60.5977,44.4964,0.40784  ,139.9);

    //Adopted Dalish
    else if(strTag == GEN_FL_Anaise)    FollowerPosition = Position(55.7778,44.4541,0.181982,139.9);
    else if(strTag == GEN_FL_Ilyana)    FollowerPosition = Position(50.4634,44.4572,0.0,139.9);
    else if(strTag == GEN_FL_Senros)    FollowerPosition = Position(50.562 ,50.6404,0.0,45.0);
    else if(strTag == GEN_FL_Dominique) FollowerPosition = Position(53.154 ,50.5959,0.0,45.0);
    else if(strTag == GEN_FL_Merrilyla) FollowerPosition = Position(53.2299,44.4601,0.0220574,139.9);

    //Dark Time Act 1
    else if(strTag == GEN_FL_Isaac)     FollowerPosition = Position(62.8907,50.6258,0.163582,45.0);
    else if(strTag == GEN_FL_Miriam)    FollowerPosition = Position(62.9314,44.509 ,0.365555,139.9);

    return FollowerPosition;
}

/*******************************************************************************
* Spawn companion at giving map. This function will check flag to decide if this companion
  should spawn or not.

  Spawn Condition :
              1. Mod is installed and
              2. RECRUITED flag is false or
              3. Target Follower is not exist(not in the party pool)
              Use OR on 2 and 3, then AND with 1,
              There might be a situation where follower existed but recruited flag is false(new user)

*******************************************************************************/
void SpawnCompanion(int ModName, string strMap, string strTag,
                    string strAgentTag, string strPlot, int nFlag,
                    resource RFollower){

    object oMap = GetObjectByTag(strMap);
    object oAgent;
    object oFollower;
    string strWP;

    //Catch agent object from map
    oAgent = GetObjectByTag(strAgentTag);

    //If the required mod is install, enable agent then start follower spawn section
    if(IsModInstall(ModName)){

       //Enable agent
       SetObjectActive(oAgent,TRUE);

       //Follower spawn section
       if((!IsFollowerInPartyPool(strTag)) && (!WR_GetPlotFlag(strPlot, nFlag)) ){

           oFollower = GetObjectByTag(strTag);
           if(!IsObjectValid(oFollower)){
              oFollower = CreateObject(OBJECT_TYPE_CREATURE, RFollower ,GetLocation(GetHero()));
           }

           WR_SetObjectActive(oFollower,TRUE);

           strWP = RC_FOLLOWER_PREFIX + strTag;
           UT_LocalJump(oFollower, strWP);

           //Change flag value for specific companion
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

    }else{
       SetObjectActive(oAgent,FALSE);
    }
}

/*******************************************************************************
* Spawn companion at giving location on the specific map.
*******************************************************************************/
void SpawnCompanion_location(int ModName, string strMap, string strTag, resource FResource){

    object oMap = GetObjectByTag(strMap);
    object oFollower;
    struct FCoordinate pos = GetFollowerPosition(strTag);
    vector vTent = Vector(pos.x,pos.y,pos.z);

    if(IsModInstall(ModName)){
       CreateObject(OBJECT_TYPE_CREATURE, FResource ,Location(oMap, vTent, pos.angle) );

       //Change flag value for specific companion
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
}

