#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_party_lealion"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Lealion);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED);

    return Result;
}