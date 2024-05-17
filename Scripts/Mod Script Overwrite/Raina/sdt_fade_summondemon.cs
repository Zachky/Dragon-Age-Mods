#include "utility_h"
#include "global_objects_2"
#include "companion_position"

void main(){

   int nCount = Random(5);
   int i;

   for(i=0;i<=nCount;i++){
      SpawnCompanion_location(Raina, CORE_RecruitCenter, GEN_FL_Pride, R_PrideDemon );
   }

}