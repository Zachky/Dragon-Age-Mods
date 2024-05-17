/*
     Remove Merrill from party

     usage:

        runscript merrill_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"
#include "companion_position"

//Import plot module
#include "plt_gen00pt_main_story"
void main()
{
    object oFollower = GetObjectByTag(GEN_FL_Merrill);

    //Get current area tag
    string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

    //Fire Companion
    UT_FireFollower(oFollower, TRUE, TRUE);

    //Set plot flag "Recruited" to false for other feature
    WR_SetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_RECRUITED, FALSE, TRUE);

    DestroyObject(oFollower);

    //Respawn the npc if warden sit on the map where npc show up in the first place.
    if(MapTag == CORE_RecruitCenter){
       SpawnCompanion_location(Main_Story, MapTag, GEN_FL_Merrill, R_Merrill );
    }

}