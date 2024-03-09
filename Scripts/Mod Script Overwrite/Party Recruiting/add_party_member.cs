#include "utility_h"

void main()
{
    event ev = GetCurrentEvent();
    int nEventType = GetEventType(ev);
    switch(nEventType)
    {
        case EVENT_TYPE_PARTYMEMBER_ADDED:
        {
            /*object oFollower = GetEventObject(ev, 0);
            SetLocalInt(oFollower, CREATURE_REWARD_FLAGS, 0);  //Allows the follower to gain XP
            AddCommand(oFollower, CommandJumpToLocation(GetLocation(GetHero())));   //Ensures follower appears at PC's location.
            SetFollowerState(oFollower, FOLLOWER_STATE_ACTIVE);  //Adds follower to the active party*/
            break;
        }

    }
}