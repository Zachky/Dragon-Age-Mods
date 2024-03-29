//---------------------------------------------------------------------
/*
     Note:

        This file overwrite the original file "add_party_members.nss".

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------
#include "utility_h"
#include "p_utility"

void main()
{
    event ev = GetCurrentEvent();
    int nEventType = GetEventType(ev);

    switch(nEventType)
    {

        //--------------------------------------------------------------------------
        // Sent by: The engine
        // When: Fires when player add companion to the party.
        //------------------------------------------------------------------
        case EVENT_TYPE_PARTYMEMBER_ADDED:
        {
            object oFollower = GetEventObject(ev, 0);

            Event_PartyMemberAddProcess(oFollower);

            break;
        }

        //--------------------------------------------------------------------------
        // Sent by: The engine
        // When: Fires when player remove companion from the party.
        //------------------------------------------------------------------
        case EVENT_TYPE_PARTYMEMBER_DROPPED:
        {

            object oFollower = GetEventObject(ev, 0);

            Event_PartyMemberDropProcess(oFollower);

            break;
        }

    }
}