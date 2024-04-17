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
#include "p_utility"

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
#include "plt_gen00pt_ndq_elora"
#include "plt_ndq_main"
#include "plt_sdt_mod_raina"
#include "plt_gen00pt_return_to_kw"
#include "plt_pt_douglas"
#include "plt_gen00pt_orand_serenity"


void CheckVirginStats(string strTag, string strPlot, int nFlag){

    if( !WR_GetPlotFlag(strPlot, nFlag) && IsFollowerInPartyPool(strTag)){
         WR_SetPlotFlag(strPlot, nFlag, TRUE);
    }
}


/*******************************************************************************
DYING inside!
********************************************************************************/
void PlaceFollowers(){

/*******************************************************************************
                                Adopted Dalish
********************************************************************************/

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

/*******************************************************************************
                              Small Restoration
********************************************************************************/
     SpawnCompanion(Small_Restoration, CORE_RecruitCenter, GEN_FL_Moira, Agent_Moira,
                    PLT_GEN00PT_MAIN_STORY, GEN_MOIRA_RECRUITED, R_Moira);

/*******************************************************************************
                                  Main Story
********************************************************************************/

     SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Daveth, Agent_Daveth,
                    PLT_GEN00PT_MAIN_STORY, GEN_DAVETH_RECRUITED, R_Daveth);

     SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Jory, Agent_Jory,
                    PLT_GEN00PT_MAIN_STORY, GEN_JORY_RECRUITED, R_Jory);

     SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Fenarel, Agent_Fenarel,
                    PLT_GEN00PT_MAIN_STORY, GEN_FENAREL_RECRUITED, R_Fenarel);

     SpawnCompanion(Main_Story, CORE_RecruitCenter, GEN_FL_Merrill, Agent_Merrill,
                    PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_RECRUITED, R_Merrill);

/*******************************************************************************
                               Dark Time Act 1
********************************************************************************/
     SpawnCompanion(Dark_Time, CORE_RecruitCenter, GEN_FL_Isaac, Agent_Isaac,
                    PLT_DT_ACT1, GEN_ISAAC_RECRUITED, R_Isaac);

     SpawnCompanion(Dark_Time, CORE_RecruitCenter, GEN_FL_Miriam, Agent_Miriam,
                    PLT_DT_ACT1, GEN_MIRIAM_RECRUITED, R_Miriam);

/*******************************************************************************
                             Return to Korcari Wilds
********************************************************************************/

     CheckVirginStats(GEN_FL_Douglas, PLT_PT_DOUGLAS, PARTY_DOUGLAS_IS_NOT_VIRGIN);
     CheckVirginStats(GEN_FL_Kenneth, PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_IS_NOT_VIRGIN);
     CheckVirginStats(GEN_FL_Ariane , PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_IS_NOT_VIRGIN);


     //Douglas
     if(WR_GetPlotFlag(PLT_PT_DOUGLAS, PARTY_DOUGLAS_IS_NOT_VIRGIN) == TRUE){
            SpawnCompanion(Return_to_KW, CORE_RecruitCenter, GEN_FL_Douglas, Agent_Douglas,
                           PLT_PT_DOUGLAS, PARTY_DOUGLAS_JOINED, R_Douglas);
     }

     //Ser Kenneth
     if(WR_GetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_IS_NOT_VIRGIN) == TRUE){
            SpawnCompanion(Return_to_KW, CORE_RecruitCenter, GEN_FL_Kenneth, Agent_Kenneth,
                           PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_RECRUITED, R_Serkenneth);
     }

     //Ariane
     if(WR_GetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_IS_NOT_VIRGIN) == TRUE){
            SpawnCompanion(Return_to_KW, CORE_RecruitCenter, GEN_FL_Ariane, Agent_Ariane,
                           PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_RECRUITED, R_Ariane);
     }

/*******************************************************************************
                                Tevinter Warden
********************************************************************************/

     CheckVirginStats(GEN_FL_Lanna , PLT_GEN00PT_PARTY_LANNA , GEN_LANNA_IS_NOT_VIRGIN);
     CheckVirginStats(GEN_FL_Marric, PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_IS_NOT_VIRGIN);
     CheckVirginStats(GEN_FL_Martin, PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_IS_NOT_VIRGIN);
     CheckVirginStats(GEN_FL_Willam, PLT_GEN00PT_PARTY_WILLAM, GEN_WILLAM_IS_NOT_VIRGIN);


     //Lanna
     if( WR_GetPlotFlag(PLT_GEN00PT_PARTY_LANNA, GEN_LANNA_IS_NOT_VIRGIN) == TRUE){
         SpawnCompanion(Tevinter_Warden, CORE_RecruitCenter, GEN_FL_Lanna, Agent_Lanna,
                        PLT_GEN00PT_PARTY_LANNA, GEN_LANNA_HIRED, R_Lanna);
     }

     //Marric
     if( WR_GetPlotFlag(PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_IS_NOT_VIRGIN) == TRUE){
         SpawnCompanion(Tevinter_Warden, CORE_RecruitCenter, GEN_FL_Marric, Agent_Marric,
                        PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_HIRED, R_Marric);
     }

     //Martin
     if( WR_GetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_IS_NOT_VIRGIN) == TRUE){
         SpawnCompanion(Tevinter_Warden, CORE_RecruitCenter, GEN_FL_Martin, Agent_Martin,
                        PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_HIRED, R_Martin);
     }

      //Willam
     if( WR_GetPlotFlag(PLT_GEN00PT_PARTY_WILLAM, GEN_WILLAM_IS_NOT_VIRGIN) == TRUE){
         SpawnCompanion(Tevinter_Warden, CORE_RecruitCenter, GEN_FL_Willam, Agent_Willam,
                        PLT_GEN00PT_PARTY_WILLAM, GEN_WILLAM_HIRED, R_Willam);
     }

