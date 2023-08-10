using MightyTextAdventure.Data.Items;
using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Service.Actions;
using Action = MightyTextAdventure.Service.Actions.Action;

namespace MightyTextAdventure.Service.Constructor_classes;

public class AreaConstructor
{
    private static readonly Item CarKey = new Item("Car keys", "The keys for your car");

    public Area[] Areas { get; }

    public AreaConstructor()
    {
        Areas = new Area[]
        {
            CreateArea0(),
            CreateArea1(),
            CreateArea2(),
            CreateArea3(),
            CreateArea4(),
            CreateArea5(),
        };
    }
    private static Area CreateArea0()
    {
        var enterCar = new GameEndingAction("Enter the car and drive away.", new[] { "enter car", "leave", "drive" },
            "You found your car keys and left the creepy forest. Congratulations!");
        var area0Actions = new List<Action>
        {
            new Move("Go into the cave", new string[] { "enter", "go", "enter cave", "go into cave" }, "You go into the dark cave.", 1),
            new GiveItemAction("Open car with keys", new []{"open car", "enter car", "car"}, "You use your keys to open the car.", "You don't have the keys!", CarKey, enterCar),
            new GameEndingAction("Keep walking", new []{"walk"}, "You leave your car behind and walk home. Thank you for protecting the environment!")
        };
        return new Area(0, "You are on a road. Your car keys are missing. There is a dark cave in front of you.", area0Actions, new int[] { 1 });
    }

    private static Area CreateArea1()
    {
        var pushButton = new Move("Go into the right tunnel", new[] { "right", "go right", "r" }, "You go into the right tunnel.", 2);
        var seeButton = new Discover("Push the button", new[] { "push", "button", "push button", "activate" },
            "The wall on the right begins to move, revealing a new passage!", pushButton);
        var area1Actions = new List<Action>
        {
            //Alagút elrejtése, gombbal
            new Move("Exit cave", new[] { "back", "go back", "b", "exit", "exit cave" }, "You exit the cave.", 0),
            new Discover("Examine Rug", new[] {"examine", "examine rug", "rug", "carpet", "examine carpet"}, "You see an indentation under the rug, inside is a stone button surrounded by red dust.", seeButton),
            new Inspect("Look at odd-looking dust", new[]{"look", "dust", "look at dust", "examine dust"}, "The sparkling red dust seems to go from the rug to the right wall, you figure it's best not to disturb it."),
            new Inspect("Catch bug", new[] {"catch", "bug", "catch bug"}, "You catch the bug for only a second, but it escapes from you clutches. An error message still lingers in your head."),
            new Inspect("Drink water", new[] { "drink", "drink water", "drink tar" },
                "It looks and smells like oil, I would rather not drink it.")
        };
        return new Area(1,
            "You arrive in a dark cave entrance. Your lamp reveals an old rug in the middle of the cave, odd-looking dust on the ground, fresh water pouring from the other side of the room, an opening on the ceiling and an annoying bug that likes your lamp a bit too much.",
            area1Actions, new[] { 0, 2, 5 });
    }
  
    private static Area CreateArea2()
    {
        var moveToArea3 = new Move("Go left", new[] { "left", "go left", "l" }, "You go through the left door.", 3);
        var moveToArea4 = new Move("Go right", new[] { "right", "go right", "r" }, "You go through the right door.", 4);
        var pullLever = new Switch("Pull the lever", new[] { "pull lever", "pull", "lever" },
            "You pull the lever and a hidden door on your left opens up.",
            "The hidden door on the right closes and the left one opens",
            "The hidden door on the left closes and the right one opens", moveToArea3, moveToArea4);
        
        var area1Actions = new List<Action>
        {
            new MathPuzzle("Try the puzzle", new[] { "try the puzzle", "puzzle", "solve", "solve puzzle", "try puzzle" },
                "You hear a satisfying beep coming from the screen. The screen disappears and reveals a lever.",
                "The screen makes a terrible sound.", pullLever)
        };
        return new Area(2,
            "You arrive in a cave filled with many objects. The door behind you has closed. ..................",
            area1Actions, new[] { 0, 2, 5 });
    }

