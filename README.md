## Dragon Age: Origin Mod --Compatibility patch for Party Picker 

### Introduction 

Here you will find all possible resource I made for "Compatibility patch for all playable companion mod"

#### * External GDA/UTC Files for Character Animation, SoundSets

![Animation_Worksheet](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Animation_Worksheet.jpg?raw=true)

1. The worksheet ("PartyPicker_Normal.xls") contain a list of the animation settings for each companion, when player select or unselected companion on the party finder, the corresponding animation will be triggered. Be ware that if you don't assign any animation to companion, they will inherit the setting from main character(Player's character itself).

![PartyPicker Worksheet](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/PartyPicker_Normal.jpg?raw=true "PartyPicker_Normal.xls")

    Column explaination:
    * ID: Index, start from 0, you must set the index correctly
    * Label: Follower's name as you wish it to appear on the party picker.
    * Tag: Follwer's tag name.

    * BlendTree: The name of BlendTree (A combined animation with soundset and special crust effect.), if you want to use other animation, set this column to empty.

    * AddAnimation & RemoveAnimation: If you use any BlendTree, add and remove column must be "673 & 675".(File "ANIM_base.xls" have a long list of animation to be used, location--".(Dragon Age installation folder)\tools\Source\2DA")

    * AddSound & RemoveSound: Basically 47 & 54, however you can try other sound as well. Code list can be found in "Sound_GUI.xls"

    * Stature: unknow xD
    * Vfx: A special crust which add to the character. Code list can be found in "VFX_Base.xls". 
    This column is a bit more tricky, since it also references the BlendTreeName value from the same file. 
    If you want to try these special visual effect, first find 2 column (ID, BlendTreeName) in "VFX_Base.xls", then enter ID into "Vfx" column and BlendTreeName into "BlendTree" column. 

    Here are some examples of Animation: 

    | ID | escription |
    | --- | --- |
    | 255 | Flying in place |
    | 277 | Dance |
    | 247 | Cast area spell |
    | 500 | VFX cast |
    | 600 | surprised |
    | 603 | praying |
    | 3063 | Arm crossed |
    | 3064 | Arm Folded |
    | 905 | Crouch start |
    | 906 | Crouch end |
    | 848 | Hand Behind back start |
    | 849 | Hand Behind back end |
    | 803 | Priest Bless start |
    | 804 | Priest Bless end |
    | 650 | Crouch Pray start |
    | 651 | Crouch Pray end |
    | 637 | Customer Brow Sing start |
    | 638 | Customer Brow Sing end |
    | 3083 | Sit Elbow start|
    | 3084 | Sit Elbow end |
    | 919 | sit ground start |
    | 920 | sit ground end |
    | 610 | (dog) resting on floor |

    Here are some examples of Visual Effect: 

    | ID | BlendTreeName | Effect |
    | --- | --- | --- |
    | 1076 | fxa_spi_aur_mht_c | Aura of Might crust |
    | 1549 | fxa_hly_imp_c | Holy Impact crust |
    | 3009 | fxc_succubus_c | Succubus crust |
    | 3054 | fxc_lotf_c | Lady of the Forest - swirling leaves |
    | 6039 | fxm_energy_up_p | Lady of the Forest pillar of light |
    | 6040 | fxm_power_in_p | Branka - power in |

| ID | BlendTreeName | Effect |
| --- | --- | --- |
| 1076 | fxa_spi_aur_mht_c | Aura of Might crust |
| 1549 | fxa_hly_imp_c | Holy Impact crust |
| 3009 | fxc_succubus_c | Succubus crust |
| 3054 | fxc_lotf_c | Lady of the Forest - swirling leaves |
| 6039 | fxm_energy_up_p | Lady of the Forest pillar of light |
| 6040 | fxm_power_in_p | Branka - power in |

''' 
PartyPicker_.xls screenshot / explaim the column 
'''

2. The worksheet ("Party_Picker_.xls") contain a list of companions, you must add the name of your companion on this sheet as well. 

'''
Party_Picker_.xls screenshot 
'''
 
#### * Script for Main Story NPC
1. Create new script under "single player" module 

![single_player](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Single_Player_Module.jpg?raw=true)

2. Copy & Past the script you want to use.

3. Export then copy the script files (.ncs,.nss) to override folder

![Export](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Export_without_dependent_resources.jpg?raw=true)

![Script_Files](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Script_Files.JPG?raw=true) 
