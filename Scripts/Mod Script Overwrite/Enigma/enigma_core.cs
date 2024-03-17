//---------------------------------------------------------------------
/*
     Note:

        This file overwrite the original file "enigma_core.nss".

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------
#include "utility_h" 
#include "p_utility"

#include "plt_enigma_plot1"

void main()
{
    event ev = GetCurrentEvent();
    int nEventType = GetEventType(ev);

    switch(nEventType)
    {
        case EVENT_TYPE_MODULE_LOAD:
        {
            if (WR_GetPlotFlag(PLT_ENIGMA_PLOT1, ENIGMA_DUNGEON_UNLOCKED) == FALSE)
            {
                WR_SetPlotFlag(PLT_ENIGMA_PLOT1, ENIGMA_DUNGEON_UNLOCKED, TRUE);
            }
            break;
        }  
        
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