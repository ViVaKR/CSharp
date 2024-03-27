public class Study
{
    public void Main()
    {
        // csc: 컴파일러
        // svm
        // ildasm /out:moo.txt main.exe
        // ildasm /out:moo.txt DmsConsole.exe

        foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
        {
            Console.WriteLine(t.Name);
        }
    }
}

// Serialize 
namespace DmsConsole
{
    [DataContract]
    class Person
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int Age { get; set; }


    }
    class MainClass
    {
        static void Main()
        {

            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            int order = 0;
            while (stack.Count > 0)
            {
                Console.WriteLine(order++ + " : " + stack.Pop());
            }

            var me = new Person
            {
                FirstName = "Jamie",
                LastName = "King",
                Age = 25
            };

            var serializer = new DataContractSerializer(me.GetType());
            var someRam = new MemoryStream();
            serializer.WriteObject(someRam, me);

            someRam.Seek(0, SeekOrigin.Begin);
            Console.WriteLine(XElement.Parse(Encoding.ASCII.GetString(someRam.GetBuffer()).Replace("\0", "")));

            #region MyRegion

            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            while (queue.Count > 0)
            {
                Console.WriteLine("Dequeue: {0}, Count: {1}", queue.Dequeue(), queue.Count);
            }

            // Hashtable
            // Queue
            // ArrayList

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(x => x.GetCustomAttributes<MyClassAttribute>().Count() > 0);

            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
                var methods = type.GetMethods().Where(x => x.GetCustomAttributes<MyMethodAttribute>().Count() > 0);
                foreach (var method in methods)
                {
                    Console.WriteLine(method.Name);
                }
            }

            Console.WriteLine(assembly.GetName());
            Console.WriteLine(assembly.FullName);

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine(type.Name + " Base Type: " + type.BaseType);
                var props = type.GetProperties();
                foreach (var prop in props)
                {
                    Console.WriteLine(prop);
                }

                var fields = type.GetFields();
                foreach (var field in fields)
                {
                    Console.WriteLine(field + ", Field Type: " + field.FieldType);
                }

                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine(method);
                }

            }

            var sample = new Sample { Name = "John", Age = 25 };

            var sampleType = typeof(Sample);

            var myMethod = sampleType.GetMethod("MyMethod");

            object[] str = { "Hello MyFriend" };
            myMethod.Invoke(sample, str);

            var me = new Person
            {
                FirstName = "장",
                LastName = "길산",
                Age = 25
            };

            var serializer = new DataContractSerializer(me.GetType());
            MemoryStream someRam = new MemoryStream();
            serializer.WriteObject(someRam, me);
            someRam.Seek(0, SeekOrigin.Begin);
            Console.WriteLine(XElement.Parse(Encoding.UTF8.GetString(someRam.GetBuffer()).Replace("\0", "")));
            someRam.Dispose();
            someRam.Close();
            #endregion

        }

        void Exam()
        {
            var props = typeof(Person).GetProperties();
            foreach (var prop in props)
            {
                var attrs = (PropNameAttribute[])prop.GetCustomAttributes(typeof(PropNameAttribute), false);
                foreach (var attr in attrs)
                {
                    Console.WriteLine("{0}: {1}", prop.Name, attr.HeaderText);
                }
            }
        }
    }
}
