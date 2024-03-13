//---------------------------------------------------------------------
/*
     Adds Martin to the party by tag, without location restriction

     usage:

        runscript ldp_martin_hire or talk to npc to hire her.

     Note:

        1. This file overwrite the original file "ldp_martin_hire.nss" to
        fix old problem.

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

//Import core module
#include "utility_h"
#include "sys_chargen_h"
#include "p_utility"
#include "global_objects_2"

//Import plot module
#include "plt_gen00pt_party_martin"

void main()
{
    object oCreature= GetObjectByTag(GEN_FL_Martin);
    int FollowerState = 0;

    //Activate target creature
    WR_SetObjectActive(oCreature, TRUE);

    //Create object(creature) near warden's current location
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"gen00fl_martin.utc", GetLocation(OBJECT_SELF));
    }

    /*-------------------------------------------------------------------------
      Set plot flag "Recruited" to true for other feature.
      Original Plot file has created, hired and fired flag. To ensure other
      feature goes as it should be, set these flags with appropriate value.
    ---------------------------------------------------------------------------*/
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_CREATED, TRUE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_HIRED, TRUE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_MARTIN, GEN_MARTIN_FIRED, FALSE);

    //Only setup follower and hire it when player does not recruit it yet
    //(Active -> follower is in the party pool and in warden's 4 man party)
    //(Avalible - > follower is in the party pool)
    FollowerState = GetFollowerState(oCreature);
    if(FollowerState != FOLLOWER_STATE_ACTIVE &&
       FollowerState != FOLLOWER_STATE_AVAILABLE){

       //Set companion attribute
       SetCompanionAttribute(oCreature, RACE_HUMAN, CLASS_ARCANE_WARRIOR);

       //Hire NPC
       UT_HireFollower(oCreature);
    }

    //Set Follower to "Active" so it will be picked in the party picker.
    WR_SetFollowerState(oCreature, FOLLOWER_STATE_ACTIVE);

    //Show Party Picker
    SetPartyPickerGUIStatus(2);
    ShowPartyPickerGUI();

}