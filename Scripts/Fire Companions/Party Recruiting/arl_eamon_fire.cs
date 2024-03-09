/*
     Remove Arl Eamon from party

     usage:

        runscript arl_eamon_fire

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
#include "plt_gen00pt_party_recruit"

void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Arl_Eamon);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set plot flag "Recruited" to true for other feature
   WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ARL_EAMON_RECRUITED, FALSE);

   DestroyObject(oFollower);

}