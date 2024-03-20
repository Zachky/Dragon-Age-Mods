//---------------------------------------------------------------------
/*
     Note:

        This file override old sdt_terra_module file with advanced party 
        member add and drop function.

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "approval_h"
#include "p_utility"
#include "global_objects_2"

void main()
{
  event ev = GetCurrentEvent();
  int nEventType = GetEventType(ev);
  switch(nEventType)
  {
    /*-----------------------------------------------------------------
     Sent by: The engine
     When: Player open party picker
    ------------------------------------------------------------------*/
    case EVENT_TYPE_MODULE_GETCHARSTAGE:
    {
      SetPartyPickerStage("sdt_terra_char_stage", "partypicker");
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
      
      if (GetTag(oFollower) == GEN_FL_Terra){
         AdjustPlotFlag(GEN_FL_Terra, PlotType_Party, TRUE, TRUE);
      }
      break;
    }
    
    //------------------------------------------------------------------
    // Sent by: The engine
    // When: Fires when player drop companion from the party
    //------------------------------------------------------------------
    case EVENT_TYPE_PARTYMEMBER_DROPPED:
    {
      object oFollower = GetEventObject(ev, 0);
      
      Event_PartyMemberDropProcess(oFollower);
      
      if (GetTag(oFollower) == GEN_FL_Terra) {
         AdjustPlotFlag(GEN_FL_Terra, PlotType_Party, FALSE, TRUE);
      }
      break;
    } 
    
    //------------------------------------------------------------------
    // Sent by: The engine
    // When: Fires when player give gift to companion
    //------------------------------------------------------------------  
    case EVENT_TYPE_MODULE_HANDLE_GIFT:
    {
      object oFollower = GetEventObject(ev, 0);
      object oControlled = GetMainControlled();
      int nFollower = 37325739;
      if (GetTag(oFollower) == GEN_FL_Terra){
         Approval_ChangeApproval(nFollower, 5);
         AdjustFollowerApproval(oControlled, -5, TRUE);
      }
      break;
    }
  }
}