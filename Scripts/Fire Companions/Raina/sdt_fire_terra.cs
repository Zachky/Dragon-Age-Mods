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
#include "wrappers_h"
#include "events_h"
#include "global_objects_2"

//Import plot module
#include "plt_sdt_terra"

void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Terra);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Adjust flag stats
   WR_SetPlotFlag(PLT_SDT_TERRA, SDT_TERRA_HIRED, FALSE);
   WR_SetPlotFlag(PLT_SDT_TERRA, SDT_TERRA_FIRED, TRUE);

   DestroyObject(oFollower);

}