#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_sdt_mod_raina"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Raina);

    Result = IsFollowerFired(oCreature, PLT_SDT_MOD_RAINA, GEN_RAINA_RECRUITED);

    return Result;
}