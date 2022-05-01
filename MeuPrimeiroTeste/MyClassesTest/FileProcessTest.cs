using System;
using MyClasses;
using Xunit;

namespace MyClassesTest
{
    public class Tests
    {
        [Fact]
        public void FileNameExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Studyspace\unit-testing-course\Files\emBranco.txt");

            Assert.True(fromCall);
        }

        [Fact]
        public void FileNameDoesntExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Studyspace\unit-testing-course\Files\naoExiste.txt");

            Assert.False(fromCall);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenFileNameIsNullOrEmpty_ThrowArgumentNullException(string fileName)
        {
            FileProcess fp = new FileProcess();

            Assert.Throws<ArgumentNullException>(() => fp.FileExists(fileName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenFileNameIsNullOrEmpty_ThrowArgumentNullException_UsingTryCatch(string fileName)
        {
            try
            {
                FileProcess fp = new FileProcess();

                fp.FileExists(fileName);
            }
            catch (ArgumentNullException)
            {
                return;
            }
        }
    }
}