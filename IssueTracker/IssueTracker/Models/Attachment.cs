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
                    throw new ArgumentException("Id-ul nu poate fi negativ.");
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
                    throw new ArgumentException("Numele fisierului nu poate fi gol.");
                fileName = value;
            }
        }

        public string FilePath
        {
            get { return filePath; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Calea fisierului nu poate fi goala.");
                filePath = value;
            }
        }

        public long FileSize
        {
            get { return fileSize; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Dimensiunea nu poate fi negativa.");
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
