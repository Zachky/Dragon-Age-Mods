#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_party_willam"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Willam);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_PARTY_WILLAM, GEN_WILLAM_HIRED);

    return Result;
}