#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_party_martin"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Martin);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_HIRED);

    return Result;
}