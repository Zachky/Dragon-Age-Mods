#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_pt_douglas"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Douglas);

    Result = IsFollowerFired(oCreature, PLT_PT_DOUGLAS, PARTY_DOUGLAS_JOINED);

    return Result;
}