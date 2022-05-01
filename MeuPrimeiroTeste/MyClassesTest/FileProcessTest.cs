using System;
using System.Configuration;
using System.IO;
using MyClasses;
using Xunit;
using Xunit.Abstractions;

namespace MyClassesTest
{
    public class FileProcessTest : IDisposable
    {
        private const string INVALID_FILE_NAME = @"C:\Studyspace\unit-testing-course\Files\naoExiste.txt";
        private string _validFileName;
        private readonly ITestOutputHelper _output;

        #region Test Inicialize and CleanUp
        //Test Initialize
        public FileProcessTest(ITestOutputHelper output)
        {
            _output = output;
            
            SetValidFileName();
            _output.WriteLine($"Creating file at {_validFileName}");
            File.AppendAllText(_validFileName, "Some text");
        }
        
        //Test CleanUp
        public void Dispose()
        {
            _output.WriteLine($"Deleting file");
            File.Delete(_validFileName);
        }
        
        #endregion

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
            _output.WriteLine($"Testing file");
            FileProcess fp = new FileProcess();
            bool fromCall = fp.FileExists(_validFileName);

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