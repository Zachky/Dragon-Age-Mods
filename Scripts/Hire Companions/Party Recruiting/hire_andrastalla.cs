//---------------------------------------------------------------------
/*
     Adds Andrastalla to the party by tag, without location restriction

     usage:

        runscript hire_andrastalla or talk to npc to hire her.  
        
     Note:
        
        1. This file overwrite the original file "hire_andrastalla.nss" to 
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
    object oCreature= GetObjectByTag(GEN_FL_Andrastalla);
    
    //Activate target creature
    WR_SetObjectActive(oCreature, TRUE); 
   
    //Create object(creature) near warden's current location
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R"party_andrastalla.utc", GetLocation(OBJECT_SELF));
    }
    
    //Set plot flag "Recruited" to true for other feature
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_RECRUIT, GEN_ANDRASTALLA_RECRUITED, TRUE);
    
    //Set companion attribute 
    SetCompanionAttribute(oCreature, RACE_SPIRIT);   
    
    //argen_SelectCoreClass(oCreature, CLASS_WIZARD);

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
