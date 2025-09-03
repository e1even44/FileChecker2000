using FileChecker.Data.Entities;

namespace FileChecker.Core.AccessLayers
{
    public class AppFileAccessLayer : BaseAccessLayer<AppFile>
    {
        /// <summary>
        /// Gets all AppFiles in database.
        /// </summary>
        /// <returns>List of AppFiles.</returns>
        public override List<AppFile> GetAll()
        {
            return Context.AppFiles
                .ToList();
        }

        /// <summary>
        /// Gets AppFile that has given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AppFile of given Id.</returns>
        public override AppFile? GetById(int id)
        {
            return Context.AppFiles
                .FirstOrDefault(a => a.AppFileId == id);
        }

        /// <summary>
        /// Adds a AppFile to the database.
        /// </summary>
        /// <param name="entity"></param>
        public override void Add(AppFile entity)
        {
            Context.AppFiles
                .Add(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Gets AppFile of given Id and updates its' properties.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public override void Update(int id, AppFile entity)
        {
            var a = GetById(id);

            a.ParentDirectoryPath = entity.ParentDirectoryPath;
            a.FilePath = entity.FilePath;
            a.FileSizeInBytes = entity.FileSizeInBytes;
            a.Checksum = entity.Checksum;
            a.Created = entity.Created;
            a.LastModified = entity.LastModified;
        }

        /// <summary>
        /// Deletes AppFile by given Id from database. (hard delete)
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(int id)
        {
            var a = GetById(id);

            Context.AppFiles.Remove(a!); // entity can't be null here
            Context.SaveChanges();
        }

        /// <summary>
        /// Checks if AppFile already exists in database by comparing file path and checksum.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True if AppFile already exists in database, false if not.</returns>
        public bool FileAlreadyExists(AppFile entity)
        {
            return Context.AppFiles
                .Any(a => a.FilePath == entity.FilePath
                && a.Checksum == entity.Checksum);          
        }
    }
}