    private static Area CreateArea3()
    {
        var pickupCarKeyAction = new TakeItemAction("Take the car keys from behind the screen",
            new[] { "take keys", "take car keys", "car key", "take key" }, "You pick up your car keys.", CarKey);
        var moveToArea2 = new Move("Go back to the previous room", new[] { "go back", "back" },
            "You move back to the previous room.", 2);
        var moveToArea5 = new Move("Go into the opening in front of you", new[] { "enter opening", "go", "go forward", "forward", "enter opening" },
            "You go into the opening in front of you.", 5);
        var puzzle = new MathPuzzle("Try to solve the puzzle",
            new[] { "try the puzzle", "puzzle", "solve", "solve puzzle" },
            "You hear a satisfying beep coming from the screen. A hidden compartment opens and reveals your car keys.",
            "The screen makes a terrible sound.", pickupCarKeyAction);
        
        var area3Actions = new List<Action>()
        {
            moveToArea2,
            moveToArea5,
            puzzle,
        };
        
        return new Area(3,
            "You arrive in a smaller rectangular room filled with dust. You see a screen with 2 numbers and your flashlight reveals an opening in front of you in the cave wall.",
            area3Actions, new[] { 2, 5 });
    }

    private static Area CreateArea4()
    {
        var codecoolSticker = new Item("Codecool sticker", "A sticker featuring the Codecool logo");
        var inspectStickerAction = new Inspect("Inspect Codecool sticker", new[] { "inspect sticker", "inspect" },
            "You look at the Codecool sticker. It's very cool.");
        var moveToArea2 = new Move("Go back to the previous room", new[] { "go back", "back" },
            "You move back to the previous room.", 2);
        
        var placeStickerAction = new GiveItemAction("Place Codecool sticker on windshield",
            new[] { "place sticker", "place codecool sticker", "sticker" }, "You have placed the sticker on your car.",
            "You couldn't place the sticker on your car.", codecoolSticker, inspectStickerAction);
        
        var pickupStickerAction = new TakeItemActionSpecial("Pick up the Codecool sticker",
            new[] { "pick up sticker", "sticker", "pick up the sticker", "pick up" },
            "You found the secret Codecool sticker", codecoolSticker, 0, placeStickerAction);
        
        var area4Actions = new List<Action>()
        {
            pickupStickerAction,
            moveToArea2
        };

        return new Area(4,
            "You find yourself in a colorful room full of gold coins and a pedestal with a familiar sticker on it",
            area4Actions, new[] { 2 });
    }

    private static Area CreateArea5()
    {
        //Items
        var wood = new Item("Wood", "Some wooden material.");
        var tools = new Item("Woodworking tools", "Some regular woodworking tools. Read the manual before use!");
        var ladder = new Item("Ladder", "A ladder.");
        
        //Actions
        var pickupLadderAction = new TakeItemAction("Pick up ladder",
            new[] { "pick up ladder", "take ladder", "ladder" },
            "You have picked up the ladder", ladder);
        
        var useToolsAction = new GiveItemAction("Use the tools to make a ladder", new []{"use tools", "make ladder", "ladder"},
            "You have built a ladder.", "You can't build a ladder.",
            tools, pickupLadderAction);
        
        var placeWoodAction = new GiveItemAction("Place wood on the woodworking table", new []{"place wood", "place wood on table", "wood"},
            "You have placed the wood on the woodworking table.", "You don't have wood",
            wood, useToolsAction);
        
        var pickupWoodAction = new TakeItemActionSpecial("Take wood from storage",
            new[] { "take wood", "take", "wood", "pick up wood" }, "You have picked up the wood", wood, 5,
            placeWoodAction);
        
        var pickupToolsAction = new TakeItemActionSpecial("Take tools from storage", 
            new []{"take tools", "take", "tools", "pick up tools"}, "You got the tools.",
            tools,5, pickupWoodAction);
        
        var openStorageRoomAction = new Discover("Open the door near the table", new []{"open door", "open", "door"},
            "You have opened the door, revealing a woodworking supply storage with some tools and wood inside.", pickupToolsAction);
        

        var moveFromArea1ToArea5 = new Move(
            "Climb up the ladder",
            new[] { "climb", "climb up", "climb ladder", "ladder", "left", "go left", "l" },
            "You climb up the ladder",
            5
        );
        
        var moveToArea3 = new Move("Go back to the dusty room", new[] { "go back", "back", "go to dusty room", "dusty room" },
            "You move back to the previous room.", 3);
        var moveToArea1 = new Move("Climb down the ladder", new[] { "climb", "climb down", "go down" },
            "You climb down the ladder", 1);
        var placeLadderAction = new PlaceLadderAction("Place ladder into the hole", new[] { "place ladder", "ladder" },
            "You have placed the ladder in the hole, making it safe to descend.",
            "You don't have a ladder!", ladder, moveFromArea1ToArea5, 1, moveToArea1);
        
        

        var area5Actions = new List<Action>()
        {
            moveToArea3,
            placeLadderAction,
            openStorageRoomAction
        };
        
        return new Area(5, "You are in a circular room. There is a relatively deep hole to your left with faint light coming out of it. You see a woodworking table and a door on the far side of the room.",
            area5Actions, new[]{1, 3});


    }
}