#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_sdt_mod_raina"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Terra);

    Result = IsFollowerFired(oCreature, PLT_SDT_MOD_RAINA, GEN_TERRA_RECRUITED);

    return Result;
}