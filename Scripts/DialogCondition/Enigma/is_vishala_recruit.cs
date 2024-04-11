#include "is_follower_recruit"
#include "global_objects_2"

#include "PLT_ENIGMA_PLOT1"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Vishala);

    Result = IsFollowerFired(oCreature, PLT_ENIGMA_PLOT1, GEN_VISHALA_RECRUITED);

    return Result;
}