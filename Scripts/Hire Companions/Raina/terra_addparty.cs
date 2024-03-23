//---------------------------------------------------------------------
/*
     Adds Terra to the party by tag, without location restriction

     usage:

        runscript terra_addparty

     Note:

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
#include "plt_sdt_terra"

void main()
{
    object oMainControlFollower = GetMainControlled();
    object oCreature= GetObjectByTag(GEN_FL_Terra);
    int FollowerState = 0;

    if(oCreature != OBJECT_INVALID){
        //Activate target creature
        WR_SetObjectActive(oCreature, TRUE);

        //Create object(creature) near warden's current location
        if(!IsObjectValid(oCreature)){
           oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"terra.utc", GetLocation(OBJECT_SELF));
        }

        //Adjust flag stats
        WR_SetPlotFlag(PLT_SDT_TERRA, SDT_TERRA_HIRED, TRUE);
        WR_SetPlotFlag(PLT_SDT_TERRA, SDT_TERRA_FIRED, FALSE);

        //Only setup follower and hire it when player does not recruit it yet
        //(Active -> follower is in the party pool and in warden's 4 man party)
        //(Avalible - > follower is in the party pool)
        FollowerState = GetFollowerState(oCreature);
        if(FollowerState != FOLLOWER_STATE_ACTIVE &&
           FollowerState != FOLLOWER_STATE_AVAILABLE){

           //Set companion attribute
           SetCompanionAttribute(oCreature, RACE_HUMAN, CLASS_WARRIOR);

           //Hire NPC
           UT_HireFollower(oCreature);
        }

        //Set Follower to "Active" so it will be picked in the party picker.
        WR_SetFollowerState(oCreature, FOLLOWER_STATE_ACTIVE);

        //Show Party Picker
        SetPartyPickerGUIStatus(2);
        ShowPartyPickerGUI();

    }else{
        DisplayFloatyMessage(oMainControlFollower, Msg_Raina, FLOATY_MESSAGE, 0xff0000, 2.0);
    }

}
