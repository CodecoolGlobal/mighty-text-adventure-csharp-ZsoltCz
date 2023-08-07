using MightyTextAdventure.Data.Items;

namespace MightyTextAdventure.Data.Places;

public record Area(int Id, string Description, Action[] Actions, int[] Connections, Inventory Items);
