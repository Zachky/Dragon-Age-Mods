//---------------------------------------------------------------------
/*
     Adds Anaise to the party by tag, without location restriction

     usage:

        runscript anaise_addparty

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
#include "plt_gen00pt_adopted_dalish"

void main()
{
    object oMainControlFollower = GetMainControlled();
    object oCreature= GetObjectByTag(GEN_FL_Anaise);
    int FollowerState = 0;

    if(oCreature != OBJECT_INVALID){
        //Activate target creature
        WR_SetObjectActive(oCreature, TRUE);

        //Create object(creature) near warden's current location
        if(!IsObjectValid(oCreature)){
           oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"ado00fl_anaise.utc", GetLocation(OBJECT_SELF));
        }

        //Set plot flag "Recruited" to true for other feature
        WR_SetPlotFlag(PLT_GEN00PT_ADOPTED_DALISH, GEN_ANAISE_RECRUITED, TRUE);

        //Only setup follower and hire it when player does not recruit it yet
        //(Active -> follower is in the party pool and in warden's 4 man party)
        //(Avalible - > follower is in the party pool)
        FollowerState = GetFollowerState(oCreature);
        if(FollowerState != FOLLOWER_STATE_ACTIVE &&
           FollowerState != FOLLOWER_STATE_AVAILABLE){

           //Set companion attribute
           SetCompanionAttribute(oCreature, RACE_ELF, CLASS_ROGUE);

           //Hire NPC
           UT_HireFollower(oCreature);
        }

        //Set Follower to "Active" so it will be picked in the party picker.
        WR_SetFollowerState(oCreature, FOLLOWER_STATE_ACTIVE);

        //Show Party Picker
        SetPartyPickerGUIStatus(2);
        ShowPartyPickerGUI();
    }else{
        DisplayFloatyMessage(oMainControlFollower, Msg_Ado, FLOATY_MESSAGE, 0xff0000, 2.0);
    }

}
