#include "is_follower_recruit"
#include "global_objects_2"

#include "PLT_ENIGMA_PLOT1"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_helperlady);

    Result = IsFollowerFired(oCreature, PLT_ENIGMA_PLOT1, GEN_HELPERLADY_RECRUITED);

    return Result;
}