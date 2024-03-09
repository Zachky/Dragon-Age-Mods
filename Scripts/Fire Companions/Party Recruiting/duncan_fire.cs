/*
     Remove Duncan from party

     usage:

        runscript duncan_fire

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
   object oFollower = GetObjectByTag(GEN_FL_Duncan);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set plot flag "Recruited" to true for other feature
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_DUNCAN_RECRUITED, FALSE);

   DestroyObject(oFollower);

}