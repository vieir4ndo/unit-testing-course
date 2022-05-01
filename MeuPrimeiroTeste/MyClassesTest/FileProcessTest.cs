using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MyClasses;
using Xunit;
using Xunit.Abstractions;

namespace MyClassesTest
{
    public class FileProcessTest : IDisposable
    {
        private const string INVALID_FILE_NAME = @"C:\Studyspace\unit-testing-course\Files\naoExiste.txt";
        private readonly ITestOutputHelper _output;
        private string _validFileName;

        public void SetValidFileName()
        {
            _validFileName = ConfigurationManager.AppSettings["VALID_FILE_NAME"];

            if (_validFileName.Contains("[AppPath]"))
                _validFileName = _validFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }

        [Fact]
        [Trait("Category", "Unit")]
        [Description("Check to see if a file does exist.")]
        //[Priority(0)] 
        //[Owner("[Matheus]")]
        public void FileNameExists()
        {
            _output.WriteLine("Testing file");
            var fp = new FileProcess();
            var fromCall = fp.FileExists(_validFileName);

            Assert.True(fromCall);
        }

        [Fact]
        [Trait("Category", "Unit")]
        [Description("Check to see if a file does not exist.")]
        public void FileNameDoesntExist()
        {
            var fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(INVALID_FILE_NAME);

            Assert.False(fromCall);
        }

        [Fact]
        [Trait("Category", "Unit")]
        [Description("Check to see if a filename is null or empty.")]
        public void WhenFileNameIsNullOrEmpty_ThrowArgumentNullException()
        {
            var fp = new FileProcess();

            Assert.Throws<ArgumentNullException>(() => fp.FileExists(string.Empty));
        }

        [Fact(Skip = "testing functionality")]
        [Trait("Category", "Unit")]
        [Description("Check to see if a filename is null or empty.")]
        public void WhenFileNameIsNullOrEmpty_ThrowArgumentNullException_UsingTryCatch()
        {
            try
            {
                var fp = new FileProcess();

                fp.FileExists(string.Empty);
            }
            catch (ArgumentNullException)
            {
            }
        }

        [Fact]
        public void SimulateTimeout()
        {
             AssertAsync.CompletesIn(2, () =>
             {
                 Thread.Sleep(1000);
             });
        }

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
            _output.WriteLine("Deleting file");
            File.Delete(_validFileName);
        }

        #endregion

    }
}

// Class found on the web to make the timeout functionality work with xunit
// https://exchangetuts.com/xunitnet-how-can-i-specify-a-timeout-how-long-a-test-should-maximum-need-1639943498266090

public static class AssertAsync
{
    public static void CompletesIn(int timeout, Action action)
    {
        var task = Task.Run(action);
        var completedInTime = Task.WaitAll(new[] { task }, TimeSpan.FromSeconds(timeout));

        if (task.Exception != null)
        {
            if (task.Exception.InnerExceptions.Count == 1)
            {
                throw task.Exception.InnerExceptions[0];
            }

            throw task.Exception;
        }

        if (!completedInTime)
        {
            throw new TimeoutException($"Task did not complete in {timeout} seconds.");
        }
    }
}