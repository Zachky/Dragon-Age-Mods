/*
     Remove Merrilyla from party

     usage:

        runscript merrilyla_fire

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
   object oWarden   = GetHero();
   object oFollower = GetObjectByTag(GEN_FL_Merrilyla);
   
   if(oFollower != OBJECT_INVALID){

       //Fire Companion
       UT_FireFollower(oFollower, TRUE, TRUE);

       //Set plot flag "Recruited" to true for other feature
       WR_SetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_MERRILYLA_RECRUITED, FALSE);

       DestroyObject(oFollower);  
       
   }else{
       DisplayFloatyMessage(oWarden, Msg_Ado, FLOATY_MESSAGE, 0xff0000, 2.0);
   }        

}