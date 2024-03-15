#include "utility_h"
#include "plt_gen00pt_party_lealion"
void main()
{
//    object oFollower = GetObjectByTag("gen00fl_legion");
//    //Follower's position <--- you should change vector below to your desired position in camp
//    vector vTent = Vector(135.252625f, 113.905f, -0.274021f);
//    location lTent = Location(GetArea(GetHero()), vTent,  180.0f);
//    command cMoveFollower = CommandJumpToLocation(lTent);
//    Camp_PlaceFollowersInCamp();
//    if(GetFollowerState(oFollower) != FOLLOWER_STATE_ACTIVE)
//    {
//        SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE);
//        AddCommand(oFollower, cMoveFollower);
//        WR_SetObjectActive(oFollower, TRUE);
//        WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_PARTY, FALSE, FALSE);
//        WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_CAMP, TRUE, FALSE);
//    }
//    else
//    {
//        SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE);
//        AddCommand(oFollower, cMoveFollower);
//        WR_SetObjectActive(oFollower, TRUE);
//        WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_PARTY, FALSE, FALSE);
//        WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_CAMP, TRUE, FALSE);
//    }

    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_PARTY, FALSE, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_CAMP, TRUE, FALSE)
}