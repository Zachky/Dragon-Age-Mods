/*
     Remove Serenity from party

     usage:

        runscript serenity_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"
#include "companion_position"

//Import plot module
#include "plt_gen00pt_orand_serenity"

void main()
{

   object oFollower = GetObjectByTag(GEN_FL_Serenity);

   //Get current area tag
   string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Adjust flag stats
   WR_SetPlotFlag(PLT_GEN00PT_ORAND_SERENITY, GEN_SERENITY_RECRUITED, FALSE);

   DestroyObject(oFollower);

   //Respawn the npc if warden sit on the map where npc show up in the first place.
   if(MapTag == CORE_RecruitCenter){
      SpawnCompanion_location(Lady_Orand, MapTag, GEN_FL_Serenity, R_Serenity );
   }

}