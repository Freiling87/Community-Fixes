#		Unfixed Vanilla Bugs

##			Level Editor
- ExtraVarString is not properly cleared out when deselecting containers. This copies the contained item name string into a non-container object, causing it to drop as a bugged Water Pistol with an "E_" name. Note that E_ drops are cancelled by the No More Bad Drops fix, so deactivate that if you work on this.

##			Map Generation
- Exclude Vanilla Chunks button doesn't work. Vanilla content always shows up.
- When you have a level with placed chunks and random chunks, some of the placed chunks are added to the random selection pool.
- Cyan_Light, re Confiscation/Deportation Centers: "it'll always spawn the largest size available, so if you put a single 1x2 of one type that then one chunk will show up every single time. 2x2s are weirder, it'll spawn a 2x2 but for some reason adds a chance to spawn additional centers of the same type, which can be of any size."


##			NPCs
- NPCs equipped with Ghost Gibber refuse to use it on ghosts
- "Remove Slave Helmet with Wrench" and Guard Duty BQ should not be limited by Vocally Challenged. Other BQs get the pass so it would make sense. And you don't need to communicate to remove a helmet, but that's a judgment call.

##			Objects
- If you use a Hacking Device on a Clone Machine while at your follower limit, it will waste the item without giving you the clone.
- NPCs often do not path properly to exit elevators in custom chunks, depending on floor ownership. Since they'll charge blindly out of prisons when you free them, they should charge blindly into owned tiles to reach the elevator.

##			Misc.
- Map seed set with keyboard input from home base