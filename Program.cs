Console.Title = "Vin Fletchers Shop";

//method title
Title();

//small intro
Console.WriteLine("\nHello welcome to my shop, I'm Vin");
Console.Write("What is your name? ");
string user = Console.ReadLine();
Console.WriteLine($"\nWelcome {user} have a look at my options of pre-made arrows or I can make you a custom arrow for the right price :)");
Console.Write("\nPress any key to proceed...");
Console.ReadKey(false);
Console.Clear();

//list for user
Console.WriteLine("Here are my options please select one");
Console.WriteLine("1 - Elite Arrow");
Console.WriteLine("2 - Beginner Arrow");
Console.WriteLine("3 - Marksman Arrow");
Console.WriteLine("4 - Custom Arrow");

//takes in user choice, places in choice variable
string? choice = Console.ReadLine();

//creating an instance Arrow class in arrow variable to use switch expression on user input to get a selection
Arrow arrow = choice switch
{
    "1" => Arrow.CreateEliteArrow(),
    "2" => Arrow.CreateBeginnerArrow(),
    "3" => Arrow.CreateMarksmanArrow(),
    _ => CreateCustomArrow(),
};

//Method if user selects custom arrow they go through the methods below
Arrow CreateCustomArrow()
{
    ArrowHeadType arrowhead = GetArrowHead();
    FletchingType fletching = GetFletchingType();
    float length = GetLength();

    return new Arrow(arrowhead, fletching, length);
}

//creating a new instance of arrow and giving it the value of the users new arrow
//Arrow arrow = GetArrow();
Console.WriteLine($"\nThe arrow you've created will cost {arrow.GetCost()} gold");

/// <summary>
/// old code for earlier part of the chapter
/// </summary>
//Method to construct the users input arrow
//Arrow GetArrow()
//{
//    ArrowHeadType arrowHeadType = GetArrowHead();
//    FletchingType fletchingType = GetFletchingType();
//    float length = GetLength();

//    Console.WriteLine($"\n{user} you picked an arrowhead {arrowHeadType} with a fletch of {fletchingType} & a length of {length}cm");
//    return new Arrow(arrowHeadType, fletchingType, length);
//}




//method to get userlength return
float GetLength()
{
    float length = 0;
    Console.WriteLine($"\n{user} please enter a length between 60 - 100");
    //will loop until 60 - 100 is entered
    while (length < 60 || length > 100)
    {
        length = Convert.ToSingle(Console.ReadLine());
        //will tell user too high
        if (length > 100) { Console.WriteLine($"{user} That value is high try between 60 - 100 "); }
        if (length < 60) { Console.WriteLine($"{user} That value is too low try between 60 - 100"); }
    }
    Console.WriteLine($"\nThanks {user} you've pick {length}cm");
    return length;
}

//method to get the fletching type from user
FletchingType GetFletchingType()
{
    while (true)
    {
        Console.WriteLine("\n 1 - Plastic \n 2 - Turkey Feathers \n 3 - Goose Feathers\n");
        int option = Convert.ToInt32(Console.ReadLine());
        if (option >= 1 && option <= 3)
        {
            return option switch
            {
                1 => FletchingType.Plastic,
                2 => FletchingType.TurkeyFeather,
                3 => FletchingType.GooseFeather,
                _ => FletchingType.Plastic
            };
        }
    }

}


//method to get the arrowhead from user
ArrowHeadType GetArrowHead()
{
    while (true)
    {
        Console.WriteLine("\n 1 - Steel \n 2 - Wood \n 3 - Obsidian\n");
        int option = Convert.ToInt32(Console.ReadLine());
        if (option >= 1 && option <= 3)
        {
            return option switch
            {
                1 => ArrowHeadType.Steel,
                2 => ArrowHeadType.Wood,
                3 => ArrowHeadType.Obsidian,
                _ => ArrowHeadType.Steel
            };
        }

    }
}

//method Title that runs at the start
void Title()
{
    Console.WriteLine("^^^^ VINS ARROWS MAKER ^^^^");
    Console.WriteLine("||||                   ||||");
    Console.WriteLine("\"\"\"\"                   \"\"\"\"");
}


//Arrow class
class Arrow
{
    //values are private can't be touched
    private ArrowHeadType _arrowHeadType { get; }
    private FletchingType _fletchingType { get; }
    private float _length { get; }

    //public static ArrowHeadType _arrowHeadType;
    //public static FletchingType _fletchingType;
    //public float _length;


    //constructor we will use to access the private variables
    public Arrow(ArrowHeadType arrowHeadType, FletchingType fletchingType, float length)
    {

        _arrowHeadType = arrowHeadType;
        _fletchingType = fletchingType;
        _length = length;

    }

    //Method to get total cost of all parts combined
    public float GetCost()
    {
        float arrowHeadCost = _arrowHeadType switch
        {
            ArrowHeadType.Steel => 10,
            ArrowHeadType.Wood => 3,
            ArrowHeadType.Obsidian => 5,
            _ => throw new NotImplementedException()
        };

        float fletchingCost = _fletchingType switch
        {
            FletchingType.Plastic => 10,
            FletchingType.TurkeyFeather => 3,
            FletchingType.GooseFeather => 5,
            _ => throw new NotImplementedException()
        };

        float lengthCost = 0.05f * _length;


        return arrowHeadCost + fletchingCost + lengthCost;
    }

    //pre-defined arrows
    public static Arrow CreateEliteArrow() => new Arrow(ArrowHeadType.Steel, FletchingType.Plastic, 95f);
    public static Arrow CreateBeginnerArrow() => new Arrow(ArrowHeadType.Wood, FletchingType.GooseFeather, 75f);
    public static Arrow CreateMarksmanArrow() => new Arrow(ArrowHeadType.Steel, FletchingType.GooseFeather, 65f);

    //parameterless constructor
    public Arrow() { }

}


//Enums
enum ArrowHeadType { Steel = 10, Wood = 3, Obsidian = 5 }
enum FletchingType { Plastic = 10, TurkeyFeather = 5, GooseFeather = 3 }