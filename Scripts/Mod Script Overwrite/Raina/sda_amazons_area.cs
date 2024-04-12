// Amazon challenge area
//

#include "utility_h"
#include "wrappers_h"
#include "events_h"
#include "party_h"

#include "plt_gen00pt_party"
#include "plt_sda_amazons"


void main()
{
    event   ev          = GetCurrentEvent();
    int     nEventType  = GetEventType(ev);
    int     nEventHandled = FALSE;
    string  sDebug;

    object oPlayer      = GetEventCreator(ev);
    object oPC          = GetHero();
    object oParty       = GetParty(oPlayer);
    object oAmazon      = GetObjectByTag("amazon_01");


    switch(nEventType)
    {
        ////////////////////////////////////////////////////////////////////////
        // Sent by: The engine
        // When: for things you want to happen while the load screen is still up,
        // things like moving creatures around
        ////////////////////////////////////////////////////////////////////////
        case EVENT_TYPE_AREALOAD_PRELOADEXIT:
        {


            break;
        }

        ////////////////////////////////////////////////////////////////////////
        // Sent by: The engine
        // When: fires at the same time that the load screen is going away,
        // and can be used for things that you want to make sure the player sees.
        ////////////////////////////////////////////////////////////////////////
        case EVENT_TYPE_AREALOAD_POSTLOADEXIT:
        {
            // Encounter is for player only, so lose the rest of the party

            object oFollower;

            // Strip away all companions
            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_ALISTAIR_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_ALISTAIR_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_ALISTAIR);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_DOG_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_DOG_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_DOG);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_LELIANA_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_LELIANA_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_LELIANA);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_LOGHAIN_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_LOGHAIN_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_LOGHAIN);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_MORRIGAN_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_MORRIGAN_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_MORRIGAN);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_OGHREN_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_OGHREN_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_OGHREN);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_SHALE_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_SHALE_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_SHALE);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_STEN_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_STEN_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_STEN);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_WYNNE_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_WYNNE_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_WYNNE);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            if (WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_ZEVRAN_IN_PARTY))
            {
                //WR_SetPlotFlag( PLT_GEN00PT_PARTY, GEN_ZEVRAN_IN_CAMP, TRUE, TRUE);
                oFollower = Party_GetActiveFollowerByTag(GEN_FL_ZEVRAN);
                WR_SetFollowerState(oFollower,FOLLOWER_STATE_UNAVAILABLE);
                WR_SetObjectActive(oFollower, FALSE);
            }

            UT_Talk(oAmazon, oPlayer);

            // End of: case EVENT_TYPE_AREALOAD_POSTLOADEXIT:
            break;
        }
        case EVENT_TYPE_ENTER:
        {
            object oCreature = GetEventCreator(ev);

            break;
        }

        case EVENT_TYPE_TEAM_DESTROYED:
        {
            int nTeamID = GetEventInteger( ev, 0 );


            // Spider dead - Amazon challenge succeeded
            if (nTeamID == 6)
            {
                WR_SetPlotFlag( PLT_SDA_AMAZONS, SDA_SPIDER_FOUGHT, TRUE, TRUE);
                UT_Talk(oAmazon, oPlayer);
            }

            break;
        }
        ////////////////////////////////////////////////////////////////////////
        // Sent by: The engine
        // When: A creature exits the area
        ////////////////////////////////////////////////////////////////////////
        case EVENT_TYPE_EXIT:
        {
            object oCreature = GetEventCreator(ev);
            UT_DoAreaTransition("pre210ar_flemeths_hut_ext", "pre210wp_outside");

            break;
        }
    }
    HandleEvent(ev, RESOURCE_SCRIPT_AREA_CORE);
}