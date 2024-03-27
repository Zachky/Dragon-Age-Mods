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
void SpawnCompanion(string strMap, string strTag){

    object oMap = GetObjectByTag(strMap);
    object oAgent;
    object oFollower;
    string strWP;


    //Anaise
    if (strTag == GEN_FL_Anaise){

       //Catch agent object from map
       oAgent = GetObjectByTag(Agent_Anaise);

       //If the required mod is install, enable agent then start follower spawn section
       if(IsModInstall(Adopted_Dalish)){

          //Enable agent
          SetObjectActive(oAgent,TRUE);

          //Follower spawn section
          if((!IsFollowerInPartyPool(strTag)) && (!WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_ANAISE_RECRUITED)) ){

              oFollower = GetObjectByTag(strTag);
              if(!IsObjectValid(oFollower)){
                 oFollower = CreateObject(OBJECT_TYPE_CREATURE, R"ado00fl_anaise.utc" ,GetLocation(GetHero()));
              }

              WR_SetObjectActive(oFollower,TRUE);

              strWP = RC_FOLLOWER_PREFIX + strTag;
              UT_LocalJump(oFollower, strWP);
          }

       }else{
          SetObjectActive(oAgent,FALSE);
       }
    }

    //Moira
    if (strTag == GEN_FL_Moira){

       //Catch agent object from map
       oAgent = GetObjectByTag(Agent_Moira);

       //If the required mod is install, enable agent then start follower spawn section
       if(IsModInstall(Small_Restoration)){

          //Enable agent
          SetObjectActive(oAgent,TRUE);

          //Follower spawn section
          if((!IsFollowerInPartyPool(strTag)) && (!WR_GetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_MOIRA_RECRUITED)) ){

              oFollower = GetObjectByTag(strTag);
              if(!IsObjectValid(oFollower)){
                 oFollower = CreateObject(OBJECT_TYPE_CREATURE, R"camp_bloodmage.utc" ,GetLocation(GetHero()));
              }

              WR_SetObjectActive(oFollower,TRUE);

              strWP = RC_FOLLOWER_PREFIX + strTag;
              UT_LocalJump(oFollower, strWP);
          }

       }else{
          SetObjectActive(oAgent,FALSE);
       }
    }


}

/*******************************************************************************
* Spawn companion at giving location on the specific map.
*******************************************************************************/
void SpawnCompanion_location(string strMap, string strTag){

    object oMap = GetObjectByTag(strMap);
    object oFollower;
    struct FCoordinate pos = GetFollowerPosition(strTag);
    vector vTent = Vector(pos.x,pos.y,pos.z);

    //Adopted Dalish
    if(strTag == GEN_FL_Anaise && IsModInstall(Adopted_Dalish)){
       CreateObject(OBJECT_TYPE_CREATURE, R"ado00fl_anaise.utc" ,Location(oMap, vTent, pos.angle) );
    }



    //Small Restoration
    else if(strTag == GEN_FL_Moira && IsModInstall(Small_Restoration)){
       CreateObject(OBJECT_TYPE_CREATURE, R"camp_bloodmage.utc" ,Location(oMap, vTent, pos.angle) );
    }

}



    //2. Follower in the party pool check



    //3.


    /*if(strTag == GEN_FL_Ariane){
       if(!WR_GetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_RECRUITED) && !IsObjectValid(oCreature)){

          FollowerState = GetFollowerState(oCreature);
          CreateObject(OBJECT_TYPE_CREATURE, R"party_zaf.utc" ,GetLocation(OBJECT_SELF));


       }
    }

    //Core Story
    else if (strTag == GEN_FL_Daveth){
       if(!WR_GetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_DAVETH_RECRUITED)){
          CreateObject(OBJECT_TYPE_CREATURE, R"pre100cr_daveth.utc" ,Location(oMap, vTent, pos.angle));
       }
    }
    else if (strTag == GEN_FL_Jory){
       if(!WR_GetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_JORY_RECRUITED)){
          CreateObject(OBJECT_TYPE_CREATURE, R"pre100cr_jory.utc" ,Location(oMap, vTent, pos.angle));
       }
    }

    //Small Restoration
    else if (strTag == GEN_FL_Moira){
       if(!WR_GetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_MOIRA_RECRUITED)){
          CreateObject(OBJECT_TYPE_CREATURE, R"camp_bloodmage.utc" ,Location(oMap, vTent, pos.angle));

       }
    }

    //Adopted Dalish
    else if (strTag == GEN_FL_Ilyana){
       if(!WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_ILYANA_RECRUITED)){
          CreateObject(OBJECT_TYPE_CREATURE, R"ado_companion_ilyana.utc" ,Location(oMap, vTent, pos.angle));

       }
    }
    else if (strTag == GEN_FL_Senros){
       if(!WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_SENROS_RECRUITED)){
          CreateObject(OBJECT_TYPE_CREATURE, R"ado_companion_senros.utc" ,Location(oMap, vTent, pos.angle));

       }
    }
    else if (strTag == GEN_FL_Dominique){
       if(!WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_DOMINIQUE_RECRUITED)){
          CreateObject(OBJECT_TYPE_CREATURE, R"ado00fl_dominique.utc" ,Location(oMap, vTent, pos.angle));

       }
    }
    else if (strTag == GEN_FL_Merrilyla){
       if(!WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_MERRILYLA_RECRUITED)){
          CreateObject(OBJECT_TYPE_CREATURE, R"ado00fl_merrilyla.utc" ,Location(oMap, vTent, pos.angle));

       }
    }
    else if (strTag == GEN_FL_Anaise){
       if(!WR_GetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_ANAISE_RECRUITED)){





       }
    } */




