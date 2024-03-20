/*
     Remove Mithra from party

     usage:

        runscript mithra_fire

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
#include "plt_gen00pt_ndq_mithra"
void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Mithra);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set plot flag "Recruited" to true for other feature
   WR_SetPlotFlag(PLT_GEN00PT_NDQ_MITHRA, GEN_MITHRA_RECRUITED, FALSE);

   DestroyObject(oFollower);

}