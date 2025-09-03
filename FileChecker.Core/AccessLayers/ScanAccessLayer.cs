using FileChecker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileChecker.Core.AccessLayers
{
    public class ScanAccessLayer : BaseAccessLayer<Scan>
    {
        /// <summary>
        /// Gets all Scans in database.
        /// </summary>
        /// <returns>List of Scans.</returns>
        public override List<Scan> GetAll()
        {
            return Context.Scans
                .ToList();
        }

        /// <summary>
        /// Gets Scan that has given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Scan of given Id.</returns>
        public override Scan? GetById(int id)
        {
            return Context.Scans
                .FirstOrDefault(s => s.ScanId == id);
        }

        /// <summary>
        /// Adds a Scan to the database.
        /// </summary>
        /// <param name="entity"></param>
        public override void Add(Scan entity)
        {
            Context.Scans
                .Add(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Gets Scan of given Id and updates its' properties.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public override void Update(int id, Scan entity)
        {
            var s = GetById(id);

            s.AppFileId = entity.AppFileId;
            s.ScanDate = entity.ScanDate;
            s.CurrentSizeInBytes = entity.CurrentSizeInBytes;
            s.CurrentChecksum = entity.CurrentChecksum;
            s.Status = entity.Status;

            Context.Scans
                .Update(s);
            Context.SaveChanges();

        }

        /// <summary>
        /// Deletes Scan by given Id from database. (hard delete)
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(int id)
        {
            var s = GetById(id);

            Context.Scans
                .Remove(s!); // entity is not null here
            Context.SaveChanges();
        }

        public Scan? GetLastScanForFile(AppFile appFile)
        {
            return Context.Scans
                .Include(s => s.AppFile) // include AppFile navigation property
                .Where(s => s.AppFileId == appFile.AppFileId) // filter scans by AppFileId
                .OrderByDescending(s => s.ScanDate) // order by ScanDate descending to last scan is first
                .FirstOrDefault(); // get last scan or null
        }

        /// <summary>
        /// Gets all scans for given AppFile Id.
        /// </summary>
        /// <param name="appFile"></param>
        /// <returns>List of Scans of given AppFile Id.</returns>
        public List<Scan>? GetScansForFile(AppFile appFile)
        {
            return Context.Scans
                .Where(s => s.AppFileId == appFile.AppFileId)
                .ToList();
        }

        /// <summary>
        /// Checks if AppFile has any scans yet.
        /// </summary>
        /// <param name="appFile"></param>
        /// <returns>True if AppFile already has scans, false if not.</returns>
        public bool FileHasScans(AppFile appFile)
        {
            return Context.Scans
                .Where(s => s.AppFileId == appFile.AppFileId)
                .Any();
        }
    }
}
