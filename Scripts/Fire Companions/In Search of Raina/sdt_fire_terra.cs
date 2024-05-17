/*
     Remove Terra from party

     usage:

        runscript terra_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"
#include "companion_position"

//Import plot module
#include "plt_sdt_mod_raina"

void main()
{

   object oFollower = GetObjectByTag(GEN_FL_Terra);

   //Get current area tag
   string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Adjust flag stats
   WR_SetPlotFlag(PLT_SDT_MOD_RAINA, GEN_TERRA_RECRUITED, FALSE);

   DestroyObject(oFollower);

   //Respawn the npc if warden sit on the map where npc show up in the first place.
   if(MapTag == CORE_RecruitCenter){
      SpawnCompanion_location(Raina, MapTag, GEN_FL_Terra, R_Terra );
   }

}