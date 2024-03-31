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

//---------Plot for each mod----------
#include "plt_gen00pt_main_story"
#include "plt_gen00pt_adopted_dalish"
#include "plt_gen00pt_party_recruit"
#include "plt_dt_act1"
#include "plt_gen00pt_party_lanna"
#include "plt_gen00pt_party_marric"
#include "plt_gen00pt_party_martin"
#include "plt_gen00pt_party_willam"
#include "plt_gen00pt_party_lealion"
#include "plt_enigma_plot1"
#include "plt_gen00pt_ndq_mithra"
#include "plt_sdt_terra"
#include "plt_gen00pt_return_to_kw"
#include "plt_pt_douglas"



void main()
{
    event   evEvent         = GetCurrentEvent();            // Event
    int     nEventType      = GetEventType(evEvent);        // Event Type
    //object  oEventCreator   = GetEventCreator(evEvent);     // Event Creator

    // Standard Stuff
    object  oPC             = GetHero();
    object  oParty          = GetParty( oPC );
    object  oThis           = GetMainControlled();
    /*int     bEventHandled   = FALSE;

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
            //Adopted Dalish
            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Anaise, Agent_Anaise,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_ANAISE_RECRUITED, R_Anaise);

            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Dominique, Agent_Dominique,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_DOMINIQUE_RECRUITED, R_Dominique);

            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Ilyana, Agent_Ilyana,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_ILYANA_RECRUITED, R_Ilyana);

            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Senros, Agent_Senros,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_SENROS_RECRUITED, R_Senros);

            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Merrilyla, Agent_Merrilyla,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_MERRILYLA_RECRUITED, R_Merrilyla);


            //Small Restoration
            SpawnCompanion(Small_Restoration, CORE_RecruitCenter, GEN_FL_Moira, Agent_Moira,
                           PLT_GEN00PT_MAIN_STORY, GEN_MOIRA_RECRUITED, R_Moira);


            //Main Story
            SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Daveth, Agent_Daveth,
                           PLT_GEN00PT_MAIN_STORY, GEN_DAVETH_RECRUITED, R_Daveth);

            SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Jory, Agent_Jory,
                           PLT_GEN00PT_MAIN_STORY, GEN_JORY_RECRUITED, R_Jory);

            SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Fenarel, Agent_Fenarel,
                           PLT_GEN00PT_MAIN_STORY, GEN_FENAREL_RECRUITED, R_Fenarel);

            SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Merrill, Agent_Merrill,
                           PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_RECRUITED, R_Merrill);

            //Dark Time Act 1
            SpawnCompanion(Dark_Time, CORE_RecruitCenter, GEN_FL_Isaac, Agent_Isaac,
                           PLT_DT_ACT1, GEN_ISAAC_RECRUITED, R_Isaac);

            SpawnCompanion(Dark_Time, CORE_RecruitCenter, GEN_FL_Miriam, Agent_Miriam,
                           PLT_DT_ACT1, GEN_MIRIAM_RECRUITED, R_Miriam);

            //Place player at camp entrance
            UT_LocalJump(oThis,"cir350wp_fade_weiss_entrance");

            break;

        }

        ////////////////////////////////////////////////////////////////////////
        // Sent by: The engine
        // When: fires at the same time that the load screen is going away,
        // but only when loading a savegame.
        ////////////////////////////////////////////////////////////////////////
        case EVENT_TYPE_AREALOADSAVE_POSTLOADEXIT:
        {
            //Adopted Dalish
            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Anaise, Agent_Anaise,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_ANAISE_RECRUITED, R_Anaise);

            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Dominique, Agent_Dominique,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_DOMINIQUE_RECRUITED, R_Dominique);

            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Ilyana, Agent_Ilyana,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_ILYANA_RECRUITED, R_Ilyana);

            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Senros, Agent_Senros,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_SENROS_RECRUITED, R_Senros);

            SpawnCompanion(Adopted_Dalish, CORE_RecruitCenter, GEN_FL_Merrilyla, Agent_Merrilyla,
                           PLT_GEN00PT_ADOPTED_DALISH, GEN_MERRILYLA_RECRUITED, R_Merrilyla);

            //Small Restoration
            SpawnCompanion(Small_Restoration, CORE_RecruitCenter, GEN_FL_Moira, Agent_Moira,
                           PLT_GEN00PT_MAIN_STORY, GEN_MOIRA_RECRUITED, R_Moira);

            //Main Story
            SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Daveth, Agent_Daveth,
                           PLT_GEN00PT_MAIN_STORY, GEN_DAVETH_RECRUITED, R_Daveth);

            SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Jory, Agent_Jory,
                           PLT_GEN00PT_MAIN_STORY, GEN_JORY_RECRUITED, R_Jory);

            SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Fenarel, Agent_Fenarel,
                           PLT_GEN00PT_MAIN_STORY, GEN_FENAREL_RECRUITED, R_Fenarel);

            SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Merrill, Agent_Merrill,
                           PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_RECRUITED, R_Merrill);

            //Dark Time Act 1
            SpawnCompanion(Dark_Time, CORE_RecruitCenter, GEN_FL_Isaac, Agent_Isaac,
                           PLT_DT_ACT1, GEN_ISAAC_RECRUITED, R_Isaac);

            SpawnCompanion(Dark_Time, CORE_RecruitCenter, GEN_FL_Miriam, Agent_Miriam,
                           PLT_DT_ACT1, GEN_MIRIAM_RECRUITED, R_Miriam);

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