/*
     Remove Daveth from party

     usage:

        runscript daveth_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "wrappers_h"
#include "events_h"

void main()
{
   object oFollower = GetObjectByTag("pre100cr_daveth");
   UT_FireFollower(oFollower, TRUE, TRUE);
   DestroyObject(oFollower);

}