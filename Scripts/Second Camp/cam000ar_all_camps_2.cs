//==============================================================================
/*
    cam000ar_all_camps.nss
    Camp area script - This script should be used for all camp areas.
*/
//==============================================================================

#include "log_h"
#include "utility_h"
#include "wrappers_h"
#include "events_h"
#include "2da_constants_h"
#include "camp_constants_h"

#include "campaign_h"
#include "cutscenes_h" 
#include "sys_injury"

#include "global_objects_h" 
#include "camp_function_2"
#include "p_utility"

#include "party_h"

//------------------------------------------------------------------------------

void main()
{
    event ev = GetCurrentEvent();
    int nEventType = GetEventType(ev);
    string sDebug;

    object oPC = GetHero();

    object  [] arParty  = GetPartyPoolList();
    int     nSize       = GetArraySize(arParty);
    int     nLoop;


    switch(nEventType)
    {
       
        case EVENT_TYPE_AREALOAD_SPECIAL:
        {
            break;
        }

        //----------------------------------------------------------------------
        // Sent by: The engine
        // When: all game objects in the area have loaded
        //----------------------------------------------------------------------
        case EVENT_TYPE_AREALOAD_PRELOADEXIT:
        {
            
            object  [] arParty  =   GetPartyPoolList();
            int     nSize       =   GetArraySize(arParty);
            int     nLoop;

            string sAreaTag     =   GetTag(OBJECT_SELF);

            //Log
            Log_Trace(LOG_CHANNEL_SYSTEMS, "cam000ar_all_camps_2.main", "CAMP AREA FINISHED LOADING");

            //Not really needed. Added as an extra line of defense.
            InitHeartbeat(oPC, CONFIG_CONSTANT_HEARTBEAT_RATE); 
            
            //Place followers
            Camp_PlaceFollowersInCamp();   

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

        //--------------------------------------------------------------------------
        // Sent by: The engine
        // When: fires at the same time that the load screen is going away,
        // and can be used for things that you want to make sure the player sees.
        //------------------------------------------------------------------
        case EVENT_TYPE_AREALOAD_POSTLOADEXIT:
        {
            Injury_RemoveAllInjuriesFromParty();

            break;
        }
        
        //--------------------------------------------------------------------------
        // Sent by: The engine
        // When: Fires when player add companion to the party.
        //------------------------------------------------------------------
        case EVENT_TYPE_PARTYMEMBER_ADDED:
        {
            object oFollower = GetEventObject(ev, 0);
            string strTag = GetTag(oFollower);
            
            //Disable Immortal effect
            SetImmortal(oFollower,0);  
            
            //Enable Exp Gain
            SetLocalInt(oFollower, CREATURE_REWARD_FLAGS, 0);
            
            //Set state to active(Recruited and in the party)
            SetFollowerState(oFollower, FOLLOWER_STATE_ACTIVE);  
            
            //Enable Follower
            SetObjectActive(oFollower,1);  
            
            //Teleport follower to warden's location
            AddCommand(oFollower, CommandJumpToLocation(GetLocation(GetHero()))); 
            
        }
        
        case EVENT_TYPE_PARTYMEMBER_DROPPED:
        {
            object oFollower = GetEventObject(ev, 0); 
            string strTag = GetTag(oFollower);
            
            //Enable Immortal effect
            SetImmortal(oFollower,1); 
            
            //Set state to Avalible(Recruited but not in the party)
            SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE); 
            
        }   
        
        /*case EVENT_TYPE_PARTYPICKER_CLOSED:
        {
            Camp_PlaceFollowersInCamp();   
        }*/
        
        
        //----------------------------------------------------------------------
        // Sent by: The engine
        // When: A creature enters the area
        //----------------------------------------------------------------------
        case EVENT_TYPE_ENTER:
        {
            Log_Trace(LOG_CHANNEL_SYSTEMS, "cam000ar_all_camps_2.main", "OBJECT ENTERING 2nd CAMP");
            
            break;
        }
        //----------------------------------------------------------------------
        // Sent by: The engine
        // When: A creature exits the area
        //----------------------------------------------------------------------
        case EVENT_TYPE_EXIT:
        {
            Log_Trace(LOG_CHANNEL_SYSTEMS, "cam000ar_all_camps_2.main", "OBJECT LEAVING CAMP");
            break;
        }

        case EVENT_TYPE_TEAM_DESTROYED:{
            break;
        }
    }
    HandleEvent(ev, RESOURCE_SCRIPT_AREA_CORE);
}