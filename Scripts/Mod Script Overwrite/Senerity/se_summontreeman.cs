#include "utility_h"
#include "global_objects_2"
#include "companion_position"

void main(){

   int nCount = Random(5);
   int i;

   for(i=0;i<=nCount;i++){
      CreateObject(OBJECT_TYPE_CREATURE, R_Sylvan, GetLocation(OBJECT_SELF));
   }

}