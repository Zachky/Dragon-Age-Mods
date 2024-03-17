//---------------------------------------------------------------------
/*
     Note:

        This file overwrite the original file "enigma_respectspawn.nss".


*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "wrappers_h"
void main()
{
    object oPlayer = GetMainControlled();
    object oMerchant = UT_GetNearestObjectByTag(oPlayer, "wrk_respec_vendor_npc"); 
    
    if (!IsObjectValid(oMerchant))
    {
        location MerchantLocation = GetLocation(GetHero());
        CreateObject(OBJECT_TYPE_CREATURE, R"wrk_respec_vendor_npc.utc", MerchantLocation);
    }
}