#include "is_follower_recruit"
#include "global_objects_2"

#include "plt_gen00pt_main_story"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Merrill);

    Result = IsFollowerFired(oCreature, PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_RECRUITED);

    return Result;
}