public sealed class MySingleton
{
    private static MySingleton _instance;

    private MySingleton()
    {

    }

    public static MySingleton Instance => _instance ?? (_instance = new MySingleton());

    // Other stuff here

    public override string ToString() => $"Type Name: {GetType().Name.Split('+')[0]}";
}

