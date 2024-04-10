#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_return_to_kw"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Ariane);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_RECRUITED);

    return Result;
}