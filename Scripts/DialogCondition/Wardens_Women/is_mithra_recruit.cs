#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_ndq_mithra"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Mithra);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_NDQ_MITHRA, GEN_MITHRA_RECRUITED);

    return Result;
}