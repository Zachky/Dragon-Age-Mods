//==============================================================================
/*

    Raina's Sister, Terra, Plot Script

*/
//==============================================================================

#include "utility_h"
#include "wrappers_h"
#include "plot_h"
#include "sys_ambient_h"
#include "plt_sdt_terra"

const int SDT_FOLLOWER_TERRA = 37325739; //Replace with Terra's id
/* Other companion numbers in use
50 - IDOMENEAS' QUEST & LEGENDS
1140150041 - IMMORTALITY'S SER GILMORE NPC
*/

void SetFollowerInParty(object oFollower, string sPlot, int nFlag)
{
//    DisplayFloatyMessage(GetHero(),"In Party",FLOATY_MESSAGE,0xff0000,10.0);
    WR_SetPlotFlag(sPlot, nFlag, FALSE);
    WR_SetObjectActive(oFollower, TRUE);
    SetImmortal(oFollower, FALSE);
    WR_SetFollowerState(oFollower, FOLLOWER_STATE_ACTIVE, TRUE);
    command cJump = CommandJumpToObject(GetPartyLeader());
    WR_AddCommand(oFollower, cJump);
}

void SetFollowerInCamp(object oFollower, string sPlot, int nFollowerPartyFlag, int bSetInactive = TRUE)
{
//    DisplayFloatyMessage(GetHero(),"In Camp",FLOATY_MESSAGE,0xff0000,10.0);
    WR_SetPlotFlag(sPlot, nFollowerPartyFlag, FALSE);
    WR_SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE, FALSE);
    if(bSetInactive)
    {
//        DisplayFloatyMessage(GetHero(),"Inactive",FLOATY_MESSAGE,0xff0000,10.0);
        WR_SetObjectActive(oFollower, FALSE);
    }else{
//        DisplayFloatyMessage(GetHero(),"Positioning",FLOATY_MESSAGE,0xff0000,10.0);
        // position follower in camp
        object oArea = GetArea(GetHero());
        string sAreaTag = GetTag(oArea);
        location lFollower;
        // Put Terra into a suitable position in the area
        if ((sAreaTag=="cam100ar_camp_plains")||(sAreaTag=="cam100ar_camp_arch1")||(sAreaTag=="cam100ar_camp_arch3"))
            lFollower=Location(oArea, Vector(137.564, 115.815, -1.08586), 180.0);

        if(sAreaTag=="den211ar_arl_eamon_estate_1")
            lFollower=Location(oArea, Vector(80.8,30.6,5.0), 0.0);

        if(sAreaTag=="cli300ar_redcliffe_castle")
            lFollower=Location(oArea, Vector(14.8,-17.0, 0.0), 22.8);

        if(sAreaTag=="epi300ar_post_coronation")
            lFollower=Location(oArea, Vector(41.8,-4.5,0.0), 62.0);

        if(sAreaTag=="epi200ar_players_funeral")
            lFollower=Location(oArea, Vector(255.0,302.8,1.9), -80.0);

        SetObjectActive(oFollower,1);
        AddCommand(oFollower, CommandJumpToLocation(lFollower));

        SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE);
        if(sAreaTag=="cam100ar_camp_plains")
        {
            // Warm by fire
            Ambient_Start(oFollower, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, 70, AMBIENT_ANIM_FREQ_ORDERED);
        }else{
            // Stand relaxed
            Ambient_Start(oFollower, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, 56, AMBIENT_ANIM_FREQ_ORDERED);
        }

    }

}

