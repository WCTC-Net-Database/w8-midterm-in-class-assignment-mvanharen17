### Week 8 Assignment: Midterm In-Class - Improving Monster Attacks

---

#### Objective:
- Add two new monsters to the game.
- Create a new room and add the new monsters to it.
- Update to allow selecting which monster to attack.
- Ensure that monster is removed from the room after they are attacked/killed.

#### Instructions:
1. **Add a new room:**
	- Create two new rooms in the `RoomFactory` class.
	- Tip: Use the `SetupRooms` method in the `GameEngine` class to add the new room.
	- Tip: The new room should be connected to an existing room.  Be sure to carefully update `SetupRooms`
	
2. **Add New Monsters:**
	- Create two new monster classes (e.g., `Rat`, `Spider`) that inherits from `CharacterBase`
	- Tip: Be sure to add the new monsters to the `input.json` file.
	- Hint: These new monsters can be similar to the existing monsters (i.e. `Goblin`), but with different names and stats.

3. **Update the `LoadMonsters` Method:**
	- Modify the `LoadMonsters` method in `GameEngine.cs` to add the new monster to a room.

4. **Modify the `AttackCharacter` Method:**
	- Update the `AttackCharacter` method in `GameEngine.cs` to allow the player to select which monster to attack.
	- Display a list of monsters in the current room and prompt the player to choose one.

5. **Remove Monster After Attack:**
	- Ensure that the monster is removed from the room after it is attacked/killed.
	- Tip: Modify the `Attack` method in `CharacterBase.cs` to handle the removal of the monster.

#### General Tips:
- Ensure that the `OutputManager` is used to provide feedback to the player during the game.
- Test your changes thoroughly to ensure that the game behaves as expected.
- Good luck, and remember to think through the problem before coding!

#### OutputManager.cs:
- **Using `OutputManager` for Feedback:**
	- Use the `Write` and `WriteLine` methods to add messages to the output buffer. For example:
	```csharp
	_outputManager.WriteLine("This is a message.", ConsoleColor.Green);
	```
	- Use different `ConsoleColor` values to differentiate types of messages (e.g., `ConsoleColor.Red` for errors, `ConsoleColor.Green` for success messages).
	- Call the `Display` method to print all buffered messages to the console. This is useful for batching output and reducing flicker:
	```csharp
	_outputManager.Display();
	```
	- Use the `Clear` method to clear the console and the output buffer if needed:
	```csharp
	_outputManager.Clear();
	```


