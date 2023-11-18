//---------------------------------------------------------------------
/*
     Adds Daveth to the party by tag, without location restriction

     usage:

        runscript daveth_addparty 
        
     Note:
        
        Changing his conversation flag before the end of joining story will cause trouble because 
        his flag is key part for main story, hence I will not change his flag. 

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------
                             
//Import core module
#include "utility_h"
#include "plt_gen00pt_party"

void main()
{
    object oCreature= GetObjectByTag("pre100cr_daveth");

    //Activate target creature
    WR_SetObjectActive(oCreature, TRUE);

    //Create object(creature) near warden's current location
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"pre100cr_daveth.utc", GetLocation(OBJECT_SELF));
    }

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