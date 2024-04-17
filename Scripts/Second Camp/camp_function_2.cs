/*******************************************************************************

*******************************************************************************/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "sys_rewards_h"
#include "camp_constants_h"

#include "global_objects_2"
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
#include "plt_sdt_mod_raina"
#include "plt_gen00pt_return_to_kw"
#include "plt_pt_douglas"
#include "plt_gen00pt_orand_serenity"

void Camp2_RemoveFollowerFromCamp();

const string WP_CAMP2_FOLLOWER_PREFIX = "wp_pcamp2_";

object [] ActivateFollowers(){

    object [] Member_List;

/*******************************************************************************
* "Main Stoty"
*******************************************************************************/

    object oDaveth  = Party_GetFollowerByTag(GEN_FL_Daveth);
    object oJory    = Party_GetFollowerByTag(GEN_FL_Jory);
    object oFenarel = Party_GetFollowerByTag(GEN_FL_Fenarel);
    object oMerrill = Party_GetFollowerByTag(GEN_FL_Merrill);

    CheckFollowerFlag(oDaveth, PLT_GEN00PT_MAIN_STORY, GEN_DAVETH_RECRUITED, GEN_DAVETH_IN_CAMP);
    CheckFollowerFlag(oJory, PLT_GEN00PT_MAIN_STORY, GEN_JORY_RECRUITED, GEN_JORY_IN_CAMP);
    CheckFollowerFlag(oFenarel, PLT_GEN00PT_MAIN_STORY, GEN_FENAREL_RECRUITED, GEN_FENAREL_IN_CAMP);
    CheckFollowerFlag(oMerrill, PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_RECRUITED, GEN_MERRILL_IN_CAMP);

    Member_List[0] = oDaveth;
    Member_List[1] = oJory;
    Member_List[2] = oFenarel;
    Member_List[3] = oMerrill;

/*******************************************************************************
* "Small Restoration"
*******************************************************************************/

    object oMoira = Party_GetFollowerByTag(GEN_FL_Moira);

    CheckFollowerFlag(oMoira, PLT_GEN00PT_MAIN_STORY, GEN_MOIRA_RECRUITED, GEN_MOIRA_IN_CAMP);

    Member_List[4] = oMoira;

/*******************************************************************************
* "Mod Adopted Dalish"
*******************************************************************************/

    object oSenros    = Party_GetFollowerByTag(GEN_FL_Senros);
    object oIlyana    = Party_GetFollowerByTag(GEN_FL_Ilyana);
    object oAnaise    = Party_GetFollowerByTag(GEN_FL_Anaise);
    object oDominique = Party_GetFollowerByTag(GEN_FL_Dominique);
    object oMerrilyla = Party_GetFollowerByTag(GEN_FL_Merrilyla);

    CheckFollowerFlag(oSenros   , PLT_GEN00PT_ADOPTED_DALISH, GEN_SENROS_RECRUITED, GEN_SENROS_IN_CAMP);
    CheckFollowerFlag(oIlyana   , PLT_GEN00PT_ADOPTED_DALISH, GEN_ILYANA_RECRUITED, GEN_ILYANA_IN_CAMP);
    CheckFollowerFlag(oAnaise   , PLT_GEN00PT_ADOPTED_DALISH, GEN_ANAISE_RECRUITED, GEN_ANAISE_IN_CAMP);
    CheckFollowerFlag(oDominique, PLT_GEN00PT_ADOPTED_DALISH, GEN_DOMINIQUE_RECRUITED, GEN_DOMINIQUE_IN_CAMP);
    CheckFollowerFlag(oMerrilyla, PLT_GEN00PT_ADOPTED_DALISH, GEN_MERRILYLA_RECRUITED, GEN_MERRILYLA_IN_CAMP);

    Member_List[5] = oSenros;
    Member_List[6] = oIlyana;
    Member_List[7] = oAnaise;
    Member_List[8] = oDominique;
    Member_List[9] = oMerrilyla;


/*******************************************************************************
* Mod "Party Recruiting"
*******************************************************************************/

    object oAndrastalla = Party_GetFollowerByTag(GEN_FL_Andrastalla);
    object oCailan = Party_GetFollowerByTag(GEN_FL_Cailan);
    object oAnora = Party_GetFollowerByTag(GEN_FL_Anora);
    object oArlEamon = Party_GetFollowerByTag(GEN_FL_Arl_Eamon);
    object oDuncan = Party_GetFollowerByTag(GEN_FL_Duncan);
    object oLadyF = Party_GetFollowerByTag(GEN_FL_LadyOfTheForest);
    object oFlemeth = Party_GetFollowerByTag(GEN_FL_Flemeth);
    object oRikku = Party_GetFollowerByTag(GEN_FL_Rikku_Templar);
    object oTroga = Party_GetFollowerByTag(GEN_FL_Troga);

