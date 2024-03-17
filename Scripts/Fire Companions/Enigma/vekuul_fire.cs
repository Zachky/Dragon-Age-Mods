/*
     Remove Vekuul from party

     usage:

        runscript vekuul_fire

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
   object oFollower = GetObjectByTag(GEN_FL_Vekuul);

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   //Set recruited flag to false so companion can respawn at specific location
   WR_SetPlotFlag(PLT_ENIGMA_PLOT1, GEN_VEKUUL_RECRUITED, FALSE);

   DestroyObject(oFollower);

}