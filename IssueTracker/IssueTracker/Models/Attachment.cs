using System;

namespace IssueTracker.Models
{
    public class Attachment
    {
        private int attachmentId;
        private int issueId;
        private string fileName;
        private string filePath;
        private long fileSize;

        public int AttachmentId
        {
            get { return attachmentId; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id can t be negative");
                attachmentId = value;
            }
        }

        public int IssueId
        {
            get { return issueId; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("IssueId invalid.");
                issueId = value;
            }
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The file name can t be empty");
                fileName = value;
            }
        }

        public string FilePath
        {
            get { return filePath; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("File path can t be empty");
                filePath = value;
            }
        }

        public long FileSize
        {
            get { return fileSize; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("File size can t be empty");
                fileSize = value;
            }
        }

        public DateTime UploadedDate { get; set; }
        public int UploadedById { get; set; }


        public Attachment()
        {
            attachmentId = 0;
            issueId = 0;
            fileName = "untitled.txt";
            filePath = "C:\\";
            fileSize = 0;
            UploadedDate = DateTime.Now;
            UploadedById = 0;
        }

        public Attachment(int id, int issueId, string fileName, string filePath)
        {
            AttachmentId = id;
            IssueId = issueId;
            FileName = fileName;
            FilePath = filePath;
            FileSize = 0;
            UploadedDate = DateTime.Now;
            UploadedById = 0;
        }

        public Attachment(int id, int issueId, string fileName, string filePath,
            long size, DateTime uploadedDate, int uploadedById)
        {
            AttachmentId = id;
            IssueId = issueId;
            FileName = fileName;
            FilePath = filePath;
            FileSize = size;
            UploadedDate = uploadedDate;
            UploadedById = uploadedById;
        }


        public override string ToString()
        {
            return FileName + " (" + FileSize + " bytes)";
        }
    }
}
