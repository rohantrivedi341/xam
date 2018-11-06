using System;
using System.Threading.Tasks;
using SQLite;

namespace PCL.DependencyServices
{
    public interface IDependencyPlatformGeneral
    {
        Int32 GetBuildNumber();
        String GetDbPath();
        //void HandlePermissions(TaskCompletionSource<Boolean> taskCompletionSource);
    }
}