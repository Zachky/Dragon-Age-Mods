/*
     Remove Vishala from party

     usage:

        runscript vishala_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"

//Import plot module
#include "plt_enigma_plot1"

void main()
{
   object oWarden   = GetHero();
   object oFollower = GetObjectByTag(GEN_FL_Vishala);
   
   if(oFollower != OBJECT_INVALID){
       //Fire Companion
       UT_FireFollower(oFollower, TRUE, TRUE);

       //Set recruited flag to false so companion can respawn at specific location
       WR_SetPlotFlag(PLT_ENIGMA_PLOT1, GEN_VISHALA_RECRUITED, FALSE);

       DestroyObject(oFollower); 
        
   }else{
       DisplayFloatyMessage(oWarden, Msg_Enigma, FLOATY_MESSAGE, 0xff0000, 2.0);
   } 

}