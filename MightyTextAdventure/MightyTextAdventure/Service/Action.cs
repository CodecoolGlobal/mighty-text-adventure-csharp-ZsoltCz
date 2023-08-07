namespace MightyTextAdventure.Service;

public class Action
{
    public string Description;

    public string[] Triggers;

    public Action(string description, string[] triggers)
    {
        Description = description;
        Triggers = triggers;
    }
    
    
}