/*
     Remove Lealion from party

     usage:

        runscript lealion_fire

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
#include "plt_gen00pt_party_lealion"

void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Lealion);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   /*-------------------------------------------------------------------------
      Set plot flag "Recruited" to true for other feature.
      Original Plot file has created, hired and fired flag. To ensure other
      feature goes as it should be, set these flags with appropriate value.
    ---------------------------------------------------------------------------*/
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_CREATED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_FIRED, TRUE);

   DestroyObject(oFollower);

}