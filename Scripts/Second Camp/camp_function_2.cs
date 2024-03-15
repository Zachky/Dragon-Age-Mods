/*******************************************************************************
* Note:
* 1. About CheckFollowerFlag() method, there is an issue that "Recruited" flag might be false
*    but companion still exist in warden's party pool,
*    (Whether this follower is in warden's 4 man party or in the party picker)
*    so the first part will check if flag is false but follower is in the party, if yes the flag
*    will be set to TRUE.
*******************************************************************************/


#include "party_h"
#include "utility_h"
#include "wrappers_h"
#include "sys_rewards_h"
#include "sys_ambient_h"
#include "camp_constants_h"
#include "global_objects_2"

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



const string WP_CAMP2_FOLLOWER_PREFIX = "wp_pcamp2_";

void Camp_FollowerAmbient(object oFollower, int bStart)
{

    string  sTag    =   GetTag(oFollower);
    string  sArea   =   GetTag(GetArea(oFollower));
    int nAnim = 4;

    // Log Record
    Log_Trace(LOG_CHANNEL_PLOT, "Follower: " + sTag, "Found in Area: " + sArea);

    // Set Follower in no-movement phase, just animation.
    SetLocalInt(oFollower, AMBIENT_ANIM_STATE, AMBIENT_ANIM_RESET);

    // Assign ambient variables
    if(!bStart){
        Ambient_Stop(oFollower);
    }else{

        //Main Story
        if     (sTag == GEN_FL_Daveth)           nAnim   =   24;
        else if(sTag == GEN_FL_Jory)             nAnim   =   37;
        else if(sTag == GEN_FL_Fenarel)          nAnim   =   9;
        else if(sTag == GEN_FL_Merrill)          nAnim   =   85;
        else if(sTag == GEN_FL_Moira)            nAnim   =   9;

        //Adopted Dalish
        else if(sTag == GEN_FL_Ilyana)           nAnim   =   37;
        else if(sTag == GEN_FL_Senros)           nAnim   =   100;
        else if(sTag == GEN_FL_Anaise)           nAnim   =   100;
        else if(sTag == GEN_FL_Dominique)        nAnim   =   85;
        else if(sTag == GEN_FL_Merrilyla)        nAnim   =   37;

        //Party Recruiting Mod
        else if(sTag == GEN_FL_Duncan)           nAnim   =   100;
        else if(sTag == GEN_FL_Cailan)           nAnim   =   85;
        else if(sTag == GEN_FL_Andrastalla)      nAnim   =   37;
        else if(sTag == GEN_FL_Anora)            nAnim   =   37;
        else if(sTag == GEN_FL_Flemeth)          nAnim   =   4;
        else if(sTag == GEN_FL_Arl_Eamon)        nAnim   =   71;
        else if(sTag == GEN_FL_Troga)            nAnim   =   70;
        else if(sTag == GEN_FL_Rikku_Templar)    nAnim   =   100;
        else if(sTag == GEN_FL_LadyOfTheForest)  nAnim   =   37;

        //Dark Time Act 1
        else if(sTag == GEN_FL_Isaac)            nAnim   =   100;
        else if(sTag == GEN_FL_Miriam)           nAnim   =   37;
        else if(sTag == GEN_FL_Marukhan)         nAnim   =   85;

        //Tevinter Warden
        else if(sTag == GEN_FL_Lanna)            nAnim   =   100;
        else if(sTag == GEN_FL_Marric)           nAnim   =   71;
        else if(sTag == GEN_FL_Martin)           nAnim   =   70;
        else if(sTag == GEN_FL_Willam)           nAnim   =   48; 
        
        //Lealion
        else if(sTag == GEN_FL_Lealion)          nAnim   =   37;
        else if(sTag == GEN_FL_Legion)           nAnim   =   4;

        //Other Mod Companions...


        Ambient_Start(oFollower, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, nAnim, AMBIENT_ANIM_FREQ_ORDERED);

        Log_Trace(LOG_CHANNEL_PLOT, "Starting Ambient Animations for: " + sTag, "Playing Animation: " + IntToString(nAnim));

    }
}

