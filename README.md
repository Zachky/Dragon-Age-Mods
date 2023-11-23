# Dragon Age: Origin Mod --Compatibility patch for Party Picker 

## Introduction 

![Party_Picker_Stage](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Party_Picker_Stage.jpg?raw=true "Party Picker Stage")

To deploy this mod in your dev environment: 

    Step 1: Download oth999d_background_layout.rar in Layout folder, unpack and move content to override folder

    Step 2: Download Party_Picker_20231124.dadbdata in Builder-To-Builder_Source_File folder, unpack then import it into DragonAge Toolset.


## External GDA Files for Character Animation

![Animation_Worksheet](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Animation_Worksheet.jpg?raw=true)

You can download the copy of Party Picker xls files in the folder "M2DA_Worksheet"

1. The worksheet ("PartyPicker_Normal.xls") contain a list of the animation settings for each companion, when player select or unselect companion on the party finder, the corresponding animation will be triggered. Be ware that if you don't assign any animation to companion, they will inherit the setting from main character(Player's character itself).

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

| ID | Description | ID | Description |
| --- | --- | --- | --- |
| 255 | Flying in place | 277 | Dance |
| 247 | Cast area spell | 500 | VFX cast |
| 600 | surprised | 603 | praying |
| 3063 | Arm crossed | 3064 | Arm Folded |
| 905 | Crouch start | 906 | Crouch end |
| 848 | Hand Behind back start | 849 | Hand Behind back end |
| 803 | Priest Bless start | 804 | Priest Bless end |
| 650 | Crouch Pray start | 651 | Crouch Pray end |
| 637 | Customer Brow Sing start | 638 | Customer Brow Sing end |
| 3083 | Sit Elbow start| 3084 | Sit Elbow end |
| 919 | sit ground start | 920 | sit ground end |
| 610 | (dog) resting on floor | 607 | Head bow |

Here are some examples of Visual Effect: 

| ID | BlendTreeName | Effect |
| --- | --- | --- |
| 1076 | fxa_spi_aur_mht_c | Aura of Might crust |
| 1549 | fxa_hly_imp_c | Holy Impact crust |
| 3009 | fxc_succubus_c | Succubus crust |
| 3054 | fxc_lotf_c | Lady of the Forest - swirling leaves |
| 6039 | fxm_energy_up_p | Lady of the Forest pillar of light |
| 6040 | fxm_power_in_p | Branka - power in |



2. The worksheet ("Party_Picker_.xls") contain a list of companions, each time you add a new companion in the previous worksheet, you have to add a new row in this worksheet as well.

![Party_Picker Worksheet](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Party_Picker_Normal.jpg?raw=true "Party_Picker_Normal.xls")

    Column explaination:

    * ID: Index, start from 0, you must set the index correctly
    * Tag: Follwer's tag name.
    * Portrait: Must be "INVALID COLUMN"



3. After finishing both partypicker.xls and party_picker.xls, drag them to ExcelProcessor.exe to generate GDA file, then move it to overrite folder. You can download ExcelProcessor from this github(in "Support_Tool")


## SoundSet for companion 

You can find this option in the character panel. However if you want to assign a soundset to follower in other mod which you dont have builder version to edit, you can add a new row in character's UTC file.

Use "Andrastalla" from "Party Recruiting_v1.0" as example: 

Step 1: Find the soundset code from the character list in core module(Single Player)

![Character_List](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Character_List.jpg?raw=true "Character List")

Step 2: Add a new row with name "SoundSet", type "RESREF" and value with the code you want to use.

![SoundSet](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/SoundSet.jpg?raw=true "SoundSet")


## Script for Main Story NPC
1. Create new script under "single player" module 

![single_player](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Single_Player_Module.jpg?raw=true)

2. Copy & Past the script you want to use.

3. Export then copy the script files (.ncs,.nss) to override folder

![Export](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Export_without_dependent_resources.jpg?raw=true)

![Script_Files](https://github.com/Zachky/Dragon-Age-Mods/blob/main/Image_Library/Hire_Companion/Script_Files.JPG?raw=true) 
