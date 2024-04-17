//::///////////////////////////////////////////////
//:: Area Core
//:: Copyright (c) 2003 Bioware Corp.
//:://////////////////////////////////////////////
/*
    Handles global area events for the Dalish camp
*/
//:://////////////////////////////////////////////
//:: Created By: Cori
//:: Created On: Feb 7/07
//:://////////////////////////////////////////////

#include "utility_h"
#include "sys_injury"

#include "global_objects_h"
#include "camp_function_2"
#include "p_utility"


void main()
{
    event ev = GetCurrentEvent();
    int nEventType = GetEventType(ev);
    object oPC = GetMainControlled();

    switch(nEventType)
    {
        ///////////////////////////////////////////////////////////////////////
        // Sent by: The engine
        // When: for things you want to happen while the load screen is still up,
        // things like moving creatures around
        ////////////////////////////////////////////////////////////////////////
        case EVENT_TYPE_AREALOAD_PRELOADEXIT:
        {
            //Log
            Log_Trace(LOG_CHANNEL_SYSTEMS, "2nd Party Camp AREA FINISHED LOADING");

            //Not really needed. Added as an extra line of defense.
            InitHeartbeat(oPC, CONFIG_CONSTANT_HEARTBEAT_RATE);

            //Place followers
            Camp2_PlaceFollowersInCamp();

            //Place player at camp entrance
            UT_LocalJump(oPC,"cam100wp_entrance");

            //Set player's location on the world map
            object oMap = GetObjectByTag("wide_open_world_2");
            object oCampLocation = GetObjectByTag("wml_wow_camp_2");
            SetWorldMapPlayerLocation(oMap, oCampLocation);

            //Reveal frog area
            RevealCurrentMap();

            break;
        }
        ////////////////////////////////////////////////////////////////////////
        // Sent by: The engine
        // When: all game objects in the area have loaded
        ////////////////////////////////////////////////////////////////////////
        case EVENT_TYPE_AREALOAD_POSTLOADEXIT:
        {
            Injury_RemoveAllInjuriesFromParty();

            break;
        }

        case EVENT_TYPE_PARTYMEMBER_ADDED:
        {
            object oFollower = GetEventObject(ev, 0);

            Event_PartyMemberAddProcess(oFollower);

            break;
        }

        case EVENT_TYPE_PARTYMEMBER_DROPPED:
        {
            object oFollower = GetEventObject(ev, 0);

            Event_PartyMemberDropProcess(oFollower);

            break;

        }

        ////////////////////////////////////////////////////////////////////////
        // Sent by: The engine
        // When: A creature exits the area
        ////////////////////////////////////////////////////////////////////////
        case EVENT_TYPE_EXIT:
        {

            //if dog is in the party -
            int nDog = WR_GetPlotFlag(PLT_GEN00PT_PARTY, GEN_DOG_IN_PARTY);
            if (nDog == TRUE)
            {
                object oDog = Party_GetFollowerByTag("gen00fl_dog");
                //DeActivate Bonus here
                RemoveEffectsByParameters(oDog, EFFECT_TYPE_INVALID, 200261);
            }

            break;
        }
        /*////////////////////////////////////////////////////////////////////////
        // Sent by: Scripting
        // When: The last creature of a team dies
        ////////////////////////////////////////////////////////////////////////
        case EVENT_TYPE_TEAM_DESTROYED:
        {
            int nTeamID = GetEventInteger(ev, 0); // Team ID

            switch (nTeamID)
            {
                case NTB_TEAM_CAMP_ZATHRIAN:
                {
                    int nTeam = WR_GetPlotFlag(PLT_NTB000PT_MAIN,NTB_MAIN_ELVES_DEFEATED,TRUE);
                    // -----------------------------------------------------
                    // if the wolves haven't reveled in the elves defeat yet
                    // return the party picker status to useable
                    // set witherfang and swiftrunner non-immortal again
                    // set witherfang inactive and the Lady active
                    // set that athras is dead
                    // and have the Lady Initiate
                    // -----------------------------------------------------
                    if(nTeam == FALSE)
                    {
                        SetPartyPickerGUIStatus(PP_GUI_STATUS_USE);

                        SetImmortal(oWitherfang,FALSE);
                        SetImmortal(oSwiftrunner,FALSE);

                        WR_SetObjectActive(oWitherfang,FALSE);
                        WR_SetObjectActive(oLady,TRUE);

                        //Move Werewolves to their posts
                        object oWerewolf3 = UT_GetNearestCreatureByTag(oPC, NTB_CR_WEREWOLF_03);
                        UT_LocalJump(oWerewolf3, NTB_WP_WEREWOLF3_POST);

                        WR_SetPlotFlag(PLT_NTB000PT_MAIN,NTB_MAIN_ELVES_DEFEATED,TRUE,TRUE);
                        //- When all elves are dead, Witherfang will turn back into the lady and she will init dialog.
                        UT_Talk(oLady,oPC);
                    }
                    break;
                }
            }
            break;
        }*/

        //------------------------------------------------------------------
        // EVENT_TYPE_STEALING_SUCCESS:
        // Sent by: Skill Script ( skill_stealing)
        // When: player succeeds stealing skill
        //------------------------------------------------------------------

        case EVENT_TYPE_STEALING_SUCCESS:
        {

            break;
        }

        //------------------------------------------------------------------
        // EVENT_TYPE_STEALING_FAILURE:
        // Sent by: Skill Script ( skill_stealing)
        // When: player fails stealing skill
        //------------------------------------------------------------------

        case EVENT_TYPE_STEALING_FAILURE:
        {

            break;
        }
    }
    HandleEvent(ev, RESOURCE_SCRIPT_AREA_CORE);
}