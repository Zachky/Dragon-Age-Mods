#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_orand_serenity"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Serenity);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_ORAND_SERENITY, GEN_SERENITY_RECRUITED);

    return Result;
}