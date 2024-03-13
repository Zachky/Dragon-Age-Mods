/*
     Remove Mirian from party

     usage:

        runscript mirian_fire

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
#include "plt_dt_act1"
void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Miriam);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set plot flag "Recruited" to true for other feature
   WR_SetPlotFlag(PLT_DT_ACT1, GEN_MIRIAM_RECRUITED, FALSE);

   DestroyObject(oFollower);

}