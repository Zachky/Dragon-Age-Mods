/*
     Remove Ariane from party

     usage:

        runscript ariane_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"
#include "companion_position"

//Import plot module
#include "plt_gen00pt_return_to_kw"

void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Ariane);

    //Get current area tag
   string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set plot flag "Recruited" to true for other feature
   WR_SetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_RECRUITED, FALSE, TRUE);

   DestroyObject(oFollower);

   //Respawn the npc if warden sit on the map where npc show up in the first place.
   if(MapTag == CORE_RecruitCenter){
      SpawnCompanion_location(Return_to_KW, MapTag, GEN_FL_Ariane, R_Ariane);
   }

}