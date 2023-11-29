using DynamicObjectApp;
using System.Reflection;


string typeName = "DynamicObjectApp.Student";

// Create an instance of the specified type dynamically
object dynamicObject = CreateInstance(typeName);

// Check if the object was created successfully
if (dynamicObject != null)
{
   
    Console.WriteLine("Dynamic object created successfully!");

    SetProperty(dynamicObject, "Id", 1);
    SetProperty(dynamicObject, "Name", "Omar");
    var studentEn = (Student)dynamicObject;
    //Console.WriteLine($"Name Of Object: {nameof(dynamicObject)}");

    //Console.WriteLine($"Name: {GetProperty(dynamicObject, "Name")}");
    //Console.WriteLine($"Id: {GetProperty(dynamicObject, "Id")}");
    var student = Helper.AddStudent(studentEn);
    Console.WriteLine($"Name: {student.Name}");
    Console.WriteLine($"Id: {student.Id}");
}
else
{
    Console.WriteLine("Failed to create dynamic object.");
}


static object CreateInstance(string typeName)
{
    try
    {
        // Get the type by name
        Type type = Type.GetType(typeName);

        if (type != null)
        {
            // Create an instance of the type
            object instance = Activator.CreateInstance(type);
            return instance;
        }
        else
        {
            Console.WriteLine($"Type {typeName} not found.");
            return null;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating instance: {ex.Message}");
        return null;
    }
}

static void SetProperty(object obj, string propertyName, object value)
{
    // Use reflection to set the property value
    PropertyInfo property = obj.GetType().GetProperty(propertyName);
    if (property != null && property.CanWrite)
    {
        property.SetValue(obj, value);
    }
    else
    {
        Console.WriteLine($"Property {propertyName} not found or is read-only.");
    }
}


//static object GetProperty(object obj, string propertyName)
//{
//    // Use reflection to get the property value
//    PropertyInfo property = obj.GetType().GetProperty(propertyName);
//    if (property != null && property.CanRead)
//    {
//        return property.GetValue(obj);
//    }
//    else
//    {
//        Console.WriteLine($"Property {propertyName} not found or is write-only.");
//        return null;
//    }
//}