using MightyTextAdventure.Data.Items;
using MA = MightyTextAdventure.Service.Actions;

namespace MightyTextAdventure.Data.Places;

//public record Area(int Id, string Description, Action[] Actions, int[] Connections);
public record Area(int Id, string Description, MA.Action[]? Actions, int[]? Connections);

