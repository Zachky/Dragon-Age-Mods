/*
     Remove Kenneth from party

     usage:

        runscript kenneth_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"

//Import plot module
#include "plt_gen00pt_return_to_kw"
void main()
{
   object oWarden   = GetHero();
   object oFollower = GetObjectByTag(GEN_FL_Kenneth);
   
   if(oFollower != OBJECT_INVALID){
       //Fire Companion
       UT_FireFollower(oFollower, TRUE, TRUE);

       //Set plot flag "Recruited" to false.
       WR_SetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_RECRUITED, FALSE, TRUE);

       DestroyObject(oFollower);
                 
   }else{
       DisplayFloatyMessage(oWarden, Msg_RTKW, FLOATY_MESSAGE, 0xff0000, 2.0);
   } 

}