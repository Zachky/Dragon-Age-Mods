//---------------------------------------------------------------------
/*
     Adds Fenarel to the party by tag, without location restriction

     usage:

        runscript fenarel_addparty   
       
     Note: 
        His start conversation flag will be changed to a proper flag

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "plt_gen00pt_party"
#include "plt_bed200pt_fenarel"
#include "plt_bed000pt_main"
#include "wrappers_h"

void main()
{
    object oCreature= GetObjectByTag("bed200cr_fenarel");

    //Activate target creature
    WR_SetObjectActive(oCreature, TRUE);

    //Create object in a specific location
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"bed200cr_fenarel.utc", GetLocation(OBJECT_SELF));
    }

    //Set Flag
    WR_SetPlotFlag(PLT_BED000PT_MAIN,9,TRUE);

    //Allow the follower to gain xp
    SetLocalInt(oCreature, CREATURE_REWARD_FLAGS, 0);

    //Hire NPC
    if(GetFollowerState(oCreature) != FOLLOWER_STATE_ACTIVE){
       UT_HireFollower(oCreature);
    }

    //Show Party Picker
    SetPartyPickerGUIStatus(2);
    ShowPartyPickerGUI();