    CheckFollowerFlag(oAndrastalla, PLT_GEN00PT_PARTY_RECRUIT, GEN_ANDRASTALLA_RECRUITED, GEN_ANDRASTALLA_IN_CAMP);
    CheckFollowerFlag(oCailan, PLT_GEN00PT_PARTY_RECRUIT, GEN_CAILAN_RECRUITED, GEN_CAILAN_IN_CAMP);
    CheckFollowerFlag(oAnora, PLT_GEN00PT_PARTY_RECRUIT, GEN_ANORA_RECRUITED, GEN_ANORA_IN_CAMP);
    CheckFollowerFlag(oArlEamon, PLT_GEN00PT_PARTY_RECRUIT, GEN_ARL_EAMON_RECRUITED, GEN_ARL_EAMON_IN_CAMP);
    CheckFollowerFlag(oDuncan, PLT_GEN00PT_PARTY_RECRUIT, GEN_DUNCAN_RECRUITED, GEN_DUNCAN_IN_CAMP);
    CheckFollowerFlag(oLadyF, PLT_GEN00PT_PARTY_RECRUIT, GEN_LADYOFTHEFOREST_RECRUITED, GEN_LADYOFTHEFOREST_IN_CAMP);
    CheckFollowerFlag(oFlemeth, PLT_GEN00PT_PARTY_RECRUIT, GEN_FLEMETH_RECRUITED, GEN_FLEMETH_IN_CAMP);
    CheckFollowerFlag(oRikku, PLT_GEN00PT_PARTY_RECRUIT, GEN_RIKKU_RECRUITED, GEN_RIKKU_IN_CAMP);
    CheckFollowerFlag(oTroga, PLT_GEN00PT_PARTY_RECRUIT, GEN_TROGA_RECRUITED, GEN_TROGA_IN_CAMP);

    Member_List[10] = oAndrastalla;
    Member_List[11] = oCailan;
    Member_List[12] = oAnora;
    Member_List[13] = oArlEamon;
    Member_List[14] = oDuncan;
    Member_List[15] = oLadyF;
    Member_List[16] = oFlemeth;
    Member_List[17] = oRikku;
    Member_List[18] = oTroga;

/*******************************************************************************
* "Dark Time Act 1"
*******************************************************************************/

    object oIsaac    = Party_GetFollowerByTag(GEN_FL_Isaac);
    object oMiriam   = Party_GetFollowerByTag(GEN_FL_Miriam);
    object oMarukhan = Party_GetFollowerByTag(GEN_FL_Marukhan);

    CheckFollowerFlag(oIsaac, PLT_DT_ACT1, GEN_ISAAC_RECRUITED, GEN_ISAAC_IN_CAMP);
    CheckFollowerFlag(oMiriam, PLT_DT_ACT1, GEN_MIRIAM_RECRUITED, GEN_MIRIAM_IN_CAMP);
    CheckFollowerFlag(oMarukhan, PLT_DT_ACT1, GEN_MARUKHAN_RECRUITED, GEN_MARUKHAN_IN_CAMP);

    Member_List[19] = oIsaac;
    Member_List[20] = oMiriam;
    Member_List[21] = oMarukhan;

/*******************************************************************************
* "Tevinter Warden"
*******************************************************************************/

    object oLanna    = Party_GetFollowerByTag(GEN_FL_Lanna);
    object oMarric   = Party_GetFollowerByTag(GEN_FL_Marric);
    object oMartin   = Party_GetFollowerByTag(GEN_FL_Martin);
    object oWillam   = Party_GetFollowerByTag(GEN_FL_Willam);

    CheckFollowerFlag(oLanna, PLT_GEN00PT_PARTY_LANNA, GEN_LANNA_HIRED, GEN_LANNA_IN_CAMP);
    CheckFollowerFlag(oMarric, PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_HIRED, GEN_MARRIC_IN_CAMP);
    CheckFollowerFlag(oMartin, PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_HIRED, GEN_MARTIN_IN_CAMP);
    CheckFollowerFlag(oWillam, PLT_GEN00PT_PARTY_WILLAM, GEN_WILLAM_HIRED, GEN_WILLAM_IN_CAMP);

    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LANNA, GEN_LANNA_FIRED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARRIC, GEN_MARRIC_FIRED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_FIRED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_WILLAM, GEN_WILLAM_FIRED, FALSE);

    Member_List[22] = oLanna;
    Member_List[23] = oMarric;
    Member_List[24] = oMartin;
    Member_List[25] = oWillam;

/*******************************************************************************
* "Lealion and Legion"
*******************************************************************************/

    object oLealion  = Party_GetFollowerByTag(GEN_FL_Lealion);
    object oLegion   = Party_GetFollowerByTag(GEN_FL_Legion);

    CheckFollowerFlag(oLealion, PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED, GEN_LEALION_IN_CAMP);
    CheckFollowerFlag(oLegion , PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_HIRED, GEN_LEGION_IN_CAMP);

    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_FIRED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_FIRED, FALSE);

    Member_List[26] = oLealion;
    Member_List[27] = oLegion;

