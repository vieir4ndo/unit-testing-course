using MyClasses;
using Xunit;

namespace MyClassesTest
{
    public class AssertClassTest
    {
        #region AreSameTests

        [Fact]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.Same(x, y);
        }
        
        [Fact]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();
            
            Assert.NotSame(x, y);
        }

        #endregion
        
        #region AreEqualTests

        [Fact]
        public void AreEqualTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.Equal(x, y);
        }
        
        [Fact]
        public void AreNotEqualTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();
            
            Assert.NotEqual(x, y);
        }

        #endregion
    }
}