/*
     Remove Isaac from party

     usage:

        runscript isaac_fire

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
   object oWarden   = GetHero();
   object oFollower = GetObjectByTag(GEN_FL_Isaac);

   if(oFollower != OBJECT_INVALID){
       //Fire Companion
       UT_FireFollower(oFollower, TRUE, TRUE);

       //Set plot flag "Recruited" to true for other feature
       WR_SetPlotFlag(PLT_DT_ACT1, GEN_ISAAC_RECRUITED, FALSE);

       DestroyObject(oFollower);
   }else{
       DisplayFloatyMessage(oWarden, Msg_DarkTime, FLOATY_MESSAGE, 0xff0000, 2.0);
   }

}