void SetFollowerRecruited(object oFollower, int nValue, string sPlot, int nCampFlag, int nPartyFlag, int nShowPartyPicker, int nForceAddToParty = FALSE)
{
    string sFollower = GetTag(oFollower);
    object oPC = GetPartyLeader();
    object oArea = GetArea(oPC);
    if(nValue == TRUE)
    {
        //Tidy up NPC for being in party
        SetTeamId(oFollower, -1);
        SetImmortal(oFollower, FALSE);
        SetPlot(oFollower, FALSE);
        int nLevel = GetLevel(oFollower)-6;
        ScaleEquippedItems(oFollower, nLevel);
        SetFollowerApprovalEnabled(oFollower, TRUE);
        SetFollowerApprovalDescription(oFollower, 371487);
        if(GetTag(oFollower) == GEN_FL_DOG)
        {
            AdjustFollowerApproval(oFollower, 100);
            SetFollowerApprovalDescription(oFollower, 371489);
        }

        if(nForceAddToParty)
        {
            // Clearing active party so there won't be 1+4 party members
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_ALISTAIR_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_ALISTAIR_IN_CAMP, TRUE, TRUE);
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_DOG_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_DOG_IN_CAMP, TRUE, TRUE);
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_SHALE_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_SHALE_IN_CAMP, TRUE, TRUE);
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_STEN_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_STEN_IN_CAMP, TRUE, TRUE);
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_ZEVRAN_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_ZEVRAN_IN_CAMP, TRUE, TRUE);
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_OGHREN_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_OGHREN_IN_CAMP, TRUE, TRUE);
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_LELIANA_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_LELIANA_IN_CAMP, TRUE, TRUE);
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_MORRIGAN_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_MORRIGAN_IN_CAMP, TRUE, TRUE);
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_WYNNE_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_WYNNE_IN_CAMP, TRUE, TRUE);
            if(WR_GetPlotFlag( PLT_GEN00PT_PARTY, GEN_LOGHAIN_RECRUITED))
                WR_SetPlotFlag(PLT_GEN00PT_PARTY, GEN_LOGHAIN_IN_CAMP, TRUE, TRUE);

            WR_SetPlotFlag(sPlot, nPartyFlag, TRUE, TRUE); // Setting locked followers's in-party flag here since it won't be trigger using the GUI
            WR_SetFollowerState(oFollower, FOLLOWER_STATE_LOCKEDACTIVE, FALSE);
        }
        else // not locked into party - set follower to be available for adding into party
        {
             WR_SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE, FALSE);
        }


        if(nShowPartyPicker)
        {
            // Party picker GUI is triggered in player_core, through the event
        }
        else
        {
            WR_SetFollowerState(oFollower, FOLLOWER_STATE_ACTIVE, FALSE);
            WR_SetPlotFlag(sPlot, nPartyFlag, TRUE);
        }
        SetEventScript(oFollower, RESOURCE_SCRIPT_PLAYER_CORE); // needed for sending the hired event, below
        SendPartyMemberHiredEvent(oFollower, nShowPartyPicker);
    }
    else // clearing the flag -> follower leaves for good
    {
        WR_SetFollowerState(oFollower, FOLLOWER_STATE_INVALID);
        WR_SetPlotFlag(sPlot, nCampFlag, FALSE);
        WR_SetPlotFlag(sPlot, nPartyFlag, FALSE);
        WR_SetObjectActive(oFollower, FALSE);

    }

}

