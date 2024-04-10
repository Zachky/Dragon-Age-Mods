#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_party_marric"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Marric);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_HIRED);

    return Result;
}