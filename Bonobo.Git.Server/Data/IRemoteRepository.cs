using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bonobo.Git.Server.Models;

namespace Bonobo.Git.Server.Data
{
    public interface IRemoteRepository
    {
        IList<RemoteModel> GetAllRemotes();
        IList<RemoteModel> GetRemotes(string repoId);
        RemoteModel GetRemote(string repoId, string remoteId);
        void Delete(string repoId, string remoteId);
        bool Create(RemoteModel remote);
        void Update(RemoteModel remote);
    }
}