/*
     Remove Helperlady from party

     usage:

        runscript helperlady_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"
#include "companion_position"

//Import plot module
#include "plt_enigma_plot1"

void main()
{
   object oFollower = GetObjectByTag(GEN_FL_helperlady);

   //Get current area tag
   string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set recruited flag to false so companion can respawn at specific location
   WR_SetPlotFlag(PLT_ENIGMA_PLOT1, GEN_HELPERLADY_RECRUITED, FALSE);

   DestroyObject(oFollower);

   //Respawn the npc if warden sit on the map where npc show up in the first place.
   if(MapTag == CORE_RecruitCenter){
      SpawnCompanion_location(Enigma, MapTag, GEN_FL_helperlady, R_helperlady );
   }


}