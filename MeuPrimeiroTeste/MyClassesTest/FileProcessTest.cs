using System;
using System.Configuration;
using System.IO;
using MyClasses;
using Xunit;

namespace MyClassesTest
{
    public class Tests
    {
        private const string INVALID_FILE_NAME = @"C:\Studyspace\unit-testing-course\Files\naoExiste.txt";
        private string _validFileName;

        public void SetValidFileName()
        {
            _validFileName = ConfigurationManager.AppSettings["VALID_FILE_NAME"];

            if (_validFileName.Contains("[AppPath]"))
            {
                _validFileName = _validFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [Fact]
        public void FileNameExists()
        {
            SetValidFileName();
            File.AppendAllText(_validFileName, "Some text");
            FileProcess fp = new FileProcess();
            bool fromCall = fp.FileExists(_validFileName);
            File.Delete(_validFileName);
            
            Assert.True(fromCall);
        }

        [Fact]
        public void FileNameDoesntExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(INVALID_FILE_NAME);

            Assert.False(fromCall);
        }

        [Fact]
        public void WhenFileNameIsNullOrEmpty_ThrowArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            Assert.Throws<ArgumentNullException>(() => fp.FileExists(String.Empty));
        }

        [Fact]
        public void WhenFileNameIsNullOrEmpty_ThrowArgumentNullException_UsingTryCatch()
        {
            try
            {
                FileProcess fp = new FileProcess();

                fp.FileExists(String.Empty);
            }
            catch (ArgumentNullException)
            {
                return;
            }
        }
    }
}