//---------------------------------------------------------------------
/*
     Adds Arl Eamon to the party by tag, without location restriction

     usage:

        runscript hire_arl_eamon or talk to npc to hire him.

     Note:

        1. This file overwrite the original file "hire_arl_eamon.nss" to
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
#include "plt_gen00pt_party_recruit"

void main()
{
    object oCreature= GetObjectByTag(GEN_FL_Arl_Eamon);

    //Activate target creature
    WR_SetObjectActive(oCreature, TRUE);

    //Create object(creature) near warden's current location
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"party_arl_eamon.utc", GetLocation(OBJECT_SELF));
    }

    //Set plot flag "Recruited" to true for other feature
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ARL_EAMON_RECRUITED, TRUE);

    //Set companion attribute
    SetCompanionAttribute(oCreature, RACE_HUMAN);

    //argen_SelectCoreClass(oCreature, CLASS_WIZARD);

    //Hire NPC
    if(GetFollowerState(oCreature) != FOLLOWER_STATE_ACTIVE){
       UT_HireFollower(oCreature);
    }

    //Set Follower's stats to "Active"
    WR_SetFollowerState(oCreature, FOLLOWER_STATE_ACTIVE);

    //Show Party Picker
    SetPartyPickerGUIStatus(2);
    ShowPartyPickerGUI();

}