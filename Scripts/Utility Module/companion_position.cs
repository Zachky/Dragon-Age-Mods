#include "wrappers_h"
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

         if(strTag == GEN_FL_Ariane) FollowerPosition = Position(1110.775, 800.5671, 12.52761,139.9);

    //Core Story
    else if(strTag == GEN_FL_Daveth)    FollowerPosition = Position(55.6314,50.5925,0.0878551,45.0);
    else if(strTag == GEN_FL_Jory)      FollowerPosition = Position(55.6874,44.4423,0.173324 ,139.9);

    //Adopted Dalish
    else if(strTag == GEN_FL_Ilyana)    FollowerPosition = Position(50.4634,44.4572,0.0,139.9);
    else if(strTag == GEN_FL_Senros)    FollowerPosition = Position(50.562 ,50.6404,0.0,45.0);
    else if(strTag == GEN_FL_Dominique) FollowerPosition = Position(53.154 ,50.5959,0.0,45.0);
    else if(strTag == GEN_FL_Merrilyla) FollowerPosition = Position(53.2299,44.4601,0.0220574,139.9);


    return FollowerPosition;
}

/*******************************************************************************
* Spawn companion at giving map. This function will check flag to decide if this companion
  should spawn or not.
*******************************************************************************/
void SpawnCompanion(string strMap, string strTag){

    object oMap = GetObjectByTag(strMap);
    struct FCoordinate pos = GetFollowerPosition(strTag);
    vector vTent = Vector(pos.x,pos.y,pos.z);

    if(strTag == GEN_FL_Ariane){
       if(!WR_GetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_RECRUITED)){
          CreateObject(OBJECT_TYPE_CREATURE, R"party_zaf.utc" ,Location(oMap, vTent, pos.angle));
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




}


