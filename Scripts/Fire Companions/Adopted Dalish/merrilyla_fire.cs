/*
     Remove Merrilyla from party

     usage:

        runscript merrilyla_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"
#include "companion_position"

//Import plot module
#include "plt_gen00pt_adopted_dalish"

void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Merrilyla);

   //Get current area tag
   string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set plot flag "Recruited" to true for other feature
   WR_SetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_MERRILYLA_RECRUITED, FALSE);

   DestroyObject(oFollower);

   //Respawn the npc if warden sit on the map where npc show up in the first place.
   if(MapTag == CORE_RecruitCenter){
      SpawnCompanion_location(Adopted_Dalish, MapTag, GEN_FL_Merrilyla, R_Merrilyla);
   }

}