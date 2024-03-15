//core includes here
#include "sys_ambient_h"
#include "events_h"
#include "wrappers_h"
#include "utility_h"
//core plot includes

//valeria function, plots etc, includes
#include "plt_lealion_fade_plot"
#include "plt_cir000pt_main"
#include "plt_cir300pt_fade"
#include "plt_gen00pt_party_lealion"

//constant definitions here

//function definitions here
void check_plot_changed(object oVal);
void lealion_banter();
void Handle_Lealion_In_Camp(object curArea);
void Handle_Legion_In_Camp(object curArea);
//(all this part 1)

void main()
{
    object oPC = GetHero(),me=OBJECT_SELF,ohire;
    event ev = GetCurrentEvent();
    int nEventType = GetEventType(ev);
    object oVal=UT_GetNearestObjectByTag(oPC,"gen00fl_lealion");
    object oVal1=UT_GetNearestObjectByTag(oPC,"gen00fl_legion");
    //function calls here, other important checks (part 2)
    check_plot_changed(oVal);
    //valeria banter: run this only if valeria is in active party
    if (WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY))
        lealion_banter();
     object curArea=GetArea(oPC);
    object oArea = GetObjectByTag("cam100ar_camp_plains");
    //valeria in camp
    //object oVal=UT_GetNearestObjectByTag(oPC,"gen00fl_lealion");
    if (GetTag(curArea)!="cam100ar_camp_plains" && GetTag(curArea)!="den211ar_arl_eamon_estate_1" && GetTag(curArea)!="cli300ar_redcliffe_castle" && GetTag(curArea)!="epi300ar_post_coronation" && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED))
        WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_RUNIT,TRUE);
    int runit=WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_RUNIT);
    if (runit && (GetTag(curArea)=="cam100ar_camp_plains" || GetTag(curArea)=="den211ar_arl_eamon_estate_1" || GetTag(curArea)=="cli300ar_redcliffe_castle" || GetTag(curArea)=="epi300ar_post_coronation") && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED))
        Handle_Lealion_In_Camp(curArea);
    if (GetTag(curArea)!="cam100ar_camp_plains" && GetTag(curArea)!="den211ar_arl_eamon_estate_1" && GetTag(curArea)!="cli300ar_redcliffe_castle" && GetTag(curArea)!="epi300ar_post_coronation" && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED))
        WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_RUNIT,TRUE);
    int runit1=WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_RUNIT);
    if (runit1 && (GetTag(curArea)=="cam100ar_camp_plains" || GetTag(curArea)=="den211ar_arl_eamon_estate_1" || GetTag(curArea)=="cli300ar_redcliffe_castle" || GetTag(curArea)=="epi300ar_post_coronation") && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED))
        Handle_Legion_In_Camp(curArea);
    //capture events
    switch(nEventType)
    {
        case EVENT_TYPE_WORLD_MAP_CLOSED:
        {
            int nCloseType = GetEventInteger(ev, 0);
            object oVal=UT_GetNearestObjectByTag(oPC,"gen00fl_lealion");
            WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_RUNIT,TRUE);
            if (GetTag(curArea)==GetTag(oArea) && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED) && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY))
            {
                if (!nCloseType)//0 canceled, 1 means selected a pin
                {
                    SetFollowerState(oVal, FOLLOWER_STATE_AVAILABLE);
                    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY, FALSE);
                    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_RUNIT,TRUE);
                }
                else
                {
//don't run the camp script for valeria now, set runit=0;

                    SetLocalInt(oVal, CREATURE_REWARD_FLAGS, 0);  //Allows the follower to gain XP
                    SetLocalInt(oVal, AMBIENT_SYSTEM_STATE, 0);
                    SetFollowerState(oVal, FOLLOWER_STATE_ACTIVE);  //Adds follower to the active party
                    AddCommand(oVal, CommandJumpToLocation(GetLocation(GetHero())));   //Ensures follower appears at PC's location.
                    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_RUNIT,FALSE);
                }
            }
             break;
        }

