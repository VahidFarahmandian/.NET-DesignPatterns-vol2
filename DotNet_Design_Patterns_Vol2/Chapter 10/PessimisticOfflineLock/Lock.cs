using System.Data;
using System.Data.SqlClient;
using DotNet_Design_Patterns_Vol2.Chapter_10.OptimisticOfflineLock;
namespace DotNet_Design_Patterns_Vol2.Chapter_10.PessimisticOfflineLock
{
    public class AuthorDomain
    {
        public bool Modify(Author author)
        {
            LockManager.ReleaseAllLocks("Session 1");
            LockManager.AcquireLock(author.AuthorId, "Sesion 1");
            //
            LockManager.ReleaseLock(author.AuthorId, "Sesion 1");
            return true;
        }
    }
    public static class LockManager
    {
        static bool HasLock(int lockable, string owner)
        {
            //check if an owner already owns a lock.
            return true;
        }
        public static void AcquireLock(int lockable, string owner)
        {
            if (!HasLock(lockable, owner))
            {
                try
                {
                    //Insert into lock table/object
                }
                catch (SqlException ex)
                {
                    throw new DBConcurrencyException($"unable to lock {lockable}");
                }
            }
        }
        public static void ReleaseLock(int lockable, string owner)
        {
            try
            {
                //delete from lock table/object
            }
            catch (SqlException ex)
            {
                throw new Exception($"unable to release lock {lockable}");
            }
        }
        public static void ReleaseAllLocks(string owner)
        {
            try
            {
                //delete all locks for given owner from lock table/object
            }
            catch (SqlException ex)
            {
                throw new Exception($"unable to release locks owned by {owner}");
            }
        }
    }
}
