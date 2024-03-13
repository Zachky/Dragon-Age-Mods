//---------------------------------------------------------------------
/*
     Note:

        This file overwrite the original file "ldp_module_core.nss".

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------
#include "utility_h"
#include "p_utility"

void main()
{
    event ev = GetCurrentEvent();
    int nEvent = GetEventType(ev);

    switch(nEvent)
    {
        //------------------------------------------------------------------
        // Sent by: The engine
        // When: Player open party picker
        //------------------------------------------------------------------
        case EVENT_TYPE_MODULE_GETCHARSTAGE:
        {
                // Overlay the existing stage with my stage
                // "my_char_stage" is the resource name of the overlay area
                // "partypicker" is the name of the default GDA
                SetPartyPickerStage("ldp_char_stage", "partypicker");
                 break;
        }

        //------------------------------------------------------------------
        // Sent by: The engine
        // When: Fires when player add companion to the party.
        //------------------------------------------------------------------
        case EVENT_TYPE_PARTYMEMBER_ADDED:
        {
            object oFollower = GetEventObject(ev, 0);

            Event_PartyMemberAddProcess(oFollower);

            break;
        }

        //------------------------------------------------------------------
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
