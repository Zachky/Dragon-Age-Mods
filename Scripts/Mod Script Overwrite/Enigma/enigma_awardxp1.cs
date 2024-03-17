//---------------------------------------------------------------------
/*
     Note:

        This file overwrite the original file "enigma_awardxp1.nss". 
        Now it reward random exp between 1~10000 to warden.

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------
#include "sys_rewards_h"

void main()
{   
    object oHero = GetHero(); 
    int iExp = Random(10000);
    
    RewardXP(oHero, iExp, FALSE, FALSE);
}