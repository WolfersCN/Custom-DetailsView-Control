using System.Collections.Generic;

/// <summary>
/// Summary description for TestData
/// </summary>
public class TestData
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}

public class TestDataList : List<TestData>
{

    /// <summary>
    /// Constructor
    /// 
    /// Just some test data
    /// </summary>
    public TestDataList()
    {
        AddRange(new[]
                     {
                         new TestData { FirstName = "Lucas", LastName = "Lim" , PhoneNumber = "647-2193484"},
                         new TestData { FirstName = "Dion", LastName = "Phaneuf", PhoneNumber = "901-8381746"},
                         new TestData { FirstName = "Bernie", LastName = "Monette", PhoneNumber = "647-3947184"},
                         new TestData { FirstName = "Sean", LastName = "Doyle" , PhoneNumber = "647-9487154"},
                         new TestData { FirstName = "Andre", LastName = "Martelli", PhoneNumber = "419-8371635"}
                     });
    }
}
