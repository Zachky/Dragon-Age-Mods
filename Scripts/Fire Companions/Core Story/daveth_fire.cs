/*
     Remove Daveth from party

     usage:

        runscript daveth_fire

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
#include "plt_gen00pt_main_story"
void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Daveth);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set plot flag "Recruited" to true for other feature
   WR_SetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_DAVETH_RECRUITED, FALSE);

   DestroyObject(oFollower);

}