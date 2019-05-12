# rpgMapSim

The purpose of this program is to build an rpg map for use with
games such as dungeons and dragons, or offsets of D&D.

Current status:
the current version of this application creates a 
user defined number of rooms, then generates a maze
around the rooms. Once the maze is created, it opens
a single door along the edge of each room. (randomly selected)
The dead ends are then removed, to create a dungeon.

Todo:
- reduce corridors that are very snake-like
- add another form that displays a fog of war version of the map
- add functionality to other user controls on map creation form
- save / open maps
- make the map look better
- add creature generation that will pull from a list of creatures 
  dependant on the dungeon motif, and place them randomly in both
  corridors and rooms. Creature generation will be based on how long
  the DM wants the dungeon to last.
