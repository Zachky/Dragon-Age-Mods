//---------------------------------------------------------------------
/*
     Note:

        This file override old sdt_terra_spawn_camp file.

*/
//---------------------------------------------------------------------
// Zach Lin
//--------------------------------------------------------------------- 

#include "utility_h"  
#include "global_objects_2"
#include "plt_sdt_terra"

void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Terra);
   
   //Prepare spawn command.
   vector vTent = Vector(137.564f, 115.815f, -1.08586f);
   location lTent = Location(GetArea(GetHero()), vTent,  180.0f);
   command cMoveFollower = CommandJumpToLocation(lTent);
   
   //Active follower and set state.
   WR_SetObjectActive(oFollower, TRUE);
   SetFollowerState(oFollower,FOLLOWER_STATE_AVAILABLE); 
   
   //Execute command
   AddCommand(oFollower, cMoveFollower);
   
   //Adjust flag value
   WR_SetPlotFlag(PLT_SDT_TERRA, SDT_TERRA_IN_PARTY, FALSE, FALSE);
   WR_SetPlotFlag(PLT_SDT_TERRA, SDT_TERRA_IN_CAMP, TRUE, FALSE);

}

