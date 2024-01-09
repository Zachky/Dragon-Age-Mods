//---------------------------------------------------------------------
/*
     Adds Jory to the party by tag, without location restriction

     usage:

        runscript jory_addparty

     Note:
        His start conversation flag is changed to a proper flag

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "plt_pre100pt_generic"
#include "wrappers_h"
#include "sys_chargen_h"

void main()
{
    object oCreature= GetObjectByTag("pre100cr_jory");
    object oHero = GetHero();
    int nLevel = GetLevel(oHero);

    //Activate target creature
    WR_SetObjectActive(oCreature, TRUE);

    //Create object in a specific location
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"pre100cr_jory.utc", GetLocation(OBJECT_SELF));
    }

    //Scale up the lvl of armor and weapon base on main character's level
    ScaleEquippedItems(oCreature, nLevel);

    //Enable approval bar
    SetFollowerApprovalEnabled(oCreature, TRUE);
    SetFollowerApprovalDescription(oCreature, 371487);

    //Enable tactics present base on follower's class
    Chargen_EnableTacticsPresets(oCreature);

    //Set Conversation Flag
    WR_SetPlotFlag(PLT_PRE100PT_GENERIC,1,TRUE);

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