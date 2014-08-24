using System;
using System.Collections.Generic;

namespace Bonobo.Git.Server.Data
{
    public partial class Remote
    {
        /*
                                    [RepositoryId] VarChar(255) Not Null,
                                    [RemoteId] VarChar(100) Not Null,
                                    [RemoteDescription] VarChar(255) Null,
                                    [Username] VarChar(255) Not Null,
                                    [Password] VarChar(255) Not Null,
 
         */

        public string RepositoryId { get; set; }
        public string RemoteId { get; set; }
        public string RemoteDescription { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