/*******************************************************************************
* "Enigma"
*******************************************************************************/

    object oVekuul   = Party_GetFollowerByTag(GEN_FL_Vekuul);
    object oVishala  = Party_GetFollowerByTag(GEN_FL_Vishala);
    object oHelperLady  = Party_GetFollowerByTag(GEN_FL_helperlady);

    CheckFollowerFlag(oVekuul  , PLT_ENIGMA_PLOT1, GEN_VEKUUL_RECRUITED , GEN_VEKUUL_IN_CAMP);
    CheckFollowerFlag(oVishala , PLT_ENIGMA_PLOT1, GEN_VISHALA_RECRUITED, GEN_VISHALA_IN_CAMP);
    CheckFollowerFlag(oHelperLady , PLT_ENIGMA_PLOT1, GEN_HELPERLADY_RECRUITED, GEN_HELPERLADY_IN_CAMP);

    Member_List[28] = oVekuul;
    Member_List[29] = oVishala;
    Member_List[30] = oHelperLady;

/*******************************************************************************
* "Warden's women"
*******************************************************************************/

    object oMithra   = Party_GetFollowerByTag(GEN_FL_Mithra);
    object oElora    = Party_GetFollowerByTag(GEN_FL_Elora);

    CheckFollowerFlag(oMithra  , PLT_GEN00PT_NDQ_MITHRA, GEN_MITHRA_RECRUITED , GEN_MITHRA_IN_CAMP);
    CheckFollowerFlag(oElora   , PLT_GEN00PT_NDQ_ELORA , GEN_ELORA_RECRUITED  , GEN_ELORA_IN_CAMP);

    Member_List[31] = oMithra;
    Member_List[32] = oElora;

/*******************************************************************************
* "In search of Raina"
*******************************************************************************/

    object oTerra   = Party_GetFollowerByTag(GEN_FL_Terra);
    object oRaina   = Party_GetFollowerByTag(GEN_FL_Raina);

    CheckFollowerFlag(oTerra  , PLT_SDT_MOD_RAINA, GEN_TERRA_RECRUITED, GEN_TERRA_IN_CAMP);
    CheckFollowerFlag(oRaina  , PLT_SDT_MOD_RAINA, GEN_RAINA_RECRUITED, GEN_RAINA_IN_CAMP);

    Member_List[33] = oTerra;
    Member_List[34] = oRaina;

/*******************************************************************************
* "Orand Serenity"
*******************************************************************************/
    object oSerenity   = Party_GetFollowerByTag(GEN_FL_Serenity);

    CheckFollowerFlag(oSerenity, PLT_GEN00PT_ORAND_SERENITY, GEN_SERENITY_RECRUITED, GEN_SERENITY_IN_CAMP);

    Member_List[35] = oSerenity;

    return Member_List;

}

void Camp2_PlaceFollowersInCamp()
{
    //Activate party member and prepare a member list.
    object [] arParty = ActivateFollowers();
    int nSize = GetArraySize(arParty);
    int i;

    object oCurrent;
    string sWP;
    object oWP;

    //2-1. Remove all map pins (in case someone left the group)
    object [] arPins = GetObjectsInArea(OBJECT_SELF);
    int nObjectsSize = GetArraySize(arPins);
    int j;
    object oCurrentObject;
    for(j = 0; j < nObjectsSize; j++)
    {
        oCurrentObject = arPins[j];
        if(GetObjectType(oCurrentObject) == OBJECT_TYPE_WAYPOINT && StringLeft(GetTag(oCurrentObject), 8) == WP_CAMP2_FOLLOWER_PREFIX)
            SetMapPinState(oCurrentObject, FALSE);
    }

    //2-2. Command companions jump to their correspond position
    for(i = 0; i < nSize; i++)
    {
        oCurrent = arParty[i];
        if(GetObjectActive(oCurrent) && !IsHero(oCurrent))
        {
            sWP = WP_CAMP2_FOLLOWER_PREFIX + GetTag(oCurrent);
            UT_LocalJump(oCurrent, sWP);
            oWP = GetObjectByTag(sWP);
            SetMapPinState(oWP, TRUE);
            SetImmortal(oCurrent, TRUE);
            RW_CatchUpToPlayer(oCurrent);

            // Start the follower ambient system.
            Camp_FollowerAmbient(oCurrent, TRUE);

        }
    }

}

void Camp2_RemoveFollowerFromCamp(){

    object [] arParty = GetPartyPoolList();
    object oCurrent;
    int nSize = GetArraySize(arParty);
    int i;

    for(i = 0; i < nSize; i++){
       oCurrent = arParty[i];
       if(GetObjectActive(oCurrent) && !IsHero(oCurrent))
       {
           WR_SetObjectActive(oCurrent,FALSE);
       }
    }
}
