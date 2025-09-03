using System.ComponentModel.DataAnnotations;

namespace FileChecker.Data.Entities
{
    public class AppFile
    {
        [Key] // Primary Key
        public int AppFileId { get; set; }

        [Required]
        public string ParentDirectoryPath { get; set; } = string.Empty;

        [Required]
        public string FilePath { get; set; } = string.Empty;

        [Required]
        public decimal FileSizeInBytes { get; set; }

        [Required]
        public string Checksum { get; set; } = string.Empty;

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime LastModified { get; set; }
    }
}
