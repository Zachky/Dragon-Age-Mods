//---------------------------------------------------------------------
/*
     Adds Marukhan to the party by tag, without location restriction

     usage:

        runscript marukhan_addparty

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
#include "plt_dt_act1"

int SpawnFollower(){

    object oCreature= GetObjectByTag(GEN_FL_Marukhan);
    int FollowerState = 0;
    int result = TRUE;

    //Check if player install the mod by creating a creature that only exist in the target mod.
    object oTestCreature = CreateObject(OBJECT_TYPE_CREATURE, R"dt_fol_dragon_v.utc", GetLocation(OBJECT_SELF));
    if(!IsObjectValid(oTestCreature)){
       DestroyObject(oTestCreature);
       return FALSE;
    }
    DestroyObject(oTestCreature);

    //Create follower next to Warden if follower does not exist
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"dt_fol_marukhan.utc", GetLocation(OBJECT_SELF));
    }

    //Enable the target creature(Enabled object will be visible to player)
    WR_SetObjectActive(oCreature, TRUE);

    //Set plot flag "Recruited" to true for other feature
    WR_SetPlotFlag(PLT_DT_ACT1, GEN_MARUKHAN_RECRUITED, TRUE);

    //Only setup follower and hire it when player does not recruit it yet
    //(Active -> follower is in the party pool and in warden's 4 man party)
    //(Avalible - > follower is in the party pool)
    FollowerState = GetFollowerState(oCreature);
    if(FollowerState != FOLLOWER_STATE_ACTIVE &&
       FollowerState != FOLLOWER_STATE_AVAILABLE){

       //Set companion attribute
       SetCompanionAttribute(oCreature, RACE_BEAST, CLASS_ROGUE);

       //Hire NPC
       UT_HireFollower(oCreature);
    }

    //Set Follower to "Active" so it will be picked in the party picker.
    WR_SetFollowerState(oCreature, FOLLOWER_STATE_ACTIVE);

    return result;

}

void main()
{
    int Result = SpawnFollower();
    object oMainControlFollower = GetMainControlled();

    if(Result){

       //Show Party Picker
       SetPartyPickerGUIStatus(2);
       ShowPartyPickerGUI();

    }else{
       DisplayFloatyMessage(oMainControlFollower, Msg_DarkTime, FLOATY_MESSAGE, 0xff0000, 2.0);
    }

}