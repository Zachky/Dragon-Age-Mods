#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_return_to_kw"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Kenneth);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_RECRUITED);

    return Result;
}