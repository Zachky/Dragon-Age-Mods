//---------------------------------------------------------------------
/*
     Note:

        This file override old sda_end_encounter file to retain its original
        feature with advanced code.
        
        Original feature:
        
        1. Add party member back to warden's team at the end of the Amazon encounter.
        2. Amazon women leave the area.
*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "camp_functions_h"
#include "party_h"
#include "wrappers_h" 

#include "global_objects_2"
#include "p_utility"

#include "plt_sdt_terra"    

void main()
{
     object oPC = GetHero(); 
     object oFollower; 
     int 
           
     //Clear the blood on warden's body. (Gore level to 0)       
     SetCreatureGoreLevel(oPC,0.00);
     
     //Restore party member
     if(Party_Member1 != "") ReSummonPartyMember(Party_Member1);
     if(Party_Member2 != "") ReSummonPartyMember(Party_Member2);
     if(Party_Member3 != "") ReSummonPartyMember(Party_Member3);
     
     //HealPartyMembers
     HealPartyMembers(TRUE, TRUE);
     Injury_RemoveAllInjuriesFromParty();
     
     
            
            

            // Lose the Amazons
            object oAmazon = GetObjectByTag("amazon_01");
            WR_SetObjectActive(oAmazon, FALSE);
            oAmazon = GetObjectByTag("amazon_02");
            WR_SetObjectActive(oAmazon, FALSE);
            oAmazon = GetObjectByTag("amazon_03");
            WR_SetObjectActive(oAmazon, FALSE);
            oAmazon = GetObjectByTag("amazon_04");
            WR_SetObjectActive(oAmazon, FALSE);
            oAmazon = GetObjectByTag("amazon_05");
            WR_SetObjectActive(oAmazon, FALSE);
            oAmazon = GetObjectByTag("amazon_06");
            WR_SetObjectActive(oAmazon, FALSE);
            oAmazon = GetObjectByTag("amazon_07");
            WR_SetObjectActive(oAmazon, FALSE);
            oAmazon = GetObjectByTag("amazon_08");
            WR_SetObjectActive(oAmazon, FALSE);
            oAmazon = GetObjectByTag("raina");
            WR_SetObjectActive(oAmazon, FALSE);
            // And the fire
            object oFire = GetObjectByTag("cli000ip_fire_small");
            WR_SetObjectActive(oFire, FALSE);
            // Now spawn Terra, as a party member
            object oTerra = GetObjectByTag("terra");
            if (!IsObjectValid(oTerra)) // Only spawn if Terra not already present
            {
            location lTerra = GetLocation(GetObjectByTag("spider_challenge"));
            oTerra = CreateObject(OBJECT_TYPE_CREATURE,R"terra.utc",lTerra);
            }
            SetCreatureProperty(oTerra,PROPERTY_SIMPLE_CURRENT_CLASS,IntToFloat(CLASS_RANGER),PROPERTY_VALUE_BASE);
            WR_SetPlotFlag(PLT_SDT_TERRA, SDT_TERRA_HIRED, TRUE, TRUE);
}