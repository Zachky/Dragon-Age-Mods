//---------------------------------------------------------------------
/*
     Start the story "In search of raina".
     Note:
        Since it's impossible to override original core script file, nor make any
     change to plot file, it is necessary to modify plot flag value here before
     warden teleport to story area.

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"

#include "plt_sdt_mod_raina"

void main()
{
    //Set Recruit & Is_Not_Virgin flag to true.
    WR_SetPlotFlag(PLT_SDT_MOD_RAINA, GEN_TERRA_RECRUITED, TRUE);
    WR_SetPlotFlag(PLT_SDT_MOD_RAINA, GEN_TERRA_IS_NOT_VIRGIN, TRUE);
    WR_SetPlotFlag(PLT_SDT_MOD_RAINA, GEN_RAINA_IS_NOT_VIRGIN, TRUE);


    UT_DoAreaTransition("sda_amazons", "start");
}