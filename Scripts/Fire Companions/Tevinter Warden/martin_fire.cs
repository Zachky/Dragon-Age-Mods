/*
     Remove Martin from party

     usage:

        runscript martin_fire

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
#include "plt_gen00pt_party_martin"

void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Martin);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   /*-------------------------------------------------------------------------
      Set plot flag "Recruited" to true for other feature.
      Original Plot file has created, hired and fired flag. To ensure other
      feature goes as it should be, set these flags with appropriate value.
    ---------------------------------------------------------------------------*/
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_CREATED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_HIRED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_FIRED, TRUE);

   DestroyObject(oFollower);

}