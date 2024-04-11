/*
     Remove Douglas from party

     usage:

        runscript douglas_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"
#include "companion_position"

//Import plot module
#include "plt_pt_douglas"
void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Douglas);

    //Get current area tag
   string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set plot flag "Recruited" to false.
   WR_SetPlotFlag(PLT_PT_DOUGLAS, PARTY_DOUGLAS_JOINED, FALSE, TRUE);

   DestroyObject(oFollower);

   //Respawn the npc if warden sit on the map where npc show up in the first place.
   if(MapTag == CORE_RecruitCenter){
      SpawnCompanion_location(Return_to_KW, MapTag, GEN_FL_Douglas, R_Douglas);
   }

}