/*******************************************************************************
                                Enigma Dungeon
********************************************************************************/

     CheckVirginStats(GEN_FL_Vekuul    , PLT_ENIGMA_PLOT1, GEN_VEKUUL_IS_NOT_VIRGIN);
     CheckVirginStats(GEN_FL_Vishala   , PLT_ENIGMA_PLOT1, GEN_VISHALA_IS_NOT_VIRGIN);
     CheckVirginStats(GEN_FL_helperlady, PLT_ENIGMA_PLOT1, GEN_HEKPERLADY_IS_NOT_VIRGIN);

     //Vekuul
     if( WR_GetPlotFlag(PLT_ENIGMA_PLOT1, GEN_VEKUUL_IS_NOT_VIRGIN) == TRUE){
         SpawnCompanion(Enigma, CORE_RecruitCenter, GEN_FL_Vekuul, Agent_Vekuul,
                        PLT_ENIGMA_PLOT1, GEN_VEKUUL_RECRUITED, R_Vekuul);
     }

     //Vishala
     if( WR_GetPlotFlag(PLT_ENIGMA_PLOT1, GEN_VISHALA_IS_NOT_VIRGIN) == TRUE){
         SpawnCompanion(Enigma, CORE_RecruitCenter, GEN_FL_Vishala, Agent_Vishala,
                        PLT_ENIGMA_PLOT1, GEN_VISHALA_RECRUITED, R_Vishala);
     }

     //Helper Lady
     if( WR_GetPlotFlag(PLT_ENIGMA_PLOT1, GEN_HEKPERLADY_IS_NOT_VIRGIN) == TRUE){
         SpawnCompanion(Enigma, CORE_RecruitCenter, GEN_FL_helperlady, Agent_helperlady,
                        PLT_ENIGMA_PLOT1, GEN_HELPERLADY_RECRUITED, R_helperlady);
     }

/*******************************************************************************
                              The Warden's Women
********************************************************************************/

     //Mithra
     SpawnCompanion(Warden_Women, CORE_RecruitCenter, GEN_FL_Mithra, Agent_Mithra,
                    PLT_GEN00PT_NDQ_MITHRA, GEN_MITHRA_RECRUITED, R_Mithra);
     //Elora
     SpawnCompanion(Warden_Women, CORE_RecruitCenter, GEN_FL_Elora, Agent_Elora,
                    PLT_GEN00PT_NDQ_ELORA, GEN_ELORA_RECRUITED, R_elora);

/*******************************************************************************
                              In Search of Raina
********************************************************************************/

     //Terra
     if( WR_GetPlotFlag(PLT_SDT_MOD_RAINA, GEN_TERRA_IS_NOT_VIRGIN) == TRUE ){
         SpawnCompanion(Raina, CORE_RecruitCenter, GEN_FL_Terra, Agent_Terra,
                    PLT_SDT_MOD_RAINA, GEN_TERRA_RECRUITED, R_Terra);
     }

     //Raina
     if( WR_GetPlotFlag(PLT_SDT_MOD_RAINA, GEN_RAINA_IS_NOT_VIRGIN) == TRUE ||
         IsFollowerInPartyPool(GEN_FL_Terra)){
         SpawnCompanion(Raina, CORE_RecruitCenter, GEN_FL_Raina, Agent_Raina,
                    PLT_SDT_MOD_RAINA, GEN_RAINA_RECRUITED, R_Raina);
     }

/*******************************************************************************
                              Orand Serenity
********************************************************************************/

    //Elora
     SpawnCompanion(Lady_Orand, CORE_RecruitCenter, GEN_FL_Serenity, Agent_Serenity,
                    PLT_GEN00PT_ORAND_SERENITY, GEN_SERENITY_RECRUITED, R_Serenity);


}

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

            PlaceFollowers();

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

            PlaceFollowers();

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