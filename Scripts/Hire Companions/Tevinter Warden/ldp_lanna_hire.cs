//---------------------------------------------------------------------
/*
     Adds Lanna to the party by tag, without location restriction

     usage:

        runscript ldp_lanna_hire or talk to npc to hire her.

     Note:

        1. This file overwrite the original file "ldp_lanna_hire.nss" to
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
#include "plt_gen00pt_party_lanna"

int SpawnFollower(){

    object oCreature= GetObjectByTag(GEN_FL_Lanna);
    int FollowerState = 0;
    int result = TRUE;
    string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

    //Check if player install the mod
    if(!IsModInstall(Tevinter_Warden)){return FALSE;}

    //Create follower next to Warden if follower does not exist
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R_Lanna, GetLocation(OBJECT_SELF));
    }

    //Enable the target creature(Enabled object will be visible to player)
    WR_SetObjectActive(oCreature, TRUE);

    //Modify flag value
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LANNA, GEN_LANNA_CREATED, TRUE); //if false, a lanna will spawn at lothering instead
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LANNA, GEN_LANNA_HIRED, TRUE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LANNA, GEN_LANNA_FIRED, FALSE);

    //Set flag "Is_not_virgin" to true if player conscript Lanna at mod's map.
    //When player fire Lanna, she will respawn at Recruit Center instead.
    if(MapTag == TW_Lothering){
       WR_SetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_ARIANE_IS_NOT_VIRGIN, TRUE);
    }

    //Only setup follower and hire it when player does not recruit it yet
    //(Active -> follower is in the party pool and in warden's 4 man party)
    //(Avalible - > follower is in the party pool)
    FollowerState = GetFollowerState(oCreature);
    if(FollowerState != FOLLOWER_STATE_ACTIVE &&
       FollowerState != FOLLOWER_STATE_AVAILABLE){

       //Set companion attribute
       SetCompanionAttribute(oCreature, RACE_HUMAN, Custom_Class);

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
       DisplayFloatyMessage(oMainControlFollower, Msg_TWarden, FLOATY_MESSAGE, 0xff0000, 2.0);
    }

}