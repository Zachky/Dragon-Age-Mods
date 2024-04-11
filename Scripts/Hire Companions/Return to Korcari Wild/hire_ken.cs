//---------------------------------------------------------------------
/*
     Adds Kenneth to the party by tag, without location restriction

     usage:

        runscript hire_ken

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
#include "plt_gen00pt_return_to_kw"

int SpawnFollower(){

    object oCreature= GetObjectByTag(GEN_FL_Kenneth);
    int FollowerState = 0;
    int result = TRUE;
    string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

    //Check if player install the mod
    if(!IsModInstall(Return_to_KW)){return FALSE;}

    //Create follower next to Warden if follower does not exist
    if(!IsObjectValid(oCreature)){
       oCreature = CreateObject(OBJECT_TYPE_CREATURE, R_Serkenneth, GetLocation(OBJECT_SELF));
    }

    //Enable the target creature(Enabled object will be visible to player)
    WR_SetObjectActive(oCreature, TRUE);

    //Set plot flag "Recruited" to true for other feature
    WR_SetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_RECRUITED, TRUE);

    //Set this flag true if player conscript Ser Kenneth at mod's map.
    //When player fire Ser Kenneth, he will respawn at Recruit Center instead.
    if(MapTag == RTKW_Korcari){
        WR_SetPlotFlag(PLT_GEN00PT_RETURN_TO_KW, GEN_KENNETH_IS_NOT_VIRGIN, FALSE);
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
       DisplayFloatyMessage(oMainControlFollower, Msg_RTKW, FLOATY_MESSAGE, 0xff0000, 2.0);
    }

}