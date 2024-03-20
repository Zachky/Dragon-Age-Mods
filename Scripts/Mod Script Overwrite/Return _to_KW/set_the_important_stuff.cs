//---------------------------------------------------------------------
/*
     Note:

        This file overwrite the original file "set_the_important_stuff.nss" with
        necessary code
*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h" 
#include "sys_chargen_h"
#include "p_utility"
#include "global_objects_2"  

#include "plt_gen00pt_return_to_kw"

void SpawnAriane(){
   
    if(!WR_GetPlotFlag(PLT_GEN00PT_RETURN_TO_KW,GEN_ARIANE_RECRUITED)){
        
       object oFollower = GetObjectByTag(GEN_FL_Ariane);      
       vector vTent = Vector(1012.96,841.12,5.96999);
       location lTent = Location(GetArea(GetHero()), vTent,  45.0f);
       command cMoveFollower = CommandJumpToLocation(lTent);
            
       SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE);
       AddCommand(oFollower, cMoveFollower);  
    }
}

void main()
{
    event ev = GetCurrentEvent();
    int nEventType = GetEventType(ev);
    switch(nEventType)
    {   
        
        //----------------------------------------------------------------------
        // Sent by: The engine
        // When: all game objects in the area have loaded
        //----------------------------------------------------------------------
        case EVENT_TYPE_AREALOAD_PRELOADEXIT:
        {
            SpawnAriane();
                     
            break;
        }
  
        //------------------------------------------------------------------
        // Sent by: The engine
        // When: Player open party picker
        //------------------------------------------------------------------
        case EVENT_TYPE_MODULE_GETCHARSTAGE:
        {
            SetPartyPickerStage("rtkw_char_stage", "partypicker");
            break;
        }   
            
        //------------------------------------------------------------------
        // Sent by: The engine
        // When: Fires when player add companion to the party.
        //------------------------------------------------------------------    
        case EVENT_TYPE_PARTYMEMBER_ADDED:
        {
            object oFollower = GetEventObject(ev, 0);

            Event_PartyMemberAddProcess(oFollower);
            
            //Adjust flag value
            if      (GetTag(oFollower) == GEN_FL_Douglas) AdjustPlotFlag(GEN_FL_Douglas, PlotType_Party, TRUE);
            else if (GetTag(oFollower) == GEN_FL_Ariane)  AdjustPlotFlag(GEN_FL_Ariane, PlotType_Party, TRUE);
            else if (GetTag(oFollower) == GEN_FL_Kenneth) AdjustPlotFlag(GEN_FL_Kenneth, PlotType_Party, TRUE);
           
            break;
        }

        case EVENT_TYPE_PARTYMEMBER_DROPPED:
        {
            object oFollower = GetEventObject(ev, 0);
                
            Event_PartyMemberDropProcess(oFollower);
                
            //Adjust flag value
            if      (GetTag(oFollower) == GEN_FL_Douglas) AdjustPlotFlag(GEN_FL_Douglas, PlotType_Party, FALSE);
            else if (GetTag(oFollower) == GEN_FL_Ariane)  AdjustPlotFlag(GEN_FL_Ariane , PlotType_Party, FALSE);
            else if (GetTag(oFollower) == GEN_FL_Kenneth) AdjustPlotFlag(GEN_FL_Kenneth, PlotType_Party, FALSE);    
            
            break;
        }
    }
}