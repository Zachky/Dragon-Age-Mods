/*
     Remove Douglas from party

     usage:

        runscript douglas_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"

//Import plot module
#include "plt_pt_douglas"
void main()
{
   object oWarden   = GetHero();
   object oFollower = GetObjectByTag(GEN_FL_Douglas);
   
   if(oFollower != OBJECT_INVALID){
       //Fire Companion
       UT_FireFollower(oFollower, TRUE, TRUE);

       //Set plot flag "Recruited" to false.
       WR_SetPlotFlag(PLT_PT_DOUGLAS, PARTY_DOUGLAS_JOINED, FALSE, TRUE);

       DestroyObject(oFollower); 
              
   }else{
       DisplayFloatyMessage(oWarden, Msg_RTKW, FLOATY_MESSAGE, 0xff0000, 2.0);
   } 

}