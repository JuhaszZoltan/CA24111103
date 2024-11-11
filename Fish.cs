namespace CA24111103;

internal class Fish
{
    private int top;
    private int depth;
    private string species;
    private float weight;
    private bool weightIsSet = false;

    public float Weight
    {
        get => weight;
        set
        {
            if (value < .5 || value > 40) throw new Exception(
                $"\nbeállítani kívánt érték: {value}" +
                $"\na weight értéke csak [0.5; 40.0] intervallumon belül valid");

            if (weightIsSet && (value < weight * .9 || value > weight * 1.1))
                throw new Exception(
                    $"\na beállítani kívánt érték: {value}" +
                    $"\na weight jelenlegi értéke: {weight}" +
                    $"\naz új érték legfeljebb 10%-ban " +
                    $"(+/- {weight*.1}) térhet el az eredetitől");

            weight = value;
            weightIsSet = true;
        }
    }

    public bool Predator { get; }

    public int Top
    {
        get => top;
        set
        {
            if (value < 0 || value > 400) throw new Exception(
                $"\na beállítani kívánt érték: {value}" +
                $"\na top értéke csak [0; 400] intervallumon belül valid!");

            top = value;
        }
    }
    public int Depth
    {
        get => depth;
        set
        {
            if (value < 10 || value > 400) throw new Exception(
                $"\na beállítani kívánt érték: {value}" +
                $"\na depth értéke csak [10; 400] intervallumon belül valid!");

            depth = value;
        }
    }

    public string Species
    {
        get => species;
        set
        {
            if (value is null) throw new Exception(
                $"a species értéke nem lehet null");

            if (value.Length < 3 || value.Length > 30) throw new Exception(
                $"\na beállítani kívánt érték: {value} (hossza: {value.Length})" +
                $"\na species karakterlánc hossza csak [3; 30] intervallumon belül valid.");

            species = value;
        }
    }

    public override string ToString() => 
        $"{Species} " +
        $"({(Predator ? "carnivore" : "herbivore")}) " +
        $"[{Top} - {Top + Depth} cm] " +
        $"{Weight: 00.0} Kg";

    public Fish(float weight, bool predator, int top, int depth, string species)
    {
        Weight = weight;
        Predator = predator;
        Top = top;
        Depth = depth;
        Species = species;
    }
}