void CheckFollowerFlag(object oFollower, string strPlot, int FlagRecruited, int FlagCamp){

//-------------------------Check recruited state first--------------------------

   if( WR_GetPlotFlag(strPlot, FlagRecruited) == FALSE &&
        (GetFollowerState(oFollower) == FOLLOWER_STATE_ACTIVE ||
         GetFollowerState(oFollower) == FOLLOWER_STATE_AVAILABLE )
      ){WR_SetPlotFlag(strPlot, FlagRecruited, TRUE);}

//---------------------------Set Follower state---------------------------------

   if( WR_GetPlotFlag(strPlot, FlagRecruited) == TRUE )
    {
        WR_SetPlotFlag(strPlot, FlagCamp, TRUE, TRUE);
        WR_SetObjectActive(oFollower, TRUE);
        SetFollowerState(oFollower,FOLLOWER_STATE_AVAILABLE);
    }

}

void ActivateFollowers(){


/*******************************************************************************
* "Main Stoty"
*******************************************************************************/

    object oDaveth  = Party_GetFollowerByTag(GEN_FL_Daveth);
    object oJory    = Party_GetFollowerByTag(GEN_FL_Jory);
    object oFenarel = Party_GetFollowerByTag(GEN_FL_Fenarel);
    object oMerrill = Party_GetFollowerByTag(GEN_FL_Merrill);
    object oMoira = Party_GetFollowerByTag(GEN_FL_Moira);

    CheckFollowerFlag(oDaveth, PLT_GEN00PT_MAIN_STORY, GEN_DAVETH_RECRUITED, GEN_DAVETH_IN_CAMP);
    CheckFollowerFlag(oJory, PLT_GEN00PT_MAIN_STORY, GEN_JORY_RECRUITED, GEN_JORY_IN_CAMP);
    CheckFollowerFlag(oFenarel, PLT_GEN00PT_MAIN_STORY, GEN_FENAREL_RECRUITED, GEN_FENAREL_IN_CAMP);
    CheckFollowerFlag(oMerrill, PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_RECRUITED, GEN_MERRILL_IN_CAMP);
    CheckFollowerFlag(oMoira, PLT_GEN00PT_MAIN_STORY, GEN_MOIRA_RECRUITED, GEN_MOIRA_IN_CAMP);

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


/*******************************************************************************
* "Dark Time Act 1"
*******************************************************************************/

    object oIsaac    = Party_GetFollowerByTag(GEN_FL_Isaac);
    object oMiriam   = Party_GetFollowerByTag(GEN_FL_Miriam);
    object oMarukhan = Party_GetFollowerByTag(GEN_FL_Marukhan);

    CheckFollowerFlag(oIsaac, PLT_DT_ACT1, GEN_ISAAC_RECRUITED, GEN_ISAAC_IN_CAMP);
    CheckFollowerFlag(oMiriam, PLT_DT_ACT1, GEN_MIRIAM_RECRUITED, GEN_MIRIAM_IN_CAMP);
    CheckFollowerFlag(oMarukhan, PLT_DT_ACT1, GEN_MARUKHAN_RECRUITED, GEN_MARUKHAN_IN_CAMP);

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
    
/*******************************************************************************
* "Lealion and Legion"
*******************************************************************************/

    object oLealion  = Party_GetFollowerByTag(GEN_FL_Lealion);
    object oLegion   = Party_GetFollowerByTag(GEN_FL_Legion);
    
    CheckFollowerFlag(oLealion, PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED, GEN_LEALION_IN_CAMP);
    CheckFollowerFlag(oLegion , PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_HIRED, GEN_LEGION_IN_CAMP);
    
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_FIRED, FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_FIRED, FALSE);
   
}

void Camp_PlaceFollowersInCamp()
{
    //1. Activate Followers
    ActivateFollowers();

    //2. Place all active party members in their spots
    object [] arParty = GetPartyPoolList();
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