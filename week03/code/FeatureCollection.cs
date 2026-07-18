using System.ComponentModel;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    //We need the 'place' attribute and the 'mag' attribute.
    public List<Feature> features { get; set; }
};

public class Feature
{
    public earthquakeProperties properties { get; set; }
}

public class earthquakeProperties
{
    public string place { get; set; }
    public decimal mag { get; set; }
}
    