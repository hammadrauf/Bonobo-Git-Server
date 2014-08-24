using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Bonobo.Git.Server.Models;

namespace Bonobo.Git.Server.Data
{
    public class EFRemoteRepository : IRemoteRepository
    {

        public IList<RemoteModel> GetAllRemotes()
        {
            using (var db = new BonoboGitServerContext())
            {
                var dbRemotes = db.Remotes.Select(remote => new
                {
                    RepositoryId = remote.RepositoryId,
                    RemoteId = remote.RemoteId,
                    RemoteDescription = remote.RemoteDescription,
                    Username = remote.Username,
                    Password = remote.Password,
                 }).ToList();

                return dbRemotes.Select(item => new RemoteModel
                {
                    RepositoryId = item.RepositoryId,
                    RemoteId = item.RemoteId,
                    RemoteDescription = item.RemoteDescription,
                    Username = item.Username,
                    Password = item.Password,
                }).ToList();
            }
        }

        public IList<RemoteModel> GetRemotes(string repoId)
        {
            // repoId = repoId.ToLowerInvariant();
            return GetAllRemotes().Where(i => i.RemoteId.Equals(repoId)).ToList();
        }

        public RemoteModel GetRemote(string repoId, string remoteId)
        {
            if (repoId == null) throw new ArgumentException("repoId");
            if (remoteId == null) throw new ArgumentException("remoteId");

            using (var db = new BonoboGitServerContext())
            {
                var remote = db.Remotes.FirstOrDefault(i => i.RepositoryId == repoId && i.RemoteId==remoteId);
                return remote == null ? null : new RemoteModel
                {
                    RepositoryId = remote.RepositoryId,
                    RemoteId = remote.RemoteId,
                    RemoteDescription = remote.RemoteDescription,
                    Username = remote.Username,
                    Password = remote.Password,
                };
            }
        }

        public void Delete(string repoId, string remoteId)
        {
            if (repoId == null) throw new ArgumentException("name");
            if (remoteId == null) throw new ArgumentException("remoteId");

            using (var db = new BonoboGitServerContext())
            {
                var remote = db.Remotes.FirstOrDefault(i => i.RepositoryId == repoId && i.RemoteId == remoteId);
                if (remote != null)
                {
                    db.Remotes.Remove(remote);
                    db.SaveChanges();
                }
            }
        }

 
        public bool Create(RemoteModel remote)
        {
            if (remote == null) throw new ArgumentException("remote");
            if (remote.RepositoryId == null) throw new ArgumentException("remote.RepositoryId");
            if (remote.RemoteId == null) throw new ArgumentException("remote.RemoteId");

            using (var database = new BonoboGitServerContext())
            {
                var remoteNew = new Remote
                {
                    RepositoryId = remote.RepositoryId,
                    RemoteId = remote.RemoteId,
                    RemoteDescription = remote.RemoteDescription,
                    Username = remote.Username,
                    Password = remote.Password
                };
                database.Remotes.Add(remoteNew);
                try
                {
                    database.SaveChanges();
                }
                catch (UpdateException)
                {
                    return false;
                }
            }

            return true;
        }

        public void Update(RemoteModel remoteModel)
        {
            if (remoteModel == null) throw new ArgumentException("remoteModel");
            if (remoteModel.RepositoryId == null) throw new ArgumentException("remoteModel.RepositoryId");
            if (remoteModel.RemoteId == null) throw new ArgumentException("remoteModel.RemoteId");

            using (var db = new BonoboGitServerContext())
            {
                var remote = db.Remotes.FirstOrDefault(i => i.RepositoryId == remoteModel.RepositoryId && i.RemoteId == remoteModel.RemoteId);
                if (remote != null)
                {
                    remote.RemoteDescription = remoteModel.RemoteDescription;
                    remote.Username = remoteModel.Username;
                    remote.Password = remoteModel.Password;
                    db.SaveChanges();
                }
            }
        }

    }
}