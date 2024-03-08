#include "utility_h"
#include "wrappers_h"
#include "events_h"

void main()
{
   object oFollower = GetObjectByTag("ado00fl_merrilyla");
   UT_FireFollower(oFollower, TRUE, TRUE);
   DestroyObject(oFollower);

}