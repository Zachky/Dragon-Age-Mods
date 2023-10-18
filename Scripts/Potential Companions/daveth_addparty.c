//---------------------------------------------------------------------
/*
     Adds Daveth to the party by tag, without location restriction

     usage:

        runscript daveth_addparty 
        
     Note:
        Daveth doesnt need to set conversation flag, 
        his conversation started at good flag without any game-breaking or fixed-location option

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

    //Hire NPC
    if(GetFollowerState(oCreature) != FOLLOWER_STATE_ACTIVE){
       UT_HireFollower(oCreature);
    }

    //Show Party Picker
    SetPartyPickerGUIStatus(2);
    ShowPartyPickerGUI();

}