//valeria was chosen from the partypicker

        case EVENT_TYPE_PARTYMEMBER_ADDED:
        {
            object oFollower = GetEventObject(ev, 0);
            if (GetTag(oFollower) == "gen00fl_lealion")
            {
                SetImmortal(oFollower,0);
                SetLocalInt(oFollower, CREATURE_REWARD_FLAGS, 0);  //Allows the follower to gain XP
                SetLocalInt(oFollower, AMBIENT_SYSTEM_STATE, 0);
                SetFollowerState(oFollower, FOLLOWER_STATE_ACTIVE);  //Adds follower to the active party
                SetObjectActive(oFollower,1);
                AddCommand(oFollower, CommandJumpToLocation(GetLocation(GetHero())));   //Ensures follower appears at PC's location.
                WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY, TRUE);
            }
            if (GetTag(oFollower) == "gen00fl_legion")
            {
                SetImmortal(oFollower,0);
                SetLocalInt(oFollower, CREATURE_REWARD_FLAGS, 0);  //Allows the follower to gain XP
                SetLocalInt(oFollower, AMBIENT_SYSTEM_STATE, 0);
                SetFollowerState(oFollower, FOLLOWER_STATE_ACTIVE);  //Adds follower to the active party
                SetObjectActive(oFollower,1);
                AddCommand(oFollower, CommandJumpToLocation(GetLocation(GetHero())));   //Ensures follower appears at PC's location.
                WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_PARTY, TRUE);
            }  
            break;
        }

//here we have dropped valeria from the party, using the partypicker

        case EVENT_TYPE_PARTYMEMBER_DROPPED:
        {
              object oFollower = GetEventObject(ev, 0);

              if (GetTag(oFollower) == "gen00fl_lealion")
              {
                SetImmortal(oFollower,1);
                SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE);  //Adds follower to the active party

                WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY, FALSE);
              }
              if (GetTag(oFollower) == "gen00fl_legion")
              {
                SetImmortal(oFollower,1);
                SetFollowerState(oFollower, FOLLOWER_STATE_AVAILABLE);  //Adds follower to the active party

                WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_PARTY, FALSE);
              }
              break;

        }

         case EVENT_TYPE_BEGIN_TRAVEL://EVENT_TYPE_WORLD_MAP_USED:
        {
            string sSource = GetEventString(ev, 0); // the area tag the player is travelling from
            string sTarget = GetEventString(ev, 1); // the area tag the player is travelling to
            string sWPOverride = GetEventString(ev, 2);
//we pick to sent the PC clicking to the right nightmare area here
//it's funny actually, all tags for the core game nightmare companion
//map pins are given the same value "Fade_Follower". What distinguishes
//them is sWPOverride(thank god for that otherwise we'd be in trouble)
//if I remember correctly, the companion nightmare areas in the fade
//map, go 1,2,3 counterclockwise starting from the one on the left
//valeria_fade_nightmare is the name of the area for Valeria's
//nightmare, start is the waypoint tag
            if(sWPOverride=="1" && sTarget=="Fade_Follower" && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_HAS_NIGHTMARE_A))
                DoAreaTransition("cir401ar_lealion","start");
            if(sWPOverride=="2" && sTarget=="Fade_Follower" && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_HAS_NIGHTMARE_B))
                DoAreaTransition("cir401ar_lealion","start");
            if(sWPOverride=="3" && sTarget=="Fade_Follower" && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_HAS_NIGHTMARE_C))
                DoAreaTransition("cir401ar_lealion","start");
            break;
        }

//here we change the partypicker to valeria_char_stage

        case EVENT_TYPE_MODULE_GETCHARSTAGE:
        {
           SetPartyPickerStage("ldp_char_stage", "partypicker");
           break;
        }
      //.....(part 3)
    }
}

//functions here (part 4)

//check if plot flags changed and act appropriately

void check_plot_changed(object oVal)
{


    //here depending on which core flag changed, act appropriately
    //enter the fade, remove valeria from party
    if (WR_GetPlotFlag(PLT_CIR300PT_FADE,ENTER_FADE) && !WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_ENTER_FADE))
    {
        WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_ENTER_FADE,TRUE);