int StartingConditional()
{

    //--------------------------------------------------------------------------
    // Initialization
    //--------------------------------------------------------------------------

    // Load Event Variables
    event   evEvent = GetCurrentEvent();            // Contains input parameters
    int     nType   = GetEventType(evEvent);        // GET or SET call
    string  sPlot   = GetEventString(evEvent, 0);   // Plot GUID
    int     nFlag   = GetEventInteger(evEvent, 1);  // The bit flag # affected
    object  oOwner  = GetEventCreator(evEvent);     // Script plot table owner

    // Grab Player, Set Default return to FALSE
    object  oPC     = GetHero();
    object  oParty  = GetParty( oPC );
    object  oTerra  = GetObjectByTag("terra");
    int     bResult = FALSE;

    // Plot Debug / Global Operations
    plot_GlobalPlotHandler(evEvent);

    //--------------------------------------------------------------------------
    // Actions -> normal flags only (SET)
    // IMPORTANT:   The flag value on a SET event is set only AFTER this script
    //              finishes running!
    //--------------------------------------------------------------------------

    if( nType == EVENT_TYPE_SET_PLOT )
    {

        int nOldValue   = GetEventInteger(evEvent, 3);  // Old flag value
        int nValue   = GetEventInteger(evEvent, 2);  // New flag value

        // Check for which flag was set
        switch(nFlag)
        {


/*            case SDT_TERRA_PLACED:
            {
                // Try to sort out inappropriate equipment levels
                int nLevel = GetLevel(GetHero()) - 6;
                ScaleEquippedItems(oLenka,nLevel);
                break;
            }
*/
            case SDT_TERRA_HIRED:
            {
                SetFollowerRecruited(oTerra, nValue, sPlot, SDT_TERRA_IN_CAMP, SDT_TERRA_IN_PARTY, TRUE);
                break;
            }
            case SDT_TERRA_IN_PARTY:
            {
                if (nValue)     // Is flag being set to TRUE or FALSE
                {
                    if (WR_GetPlotFlag(PLT_SDT_TERRA,SDT_TERRA_IN_FADE))
                    {
                       Ambient_Start(oTerra, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, /*relaxed animation*/ 56, AMBIENT_ANIM_FREQ_ORDERED);
                       SetFollowerInParty(oTerra, sPlot, SDT_TERRA_IN_FADE);
                    }else{
                        SetFollowerInParty(oTerra, sPlot, SDT_TERRA_IN_CAMP);
                    }
                }else{
                    SetFollowerInCamp(oTerra, sPlot, SDT_TERRA_IN_PARTY, TRUE);
                }
                break;
            }
            case SDT_TERRA_IN_CAMP:
            {
//                DisplayFloatyMessage(oPC,"Camp plot triggered",FLOATY_MESSAGE,0xff0000,10.0);
                if (!IsObjectValid(oTerra))      // Check Lenka is present
                {
                    location lTerra = Location(GetArea(oPC), Vector(137.564, 115.815, -1.08586), 180.0);
                    oTerra = CreateObject(OBJECT_TYPE_CREATURE,R"terra.utc",lTerra);
                }
                SetFollowerInCamp(oTerra, sPlot, SDT_TERRA_IN_PARTY, FALSE);
                break;
            }
/*            case SDT_TERRA_IN_FADE:
            {
//                DisplayFloatyMessage(oPC,"Fade plot triggered",FLOATY_MESSAGE,0xff0000,10.0);
                // Stop Lenka from following player
                WR_SetPlotFlag(PLT_SDT_TERRA, SDT_TERRA_IN_PARTY, FALSE);
                WR_SetFollowerState(oTerra, FOLLOWER_STATE_AVAILABLE, TRUE);
                WR_SetObjectActive(oTerra, FALSE);
                // Set plot flag for nightmare processing
                WR_SetPlotFlag(PLT_SDT_FADE_TERRA,TERRA_SLEEP,TRUE);
                // There are 3 nightmare fade areas - find the first free one
                int nFoll_1=GetLocalInt(GetModule(),CIR_FADE_FOLLOWER_1);
                int nFoll_2=GetLocalInt(GetModule(),CIR_FADE_FOLLOWER_2);
                int nFoll_3=GetLocalInt(GetModule(),CIR_FADE_FOLLOWER_3);
                if(nFoll_1<1)
                {
                    WR_SetPlotFlag(PLT_SDT_FADE_TERRA,TERRA_NIGHTMARE_A,TRUE);
                    SetLocalInt(GetModule(),CIR_FADE_FOLLOWER_1,SDT_FOLLOWER_TERRA);
                }
                else if(nFoll_2<1)
                {
                    WR_SetPlotFlag(PLT_SDT_FADE_TERRA,TERRA_NIGHTMARE_B,TRUE);
                    SetLocalInt(GetModule(),CIR_FADE_FOLLOWER_2,SDT_FOLLOWER_TERRA);
                }
                else if(nFoll_3<1)
                {
                    WR_SetPlotFlag(PLT_SDT_FADE_TERRA,TERRA_NIGHTMARE_C,TRUE);
                    SetLocalInt(GetModule(),CIR_FADE_FOLLOWER_3,SDT_FOLLOWER_TERRA);
                }
                break;
            }
*/

        }
    }

    //--------------------------------------------------------------------------
    // Conditions -> defined flags only (GET DEFINED)
    //--------------------------------------------------------------------------

    else
    {

        // Check for which flag was checked
        switch(nFlag)
        {

        }
    }

    // Plot Debug / Global Operations
    plot_OutputDefinedFlag( evEvent, bResult );

    return bResult;

}