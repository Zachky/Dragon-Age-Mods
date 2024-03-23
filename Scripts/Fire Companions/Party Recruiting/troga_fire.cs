/*
     Remove Troga from party

     usage:

        runscript troga_fire

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
   object oWarden   = GetHero();
   object oFollower = GetObjectByTag(GEN_FL_Troga);
   
   if(oFollower != OBJECT_INVALID){   
       //Fire Companion
       UT_FireFollower(oFollower, TRUE, TRUE);

       //Set plot flag "Recruited" to true for other feature
        WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_TROGA_RECRUITED, FALSE);

       DestroyObject(oFollower);  
        
   }else{
       DisplayFloatyMessage(oWarden, Msg_PRecruit, FLOATY_MESSAGE, 0xff0000, 2.0);
   }

}