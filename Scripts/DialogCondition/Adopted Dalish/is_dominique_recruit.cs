#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_adopted_dalish"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Dominique);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_ADOPTED_DALISH, GEN_DOMINIQUE_RECRUITED);

    return Result;
}