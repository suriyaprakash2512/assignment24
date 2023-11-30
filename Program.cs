using System;

class Source
{
    // Define properties in the Source class
    public string CommonProperty1 { get; set; }
    public int CommonProperty2 { get; set; }
    public string SourceOnlyProperty { get; set; }
}

class Destination
{
    // Define properties in the Destination class
    public string CommonProperty1 { get; set; }
    public int CommonProperty2 { get; set; }
    public string DestinationOnlyProperty { get; set; }

    public string DestName { get; set; }
}

class Program
{
    static void Main()
    {
        // Step 3: Test Dynamic Property Mapping

        // Create instances of Source and Destination classes
        Source sourceInstance = new Source();
        Destination destinationInstance = new Destination();

        // Assign values to properties of the Source class
        sourceInstance.CommonProperty1 = "Value1";
        sourceInstance.CommonProperty2 = 42;
        sourceInstance.SourceOnlyProperty = "SourceOnlyValue";

        // Call the MapProperties method to map common properties
        MapProperties(sourceInstance, destinationInstance);

        // Display values of properties in the Destination class
        Console.WriteLine($"Destination CommonProperty1: {destinationInstance.CommonProperty1}");
        Console.WriteLine($"Destination CommonProperty2: {destinationInstance.CommonProperty2}");
        Console.WriteLine($"Destination DestinationOnlyProperty: {destinationInstance.DestinationOnlyProperty}");
        Console.WriteLine($"Destination DestName: {destinationInstance.DestName}");

        Console.ReadKey();
    }

    // Step 2: Implement Dynamic Property Mapping
    static void MapProperties(Source source, Destination destination)
    {
        var sourceProperties = source.GetType().GetProperties();
        var destinationProperties = destination.GetType().GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            
            var matchingDestinationProperty = Array.Find(destinationProperties, p => p.Name == sourceProperty.Name);

            if (matchingDestinationProperty != null)
            {
              
                var value = sourceProperty.GetValue(source);
                matchingDestinationProperty.SetValue(destination, value);
            }
        }
    }
}