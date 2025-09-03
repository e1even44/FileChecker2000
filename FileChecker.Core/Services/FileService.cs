using FileChecker.Core.AccessLayers;
using FileChecker.Data.Entities;

namespace FileChecker.Core.Services
{
    public class FileService
    {
        static readonly AppFileAccessLayer _fileAccess = new();
        static readonly ScanAccessLayer _scanAccess = new();

     /// <summary>
     /// Scans for files in initial given directory and adds all files to database,
     /// then scans initial directory for subdirectories and for each subdirectory, 
     /// recursively calls itself to add files of subdirectories to database.
     /// </summary>
     /// <param name="path"></param>
        public static void GetFilesRecursively(string path)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                AppFile appFile = new AppFile
                {
                    ParentDirectoryPath = path, // use current directory
                    FilePath = Path.GetFullPath(file), // current file's full pat
                    FileSizeInBytes = new FileInfo(file).Length,
                    Checksum = GetFileChecksumMD5(file),
                    Created = File.GetCreationTime(file),
                    LastModified = File.GetLastWriteTime(file),
                };

                if (!_fileAccess.FileAlreadyExists(appFile))
                {
                    _fileAccess.Add(appFile);
                }
                continue;
            }
            foreach (var subDirectory in Directory.GetDirectories(path))
            {
                GetFilesRecursively(subDirectory); // call recursion and do same process with sub directories
            }
        }

        /// <summary>
        /// Gets the last modification date of given file (path).
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Last Modification date of given file.</returns>
        public static DateTime GetLastModified(string path)
        {
            return File.GetLastWriteTime(path);
        }

        /// <summary>
        /// Gets file content's checksum using MD5 format.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Checksum of given file's content.</returns>
        public static string GetFileChecksum(string path)
        {
            return GetFileChecksumMD5(path);
        }

        /// <summary>
        /// Gets file size in bytes of given file (path).
        /// </summary>
        /// <param name="path"></param>
        /// <returns>File size in byte of given file.</returns>
        public static decimal GetCurrentFileSize(string path)
        {
            return new FileInfo(path).Length;
        }
        
        /// <summary>
        /// Checks for given file's very last calculated checksum and compares it
        /// to calculated checksum during current scan to update file's status.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="newChecksum"></param>
        /// <returns>Current scan status of given file.</returns>
        public static ScanStatus GetStatus(AppFile file, string newChecksum)
        {
            // if first scan, compare to initial file checksum
            if (!_scanAccess.FileHasScans(file))
            {
                if (file.Checksum == newChecksum)
                {
                    return ScanStatus.NoChanges;
                }
                return ScanStatus.FileChanged;
            }
            // if > 1 scan, compare to last scan's file checksum
            else
            {
                var scan = _scanAccess.GetLastScanForFile(file);
                if (scan.CurrentChecksum == newChecksum)
                {
                    return ScanStatus.NoChanges;
                }
                return ScanStatus.FileChanged;
            }
        }

        /// <summary>
        /// Calculates given file content's checksum using MD5 format.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>File content checksum in MD5 format.</returns>
        private static string GetFileChecksumMD5(string path)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "");
                }
            }
        }
    }
}