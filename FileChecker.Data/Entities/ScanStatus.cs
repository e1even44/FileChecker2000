namespace FileChecker.Data.Entities
{
    /// <summary>
    /// File Status currently reduced to NoChanges and FileChanged.
    /// More status options can easily be added in future e.g. FileDeleted.
    /// </summary>
    public enum ScanStatus
    {
        NoChanges = 0,
        FileChanged = 1,
    }
}
