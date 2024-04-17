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

    //Return to KW
         if(strTag == GEN_FL_Ariane)    FollowerPosition = Position(68.0122,44.4942,0.392062,139.9);
    else if(strTag == GEN_FL_Douglas)   FollowerPosition = Position(65.5337,44.5532,0.363952,139.9);
    else if(strTag == GEN_FL_Kenneth)   FollowerPosition = Position(65.2557,50.5995,0.208606,45.0);

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

    //Tevinter Warden
    else if(strTag == GEN_FL_Lanna)     FollowerPosition = Position(69.7907,50.6205,0.249061,45.0);
    else if(strTag == GEN_FL_Marric)    FollowerPosition = Position(70.065 ,44.4927,0.427784,139.9);
    else if(strTag == GEN_FL_Martin)    FollowerPosition = Position(72.1146,44.5143,0.416375,139.9);
    else if(strTag == GEN_FL_Willam)    FollowerPosition = Position(72.0421,50.6125,0.222319,45.0);

    //Enigma
    else if(strTag == GEN_FL_Vekuul)      FollowerPosition = Position(74.9521,44.5138,0.289806,139.9);
    else if(strTag == GEN_FL_Vishala)     FollowerPosition = Position(74.6203,50.6274,0.171244,45.0);
    else if(strTag == GEN_FL_helperlady)  FollowerPosition = Position(77.228 ,50.6139,0.070779,45.0);
    else if(strTag == GEN_FL_HighDragon)  FollowerPosition = Position(109.569,45.5032,2.95715,90.0);

    //The Warden's Women
    else if(strTag == GEN_FL_Mithra)    FollowerPosition = Position(67.6161,50.585,0.204323,45.0);
    else if(strTag == GEN_FL_Elora)     FollowerPosition = Position(77.1551,44.46 ,0.211574,139.9);

    //Raina
    else if(strTag == GEN_FL_Terra)     FollowerPosition = Position(79.4971,50.6592,0.0787402,45.0);
    else if(strTag == GEN_FL_Raina)     FollowerPosition = Position(81.7459,50.7323,0.12816,45.0);
    else if(strTag == GEN_FL_Pride)     FollowerPosition = Position(109.569,45.5032,2.95715,90.0);

    //Orand_Serenity
    else if(strTag == GEN_FL_Serenity)  FollowerPosition = Position(79.2484,44.4388,0.172884,139.9);
    else if(strTag == GEN_FL_Sylvan)    FollowerPosition = Position(109.569,45.5032,2.95715,90.0);



    return FollowerPosition;
}

/*******************************************************************************
* Return a set of camp position for different companion.
*******************************************************************************/
struct FCoordinate GetFollowerCampPosition(string strTag){

    struct FCoordinate FollowerPosition = Position(0.0,0.0,0.0,0.0);

    //Return to Korcari Wilds  (Camp 1)

         if(strTag == GEN_FL_Ariane)    FollowerPosition = Position(171.395,152.458,-0.744983,-127.0);
    else if(strTag == GEN_FL_Douglas)   FollowerPosition = Position(170.595,150.869,-0.767359,-104.9);
    else if(strTag == GEN_FL_Kenneth)   FollowerPosition = Position(170.77 ,149.102,-0.971386,-74.9);

    return FollowerPosition;

}

/*******************************************************************************
* Return a set of position on the story map for different follower
*******************************************************************************/
struct FCoordinate GetFollowerPosition_StoryMap(string strTag){

    struct FCoordinate FollowerPosition = Position(0.0,0.0,0.0,0.0);

    //Spawn position at Korcari Wilds
    if(strTag == GEN_FL_Ariane)    FollowerPosition = Position(1110.775, 800.5671, 12.52761,139.9);

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
              There might be a situation which follower existed but recruited flag is false(new user)

*******************************************************************************/
void SpawnCompanion(int ModName, string strMap, string strTag,
                    string strAgentTag, string strPlot, int nFlag,
                    resource RFollower){

    object oMap = GetObjectByTag(strMap);
    object oAgent;
    object oFollower;
    string strWP;

    //Catch agent object from map
    if(strAgentTag != "NONE") oAgent = GetObjectByTag(strAgentTag);

    //If the required mod is install, enable agent then start follower spawn section
    if(IsModInstall(ModName)){

       //Enable agent
       if(strAgentTag != "NONE") SetObjectActive(oAgent,TRUE);

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
      if(strAgentTag != "NONE") SetObjectActive(oAgent,FALSE);
    }
}

/*******************************************************************************
* Create a new NPC object at giving location on the specific map.
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

/*******************************************************************************
* Create a new NPC object at giving location on the specific map.
*******************************************************************************/
void SpawnCompanion_StoryPosition(int ModName, string strMap, string strTag, resource FResource){

    object oMap = GetObjectByTag(strMap);
    object oFollower;
    struct FCoordinate pos = GetFollowerPosition_StoryMap(strTag);
    vector vTent = Vector(pos.x,pos.y,pos.z);

    if(IsModInstall(ModName)){
       CreateObject(OBJECT_TYPE_CREATURE, FResource ,Location(oMap, vTent, pos.angle) );
    }
}

/*******************************************************************************
* Spawn companion at giving location on the party map.
*******************************************************************************/
void SpawnCompanion_PartyCamp(string strMap, string strTag, object oFollower){

    object   oMap = GetObjectByTag(strMap);

    struct   FCoordinate pos = GetFollowerCampPosition(strTag);
    vector   vTent = Vector(pos.x,pos.y,pos.z);
    location oDest = Location(oMap, vTent, pos.angle);

    command  cMove = CommandJumpToLocation(oDest);

    AddCommand(oFollower, cMove);

}





