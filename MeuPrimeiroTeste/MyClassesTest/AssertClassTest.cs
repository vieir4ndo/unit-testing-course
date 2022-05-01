using MyClasses;
using Xunit;

namespace MyClassesTest
{
    public class AssertClassTest
    {
        [Fact]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            AssertClass a = new AssertClass(x, y);

            Assert.True(a.AreSame());
        }
        
        [Fact]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();
            
            AssertClass a = new AssertClass(x, y);
            
            Assert.True(a.AreNotSame());
        }
    }
}