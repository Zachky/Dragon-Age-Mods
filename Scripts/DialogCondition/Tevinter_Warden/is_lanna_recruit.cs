#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_party_lanna"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Lanna);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_PARTY_LANNA, GEN_LANNA_HIRED);

    return Result;
}