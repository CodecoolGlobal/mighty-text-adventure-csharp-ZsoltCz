using MightyTextAdventure.Data.Items;
using MA = MightyTextAdventure.Service.Actions;

namespace MightyTextAdventure.Data.Places;

public record Area(int Id, string Description, List<MA.Action> Actions, int[] Connections);
