//---------------------------------------------------------------------
/*
     Adds Merrill to the party by tag, without location restriction

     usage:

        runscript merrill_addparty

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
#include "plt_gen00pt_main_story"
#include "plt_bed000pt_main"
#include "plt_bed200pt_merrill"

int SpawnFollower(){

    object oCreature= GetObjectByTag(GEN_FL_Merrill);
    int FollowerState = 0;
    int result = TRUE;

    //Check if player install the mod
    //if(!IsModInstall(Adopted_Dalish)){return FALSE;}

    //Create follower next to Warden if follower does not exist
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R_Merrill, GetLocation(OBJECT_SELF));
    }

    //Enable the target creature(Enabled object will be visible to player)
    WR_SetObjectActive(oCreature, TRUE);

    //Set Conversation Flag
    WR_SetPlotFlag(PLT_BED000PT_MAIN, BED_MAIN_KEEPER_AT_ARAVEL, FALSE);
    WR_SetPlotFlag(PLT_BED200PT_MERRILL, BED_MERRILL_IN_PARTY, TRUE);

    //Set plot flag "Recruited" to true for other feature
    WR_SetPlotFlag(PLT_GEN00PT_MAIN_STORY, GEN_MERRILL_RECRUITED, TRUE);

    //Only setup follower and hire it when player does not recruit it yet
    //(Active -> follower is in the party pool and in warden's 4 man party)
    //(Avalible - > follower is in the party pool)
    FollowerState = GetFollowerState(oCreature);
    if(FollowerState != FOLLOWER_STATE_ACTIVE &&
       FollowerState != FOLLOWER_STATE_AVAILABLE){

       //Set companion attribute
       SetCompanionAttribute(oCreature, RACE_ELF, Custom_Class);

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

    //Show Party Picker
    SetPartyPickerGUIStatus(2);
    ShowPartyPickerGUI();
}
