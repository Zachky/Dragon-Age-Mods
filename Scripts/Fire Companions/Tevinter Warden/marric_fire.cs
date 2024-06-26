/*
     Remove Marric from party

     usage:

        runscript marric_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"
#include "companion_position"

//Import plot module
#include "plt_gen00pt_party_marric"

void main()
{
    object oFollower = GetObjectByTag(GEN_FL_Marric);

    //Get current area tag
    string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

    //Fire Companion
    UT_FireFollower(oFollower, TRUE, TRUE);

    /*-------------------------------------------------------------------------
       Set plot flag "Recruited" to true for other feature.
       Original Plot file has created, hired and fired flag. To ensure other
       feature goes as it should be, set these flags with appropriate value.
    ---------------------------------------------------------------------------*/
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_CREATED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_HIRED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_FIRED, TRUE);

    DestroyObject(oFollower);

    //Respawn the npc if warden sit on the map where npc show up in the first place.
    if(MapTag == CORE_RecruitCenter){
       SpawnCompanion_location(Tevinter_Warden, MapTag, GEN_FL_Marric, R_Marric );
    }

}