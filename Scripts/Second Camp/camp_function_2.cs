#include "party_h"
#include "utility_h"
#include "wrappers_h"
#include "sys_rewards_h"
#include "sys_ambient_h"
#include "camp_constants_h"   
#include "global_objects_2" 

#include "plt_gen00pt_party_recruit"


const string WP_CAMP_FOLLOWER_PREFIX = "wp_camp_";

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

        //Party Recruiting Mod
        if     (sTag == GEN_FL_Duncan)           nAnim   =   4;      // Relaxed.
        else if(sTag == GEN_FL_Cailan)           nAnim   =   85;     // Listener Passive 3
        else if(sTag == GEN_FL_Andrastalla)      nAnim   =   24;     // Guard Wander Left and Right
        else if(sTag == GEN_FL_Anora)            nAnim   =   67;     // Bored Loitering 1
        else if(sTag == GEN_FL_Flemeth)          nAnim   =   103;    // Bored Stationary
        else if(sTag == GEN_FL_Arl_Eamon)        nAnim   =   71;     // Chat by fire.
        else if(sTag == GEN_FL_Troga)            nAnim   =   70;     // Warm by fire.
        else if(sTag == GEN_FL_Rikku_Templar)    nAnim   =   100;    // Squat by fire.
        else if(sTag == GEN_FL_LadyOfTheForest)  nAnim   =   68;     // Bored Loitering 2

        //Other Mod Companions...

        Ambient_Start(oFollower, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, nAnim, AMBIENT_ANIM_FREQ_ORDERED);
        
        Log_Trace(LOG_CHANNEL_PLOT, "Starting Ambient Animations for: " + sTag, "Playing Animation: " + IntToString(nAnim)); 
    
    }
}

void ActivateFollowers(){

    //Activate companion who has been recruited by player

  /*object oAlistair = Party_GetFollowerByTag(GEN_FL_Duncan);
    object oMorrigan = Party_GetFollowerByTag(GEN_FL_Cailan);
    object oDog = Party_GetFollowerByTag(GEN_FL_Andrastalla);
    object oWynne = Party_GetFollowerByTag(GEN_FL_Anora);
    object oShale = Party_GetFollowerByTag(GEN_FL_Flemeth);
    object oSten = Party_GetFollowerByTag(GEN_FL_Arl_Eamon);
    object oZevran = Party_GetFollowerByTag(GEN_FL_Troga);
    object oOghren = Party_GetFollowerByTag(GEN_FL_Rikku_Templar);
    object oLeliana = Party_GetFollowerByTag(GEN_FL_LadyOfTheForest);

    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_ALISTAIR_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_ALISTAIR_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oAlistair, TRUE);
    }
    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_DOG_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_DOG_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oDog, TRUE);
    }
    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_WYNNE_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_WYNNE_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oWynne, TRUE);
    }
    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_SHALE_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_SHALE_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oShale, TRUE);
    }
    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_STEN_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_STEN_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oSten, TRUE);
    }
    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_ZEVRAN_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_ZEVRAN_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oZevran, TRUE);
    }
    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_OGHREN_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_OGHREN_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oOghren, TRUE);
    }
    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_LELIANA_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_LELIANA_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oLeliana, TRUE);
    }
    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_MORRIGAN_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_MORRIGAN_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oMorrigan, TRUE);
    }
    if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_LOGHAIN_RECRUITED))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_LOGHAIN_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oLoghain, TRUE);
    } */

    //Test Area
    
    object oAndrastalla = Party_GetFollowerByTag(GEN_FL_Andrastalla);  
    object oCailan = Party_GetFollowerByTag(GEN_FL_Cailan); 
    
    if( WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ANDRASTALLA_RECRUITED) == TRUE )
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ANDRASTALLA_IN_CAMP, TRUE, TRUE);
        WR_SetObjectActive(oAndrastalla, TRUE);
        SetFollowerState(oAndrastalla,FOLLOWER_STATE_AVAILABLE);
    } 
    
    if( WR_GetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_CAILAN_RECRUITED) == TRUE )
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_CAILAN_IN_CAMP, TRUE, TRUE); 
        WR_SetObjectActive(oCailan, TRUE);
        SetFollowerState(oCailan,FOLLOWER_STATE_AVAILABLE);
    }
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
        if(GetObjectType(oCurrentObject) == OBJECT_TYPE_WAYPOINT && StringLeft(GetTag(oCurrentObject), 8) == WP_CAMP_FOLLOWER_PREFIX)
            SetMapPinState(oCurrentObject, FALSE);
    }

    //2-2. Command companions jump to their correspond position
    for(i = 0; i < nSize; i++)
    {
        oCurrent = arParty[i];
        if(GetObjectActive(oCurrent) && !IsHero(oCurrent))
        {
            sWP = WP_CAMP_FOLLOWER_PREFIX + GetTag(oCurrent);
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