//if she was in the party when the demon put you to sleep, she needs
//to have a nightmare area for her
        if(WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY))
        {
            SetFollowerState(oVal, FOLLOWER_STATE_AVAILABLE);  //Adds follower to the active party
//this flag is important, it tells us valeria has indeed a nightmare
//and will be used in her dialogs(see below)
            WR_SetPlotFlag(PLT_LEALION_FADE_PLOT,LEALION_SLEEP,TRUE);
//which area to put valeria in. these module variables are set when
//first entering the fade and are positive if a companion nightmare
//area will have an actual companion in it (imagine going there with
//only 3 in the party, one area should be inactive, the value -1
//so circle through all 3 and see which one is the first available
//the core game scripts would put the other companions already in
//one of these, so we just find any available.
//so if say Rory(Ser Gilmore) and Valeria are in party, these scripts
//are disjoint and they would both behave appropriately
            int fol1=GetLocalInt(GetModule(),CIR_FADE_FOLLOWER_1);
            int fol2=GetLocalInt(GetModule(),CIR_FADE_FOLLOWER_2);
            int fol3=GetLocalInt(GetModule(),CIR_FADE_FOLLOWER_3);
            if(fol1<1)
                WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_HAS_NIGHTMARE_A,TRUE);
            else if(fol2<1)
                WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_HAS_NIGHTMARE_B,TRUE);
            else if(fol3<1)
                WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_HAS_NIGHTMARE_C,TRUE);
        }
        WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY, FALSE);//not in party anymore anyways
    }
//fighting the demon in the fade
//after the PC makes it to the inner sanctum, they get to talk to the
//demon and the battle begins. This is captured here. Notice that if
//we have talked to Valeria in the fade, she should be brought back
//to help in battle.
    if (WR_GetPlotFlag(PLT_CIR300PT_FADE,SLOTH_DEMON_ATTACKS) && !WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_SLOTH_DEMON_ATTACKS) && WR_GetPlotFlag(PLT_LEALION_FADE_PLOT, LEALION_TALKED_TO_IN_FADE))
    {
       WR_SetFollowerState(oVal, FOLLOWER_STATE_ACTIVE);
       SetImmortal(oVal,0);
       WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_SLOTH_DEMON_ATTACKS,TRUE);
       WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY,TRUE);
       SetLocalInt(oVal, CREATURE_REWARD_FLAGS, 0);  //Allows the follower to gain XP
       SetLocalInt(oVal, AMBIENT_SYSTEM_STATE, 0);
       SetObjectActive(oVal,1);
       AddCommand(oVal, CommandJumpToLocation(GetLocation(GetHero())));   //Ensures follower appears at PC's location.
    }
//demon in the fade defeated, this is captured here
//if valeria was with the PC when he first entered the fade
//she should come back to him regardless of him tlaking to her in the fade
    if (WR_GetPlotFlag(PLT_CIR300PT_FADE,SLOTH_DEMON_DEFEATED) && !WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_SLOTH_DEMON_DEFEATED) && WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_ENTER_FADE))
    {
       WR_SetFollowerState(oVal, FOLLOWER_STATE_ACTIVE);
       WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY,TRUE);
       WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION,LEALION_SLOTH_DEMON_DEFEATED,TRUE);
       SetLocalInt(oVal, CREATURE_REWARD_FLAGS, 0);  //Allows the follower to gain XP
       SetLocalInt(oVal, AMBIENT_SYSTEM_STATE, 0);
       SetObjectActive(oVal,1);
       AddCommand(oVal, CommandJumpToLocation(GetLocation(GetHero())));   //Ensures follower appears at PC's location.
    }
    object oPC=GetHero();//if NPC has not joined return
    if (!WR_GetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_HIRED))
        return;

}

void lealion_banter()
{
    if(Random(400)!=1)//1 in 400 chance to start banter
        return;
    if(GetCombatState(GetHero()))//don't start if in combat
        return;
    object [] arParty = GetPartyList(GetHero());
    int i;
    int nSize = GetArraySize(arParty);
    if(nSize<=2)//if only valeria and the PC no banter
        return;
    for(i=0;i<nSize;i++)
        if(!ClearAmbientDialogs(arParty[i]))
            return;
    object oval=UT_GetNearestObjectByTag(GetHero(),"gen00fl_lealion");
    UT_Talk(oval,GetHero(),R"lealion_random_banter.dlg");
}

