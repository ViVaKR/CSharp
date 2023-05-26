namespace BootCamp;

public class AnimalTypeTestClass
{
    [AnimalType(Animal.Bird)]
    public void Bird() { }

    [AnimalType(Animal.Cat)]
    public void Cat() { }

    [AnimalType(Animal.Dog)]
    public void Dog() { }
}

/// <summary>
/// Custom Attribute Demo Test
/// </summary>
public class TestClass
{
    /// <summary>
    /// Assign an ArgumentID attribute to each parameter.
    /// Assign an ArgumentUsage attribute to each parameter.
    /// </summary>
    /// <param name="strArray"></param>
    /// <param name="strList"></param>
    public void TestMethod(
        [ArgumentID]
        [ArgumentUsage("Must pass an array here.")]
        string[] strArray,
        [ArgumentID]
        [ArgumentUsage("Can pass param list or array here.")]
        params string[] strList
    )
    {
        WriteLine($"{string.Join(", ", strArray)}\n{string.Join(", ", strList)}");
    }
}

public class PropClass
{
    public string? Name { get; set; }
}

/// <summary>
/// Activator Demo Class
/// </summary>
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Customer()
    {
        Id = 1;
        Name = "No Name";
    }
}

public class MyFilter<T> where T : struct
{
    public List<T> MyList { get; init; }

    public MyFilter(List<T> list)
    {
        MyList = list;
    }
    public MyFilter()
    {
        MyList = new List<T>();
    }
}

public class TestTrigger
{
    public void Run()
    {
        // Test 1
        var test = new AnimalTypeTestClass();
        Type type = test.GetType();
        foreach (MethodInfo item in type.GetMethods())
        {
            foreach (var attr in Attribute.GetCustomAttributes(item))
            {
                if (attr is not AnimalTypeAttribute animal) continue;
                WriteLine($"{item.Name} Method -> {animal.Pet}");
            }
        }

        // Test 2
        var tc = new TestClass();
        tc.TestMethod(new string[] { "Hello", "World" }, "World", "Fine", "Thanks");

        type = typeof(TestClass);
        MethodInfo? info = type.GetMethod(nameof(TestClass.TestMethod));
        if (info == null) return;
        ParameterInfo[] pInfos = info.GetParameters();

        var attrUsage0 = Attribute.GetCustomAttribute(pInfos[0], typeof(ArgumentUsageAttribute)) as ArgumentUsageAttribute;
        var attrId0 = Attribute.GetCustomAttribute(pInfos[0], typeof(ArgumentIDAttribute)) as ArgumentIDAttribute;

        WriteLine($"{attrId0?.InstanceGuid} {attrUsage0?.Message}");

        // Test 3
        var propClass = new PropClass();
        SetValueToProperty(propClass, nameof(PropClass.Name), "Viv");
        WriteLine($"a = {propClass.Name}");

        // Test 4
        var obj = Activator.CreateInstance(typeof(Customer));
        if (obj == null) return;
        string? name = (obj as Customer)?.Name;
        int id = ((Customer)obj).Id;
        WriteLine($"{id}: {name}");

        // Test 5
        MyFilter<int> filter = new();
        GetPropFromGenericType(filter);
    
    }

    private void GetPropFromGenericType<T>(T obj) where T : class
    {
        if(!obj.GetType().Name.Equals(typeof(MyFilter<>).Name)) return;

        Type[] argTypes = obj.GetType().GetGenericArguments();

        Type actualType = typeof(MyFilter<>).MakeGenericType(argTypes[0]);

        var o = Activator.CreateInstance(actualType);
        if(o == null) return;
        WriteLine($"o -> {o.GetType().Name}");
    }

    /// <summary>
    /// GetValue, SetValue Reflection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private void SetValueToProperty<T>(T obj, string property, string value) where T : class
    {
        PropertyInfo? info = obj.GetType().GetProperty(property);
        if (info == null) return;
        info.SetValue(obj, value, null);
        WriteLine($"{info.Name} -> {info.GetValue(obj)}");
    }
}
