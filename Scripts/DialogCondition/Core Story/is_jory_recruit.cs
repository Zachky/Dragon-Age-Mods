#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_main_story"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Jory);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_MAIN_STORY, GEN_JORY_RECRUITED);

    return Result;
}