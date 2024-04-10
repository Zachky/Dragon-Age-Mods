/*******************************************************************************
* Note:
*

*******************************************************************************/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"

/*******************************************************************************
Check when Recruited flag is false, follower is in party pool or not.
If this scenario happen, it means this is a fake fired, return false
and set flag to true.

PS:
  1. It happen when player install this party picker mod in the middle of the game.
  2. Return False means the dialog line will not show up.
*******************************************************************************/
int IsFollowerFired(object oFollower, string strPlot, int FlagRecruited){

    int Result = FALSE;

    if( WR_GetPlotFlag(strPlot, FlagRecruited) == FALSE ){

       Result = TRUE;

       if(GetFollowerState(oFollower) == FOLLOWER_STATE_ACTIVE ||
         GetFollowerState(oFollower) == FOLLOWER_STATE_AVAILABLE ){

         WR_SetPlotFlag(strPlot, FlagRecruited, TRUE);
         Result = FALSE;
       }

    }

    return Result;
}