using System.ComponentModel.DataAnnotations;

namespace FileChecker.Data.Entities
{
    public class Scan
    {
        [Key] // Primary Key
        public int ScanId { get; set; }
        
        [Required] // Foreign KEy, navigation property
        public int AppFileId { get; set; }
        public AppFile AppFile { get; set; }

        public DateTime ScanDate{ get; set; }

        public decimal CurrentSizeInBytes { get; set; }

        public string CurrentChecksum { get; set; } = string.Empty;

        public ScanStatus Status { get; set; }
    }
}
