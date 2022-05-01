namespace MyClasses
{
    public class AssertClass
    {
        private FileProcess file1 { get; set; }

        private FileProcess file2 { get; set; }

        public AssertClass(FileProcess file1, FileProcess file2)
        {
            this.file1 = file1;
            this.file2 = file2;
        }
        public bool AreSame()
        {
            return file1 == file2;
        }
        
        public bool AreNotSame()
        {
            return file1 != file2;
        }
    }
}