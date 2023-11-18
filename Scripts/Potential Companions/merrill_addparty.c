//---------------------------------------------------------------------
// merrill_addparty
//---------------------------------------------------------------------
/*
     Adds Merrill to the party by tag, without location restriction

     usage:

        runscript merrill_addparty
     
     Note: 
        Her start conversation flag is changed to a proper flag
     
     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "wrappers_h"
#include "plt_gen00pt_party"
#include "plt_bed200pt_merrill"

void main()
{
    object oCreature= GetObjectByTag("bed200cr_merrill");

    //Activate target creature
    WR_SetObjectActive(oCreature, TRUE);

    //Create object in a specific location
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"bed200cr_merrill.utc", GetLocation(OBJECT_SELF));
    }

    //Set conversation Flag
    WR_SetPlotFlag(PLT_BED200PT_MERRILL,0,TRUE);

    //Allow the follower to gain xp
    SetLocalInt(oCreature, CREATURE_REWARD_FLAGS, 0);

   //Cancel Auto level up
    SetAutoLevelUp(oCreature,0);

    //Hire NPC
    if(GetFollowerState(oCreature) != FOLLOWER_STATE_ACTIVE){
       UT_HireFollower(oCreature);
    }

    //Set Follower to the active party(Important)
    WR_SetFollowerState(oCreature, FOLLOWER_STATE_ACTIVE);
     
    //Show Party Picker
    SetPartyPickerGUIStatus(2);
    ShowPartyPickerGUI();

}
