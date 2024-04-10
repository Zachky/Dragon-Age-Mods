#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_ndq_elora"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Elora);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_NDQ_ELORA, GEN_ELORA_RECRUITED);

    return Result;
}