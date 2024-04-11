#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_dt_act1"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Miriam);

    Result = IsFollowerFired(oCreature, PLT_DT_ACT1, GEN_MIRIAM_RECRUITED);

    return Result;
}