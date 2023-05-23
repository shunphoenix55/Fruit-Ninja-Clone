========================================================================================================
Thank you for choosing EasyImport!

EasyImport is due to save your time from modifying settings for massive textures and models. Especially for 3D artists.

In order to keep this tool simple and efficient, it only contains major parameters those need to be modified more frequently when importing textures and models.
========================================================================================================
Quik Start:

1.Import EasyImport package into your Unity project.

2.Select "Menu -> Window -> EasyImport" to open EasyImport window.

3.Enjoy!
========================================================================================================
Features:

1.Change import settings for all textures/models in project or the ones in the folder you specified.

2.Override default import settings when importing new textures/models.

3.Assign textures for materials if the textures's names are matched with materials in certain rules.

4.Change texture type automatically according to the names of texture files.
========================================================================================================
How to use it:

1.Change settings just like when you doing on a inspector window.

2.If you want to apply the settings to the assets in a same folder, assign a folder into "Target" slot, then click "Apply".

3.If you want to change all the assets in your project, just click "Apply all".

4.If you want to override default settings for new assets, check "Auto".

5.Assign Textures:

1).This is mainly designed for Unity Standard shader. It works with other shaders those share same texture channels with Standard shader.

2).Example:

Say there's a material names "newMaterial", and a texture names "newMaterial_Albedo", after you click "Apply" or "Apply all" button, EasyImport will fill the "Albedo" Channel of "newMaterial" with "newMaterial_Albedo".

3).By default, there're some pre-defined suffix(_xxx) optionals for each texture channel of Standard shader, you can change or extend the options by editing a "MapTail" data.

4).To create a "MapTail" data, right click on anywhere in project window, or select "Asset" on main menu, then select "Create -> EasyImport -> MapTail". Or just click the "New" button on EasyImport window right beside the "Suffixes Extension" slot when it's empty.

5).To use a "MapTail" data, drag and drop it into the "Suffixes Extension" slot on "Material" tag. Click the "Edit" button beside it to quickly select the data, so you can edit it.
========================================================================================================
Notes:

1.To ensure "texture type by name" and "assign texture" work correctly, you need to name your textures with certain rules. You can find the rules and examples on EasyImport window.

2."texture type by name" detect only the head of a texture's name.

3.Clicking "Apply" or "Apply all" button will only apply settings in current tag(Texture/Model/Material).