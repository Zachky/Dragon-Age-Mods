/*
     Remove Legion from party

     usage:

        runscript legion_fire

     Note:

     */
//---------------------------------------------------------------------
// Zach Lin
//---------------------------------------------------------------------

#include "utility_h"
#include "global_objects_2"
#include "companion_position"

//Import plot module
#include "plt_gen00pt_party_lealion"

void main()
{
   object oFollower = GetObjectByTag(GEN_FL_Legion);
   int nCount = Random(2);
   int i;

   //Get current area tag
   string MapTag    = GetTag(GetAreaFromLocation(GetLocation(GetHero())));

   //Fire Companion
   UT_FireFollower(oFollower, TRUE, TRUE);

   /*-------------------------------------------------------------------------
      Set plot flag "Recruited" to true for other feature.
      Original Plot file has created, hired and fired flag. To ensure other
      feature goes as it should be, set these flags with appropriate value.
   ---------------------------------------------------------------------------*/
   WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_CREATED, FALSE);
   WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_HIRED, FALSE);
   WR_SetPlotFlag(PLT_GEN00PT_PARTY_LEALION, GEN_LEGION_FIRED, TRUE);

   DestroyObject(oFollower);

   if(MapTag == CORE_RecruitCenter){

      //Spawn a pair of dragon to punish warden for layoff the dog
      SpawnCompanion_location(Lealion, CORE_RecruitCenter, FadeBoss_position_1, R_lealion_boss_dragon);
      SpawnCompanion_location(Lealion, CORE_RecruitCenter, FadeBoss_position_2, R_lealion_boss_pride);
      SpawnCompanion_location(Lealion, CORE_RecruitCenter, FadeBoss_position_3, R_lealion_boss_dragon);

      //Respawn legion at recruitment center immediately if warden is also in this map.
      SpawnCompanion_location(Lealion, MapTag, GEN_FL_Legion, R_Legion );

   }else{

      //Spawn a pair of dragon at warden's location.
      CreateObject(OBJECT_TYPE_CREATURE, R_lealion_boss_dragon, GetLocation(OBJECT_SELF));
      CreateObject(OBJECT_TYPE_CREATURE, R_lealion_boss_dragon, GetLocation(GetHero()));

   }

}