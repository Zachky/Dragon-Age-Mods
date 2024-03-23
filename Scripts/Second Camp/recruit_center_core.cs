//==============================================================================
/*

    Recruit Center Script

*/
//------------------------------------------------------------------------------
// Created By: Zach Lin
// Created On: March 21, 2024
//==============================================================================

#include "sys_ambient_h"
#include "cir_constants_h"
#include "utility_h"
#include "core_h"

#include "global_objects_2"
#include "companion_position"


void main()
{
    event   evEvent         = GetCurrentEvent();            // Event
    int     nEventType      = GetEventType(evEvent);        // Event Type
    //object  oEventCreator   = GetEventCreator(evEvent);     // Event Creator

    // Standard Stuff
    object  oPC             = GetHero();
    object  oParty          = GetParty( oPC );
    /*object  oThis           = OBJECT_SELF;
    int     bEventHandled   = FALSE;

    object oTarg, oFollower;*/

    //--------------------------------------------------------------------------
    // Area Events
    //--------------------------------------------------------------------------

    switch ( nEventType )
    {

        //------------------------------------------------------------------
        // Sent by: The engine
        // When: for things you want to happen while the load screen is
        // still up, things like moving creatures around.
        //------------------------------------------------------------------
        case EVENT_TYPE_AREALOAD_PRELOADEXIT:
        {

            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Ilyana);
            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Senros);
            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Dominique);
            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Merrilyla);

            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Daveth);
            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Jory);

            //Place player at camp entrance
            UT_LocalJump(oPC,"cir350wp_fade_weiss_entrance");

            break;

        }

        ////////////////////////////////////////////////////////////////////////
        // Sent by: The engine
        // When: fires at the same time that the load screen is going away,
        // but only when loading a savegame.
        ////////////////////////////////////////////////////////////////////////
        case EVENT_TYPE_AREALOADSAVE_POSTLOADEXIT:
        {
            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Ilyana);
            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Senros);
            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Dominique);
            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Merrilyla);

            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Daveth);
            SpawnCompanion(CORE_RecruitCenter, GEN_FL_Jory);

            break;
        }




        case EVENT_TYPE_EXIT:
        {

            break;

        }

        case EVENT_TYPE_TEAM_DESTROYED:
        {

            break;
        }


    }

    //--------------------------------------------------------------------------
    // Pass any unhandled events to area_core
    //--------------------------------------------------------------------------


    HandleEvent( evEvent, CIR_RESOURCE_SCRIPT_AR_CORE );

}