//---------------------------------------------------------------------
/*
     Note:

        This file overwrite the original file "enigma_openstore.nss".

*/
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------
#include "utility_h"
#include "global_objects_2"

void main()
{
    object oPlayer = GetMainControlled();
    object oStore = GetObjectByTag(GEN_FL_EnMerchant);
    
    if(IsObjectValid(oStore))
    {
        OpenStore(oStore);
    }
    else
    {
        DisplayFloatyMessage(oPlayer, "Could not find valid store!", FLOATY_MESSAGE, 16777215, 20.0);
    }
} 