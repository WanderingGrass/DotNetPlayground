
using CSharpFeatures.CSharp_13;


namespace tests.CSharpFeatures.CSarp13
{
    public class DisposerTest
    {
        public void TestDisposeAll()
        {
            Disposer.DisposeAll<StringReader>([new("Hello"), new("World")]);
        }
    }
}