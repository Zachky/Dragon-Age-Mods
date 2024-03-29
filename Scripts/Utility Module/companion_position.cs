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
    else if(strTag == GEN_FL_Daveth)    FollowerPosition = Position(55.6314,50.5925,0.0878551,45.0);
    else if(strTag == GEN_FL_Jory)      FollowerPosition = Position(55.6874,44.4423,0.173324 ,139.9);

    //Adopted Dalish
    else if(strTag == GEN_FL_Anaise)    FollowerPosition = Position(55.7778,44.4541,0.181982,139.9);
    else if(strTag == GEN_FL_Ilyana)    FollowerPosition = Position(50.4634,44.4572,0.0,139.9);
    else if(strTag == GEN_FL_Senros)    FollowerPosition = Position(50.562 ,50.6404,0.0,45.0);
    else if(strTag == GEN_FL_Dominique) FollowerPosition = Position(53.154 ,50.5959,0.0,45.0);
    else if(strTag == GEN_FL_Merrilyla) FollowerPosition = Position(53.2299,44.4601,0.0220574,139.9);


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
    }
}

