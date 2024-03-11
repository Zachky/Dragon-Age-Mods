/*
     Remove Dominique from party

     usage:

        runscript dominique_fire

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
#include "plt_gen00pt_adopted_dalish"
void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Dominique);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set plot flag "Recruited" to true for other feature
   WR_SetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_DOMINIQUE_RECRUITED, FALSE);

   DestroyObject(oFollower);

}