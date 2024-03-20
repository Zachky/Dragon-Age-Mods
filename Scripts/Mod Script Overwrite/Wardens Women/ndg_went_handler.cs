//---------------------------------------------------------------------
/*
     Note:

       This file overwrite origin "ndq_event_handler" with 
       party member add and drop event.

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------
#include "utility_h"
#include "placeable_h" 
#include "p_utility"

#include "plt_ndq_secondary" 

void main()
{
    event ev   = GetCurrentEvent();
    int nEvent = GetEventType(ev);

    switch (nEvent)
    {        
        //------------------------------------------------------------------
        // EVENT_TYPE_CAMPAIGN_ITEM_ACQUIRED
        //------------------------------------------------------------------
        // Sent by: Scripting
        // When:    Item is added to inventory that has
        //          ITEM_SEND_ACQUIRED_EVENT set to TRUE
        //------------------------------------------------------------------
        case EVENT_TYPE_CAMPAIGN_ITEM_ACQUIRED:
        {
            object oItem = GetEventObject(ev, 0);
            string sItemTag = GetTag(oItem);
            object oAcquirer = GetEventCreator(ev);

            if (WR_GetPlotFlag(PLT_NDQ_SECONDARY, NDQ_ITEMS_RECEIVED) == FALSE){

                if ((GetTag(oItem) == "bp_abdruil_bow") || (GetTag(oItem) == "bp_fen_harel_axe")
                    || (GetTag(oItem) == "erevan_mischief") || (GetTag(oItem) == "hanali_romance")
                    || (GetTag(oItem) == "labelas_longevity")|| (GetTag(oItem) == "tarsellis_wilderness"))
                {

                    WR_SetPlotFlag(PLT_NDQ_SECONDARY, NDQ_ITEMS_RECEIVED, TRUE);
                    
                    RewardXPParty(5000, 5, OBJECT_SELF, OBJECT_SELF);
                    
                    object oHostile_4_00 = GetObjectByTag( "ndq_hostile_4_00" );
                    object oHostile_4_01 = GetObjectByTag( "ndq_hostile_4_01" );
                    object oHostile_4_02 = GetObjectByTag( "ndq_hostile_4_02" );
                    object oHostile_4_03 = GetObjectByTag( "ndq_hostile_4_03" );
                    object oHostile_4_04 = GetObjectByTag( "ndq_hostile_4_04" );
                    object oHostile_4_05 = GetObjectByTag( "ndq_hostile_4_05" );
                    object oHostile_4_06 = GetObjectByTag( "ndq_hostile_4_06" );
                    object oHostile_4_07 = GetObjectByTag( "ndq_hostile_4_07" );
                    object oHostile_4_08 = GetObjectByTag( "ndq_hostile_4_08" );
                    object oHostile_4_09 = GetObjectByTag( "ndq_hostile_4_09" );
                    SetObjectActive(oHostile_4_00, TRUE);
                    SetObjectActive(oHostile_4_01, TRUE);
                    SetObjectActive(oHostile_4_02, TRUE);
                    SetObjectActive(oHostile_4_03, TRUE);
                    SetObjectActive(oHostile_4_04, TRUE);
                    SetObjectActive(oHostile_4_05, TRUE);
                    SetObjectActive(oHostile_4_06, TRUE);
                    SetObjectActive(oHostile_4_07, TRUE);
                    SetObjectActive(oHostile_4_08, TRUE);
                    SetObjectActive(oHostile_4_09, TRUE);
                    object oHostile410 = GetObjectByTag( "ndq_hostile_4_10" );
                    object oHostile411 = GetObjectByTag( "ndq_hostile_4_11" );
                    object oHostile412 = GetObjectByTag( "ndq_hostile_4_12" );
                    object oHostile413 = GetObjectByTag( "ndq_hostile_4_13" );
                    object oHostile414 = GetObjectByTag( "ndq_hostile_4_14" );
                    object oHostile415 = GetObjectByTag( "ndq_hostile_4_15" );
                    object oHostile416 = GetObjectByTag( "ndq_hostile_4_16" );
                    object oHostile417 = GetObjectByTag( "ndq_hostile_4_17" );
                    object oHostile418 = GetObjectByTag( "ndq_hostile_4_18" );
                    object oHostile419 = GetObjectByTag( "ndq_hostile_4_19" );
                    SetObjectActive(oHostile410, TRUE);
                    SetObjectActive(oHostile411, TRUE);
                    SetObjectActive(oHostile412, TRUE);
                    SetObjectActive(oHostile413, TRUE);
                    SetObjectActive(oHostile414, TRUE);
                    SetObjectActive(oHostile415, TRUE);
                    SetObjectActive(oHostile416, TRUE);
                    SetObjectActive(oHostile417, TRUE);
                    SetObjectActive(oHostile418, TRUE);
                    SetObjectActive(oHostile419, TRUE);

                }
            }
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
