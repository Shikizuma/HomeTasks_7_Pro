using Task2;

namespace HomeTasks_7_Pro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestObsolete testObsolete = new TestObsolete();
            #if DEBUG
                testObsolete.TestMethod();
            #endif
            testObsolete.TestMethod("Test");
            testObsolete.TestMethod("Test", 22);
        }
    }
}