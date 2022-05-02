using System.Text.RegularExpressions;
using Xunit;

namespace MyClassesTest
{
    public class StringAssertClassTest
    {
        [Fact]
        public void ContainsTest()
        {
            string str1 = "matheus vieira santos";
            string str2 = "math";
            
            Assert.Contains(str2, str1);
        }
        
        [Fact]
        public void StartsWithTest()
        {
            string str1 = "matheus vieira santos";
            string str2 = "math";
            
            Assert.StartsWith(str2, str1);
        }
           
        [Fact]
        public void IsAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");
            
            Assert.Matches( reg, "todos caixa baixa");
        }
        
        [Fact]
        public void IsNotAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");
            
            Assert.DoesNotMatch( reg, "Pelo menos um caixa alta");
        }
    }
}