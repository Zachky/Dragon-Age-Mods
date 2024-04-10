#include "is_follower_recruit"
#include "global_objects_2"

#include "PLT_ENIGMA_PLOT1"

int StartingConditional()
{
    int Result = FALSE;
    object oCreature = GetObjectByTag(GEN_FL_Vekuul);

    Result = IsFollowerFired(oCreature, PLT_ENIGMA_PLOT1, GEN_VEKUUL_RECRUITED);

    return Result;
}