void Handle_Lealion_In_Camp(object curArea)
{ 
    object oPC=GetHero();

//spawn valeria in camp if she's joined
    object oVal=UT_GetNearestObjectByTag(oPC,"gen00fl_lealion");
    location LealionLoc;

    if(GetTag(curArea)=="cam100ar_camp_plains")
        LealionLoc=Location(curArea, Vector(135.252625f, 113.905f, -0.274021f), 180.0f);

    if(GetTag(curArea)=="den211ar_arl_eamon_estate_1")
        LealionLoc=Location(curArea, Vector(9.0395, 21.0954, 0.022839), 162.4);

    if(GetTag(curArea)=="cli300ar_redcliffe_castle")
        LealionLoc=Location(curArea, Vector(3.80957,-16.221,0.022839), -130.38);

    if(GetTag(curArea)=="epi300ar_post_coronation")
        LealionLoc=Location(curArea, Vector(23.8303,4.0849,0.022839), -179.0);

    if(!IsObjectValid(oVal))
    {
        oVal=CreateObject(OBJECT_TYPE_CREATURE, R"gen00fl_lealion.utc", LealionLoc);
    }
    else
    {
        SetObjectActive(oVal,1);
        AddCommand(oVal, CommandJumpToLocation(LealionLoc));
    }
    SetFollowerState(oVal, FOLLOWER_STATE_AVAILABLE);
    if(GetTag(curArea)=="cam100ar_camp_plains")
        Ambient_Start(oVal, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, 70, AMBIENT_ANIM_FREQ_ORDERED);
    if(GetTag(curArea)=="den211ar_arl_eamon_estate_1" ||GetTag(curArea)=="cli300ar_redcliffe_castle" || GetTag(curArea)=="epi300ar_post_coronation")
        Ambient_Start(oVal, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, 56, AMBIENT_ANIM_FREQ_ORDERED);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_IN_PARTY,FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEALION_RUNIT,FALSE);
}

void Handle_Legion_In_Camp(object curArea)
{ 
    object oPC=GetHero();

//spawn valeria in camp if she's joined
    object oVal1=UT_GetNearestObjectByTag(oPC,"gen00fl_legion");
    location LegionLoc;

    if(GetTag(curArea)=="cam100ar_camp_plains")
        LegionLoc=Location(curArea, Vector(135.252625f, 113.905f, -0.274021f), 180.0f);

    if(GetTag(curArea)=="den211ar_arl_eamon_estate_1")
        LegionLoc=Location(curArea, Vector(9.0395, 21.0954, 0.022839), 162.4);

    if(GetTag(curArea)=="cli300ar_redcliffe_castle")
        LegionLoc=Location(curArea, Vector(3.80957,-16.221,0.022839), -130.38);

    if(GetTag(curArea)=="epi300ar_post_coronation")
        LegionLoc=Location(curArea, Vector(23.8303,4.0849,0.022839), -179.0);

    if(!IsObjectValid(oVal1))
    {
        oVal1=CreateObject(OBJECT_TYPE_CREATURE, R"gen00fl_legion.utc", LegionLoc);
    }
    else
    {
        SetObjectActive(oVal1,1);
        AddCommand(oVal1, CommandJumpToLocation(LegionLoc));
    }
    SetFollowerState(oVal1, FOLLOWER_STATE_AVAILABLE);
    if(GetTag(curArea)=="cam100ar_camp_plains")
        Ambient_Start(oVal1, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, 70, AMBIENT_ANIM_FREQ_ORDERED);
    if(GetTag(curArea)=="den211ar_arl_eamon_estate_1" ||GetTag(curArea)=="cli300ar_redcliffe_castle" || GetTag(curArea)=="epi300ar_post_coronation")
        Ambient_Start(oVal1, AMBIENT_SYSTEM_ENABLED, AMBIENT_MOVE_NONE, AMBIENT_MOVE_PREFIX_NONE, 56, AMBIENT_ANIM_FREQ_ORDERED);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_IN_PARTY,FALSE);
    WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_RUNIT,FALSE);
}