using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Bonobo.Git.Server.App_GlobalResources;

namespace Bonobo.Git.Server.Models
{
    public class RemoteModel
    {
        public string RepositoryId { get; set; }
        public string RemoteId { get; set; }
        public string RemoteDescription { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RemoteDetailModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Validation_Required")]
        [StringLength(40, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Validation_StringLength")]
        [Display(ResourceType = typeof(Resources), Name = "Remote_Detail_RepositoryId")]
        public string RepositoryId { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "Remote_Detail_RemoteId")]
        public string RemoteId { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "Remote_Detail_RemoteDescription")]
        public string RemoteDescription { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "Remote_Detail_Username")]
        public string Username { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "Remote_Detail_Password")]
        public string Password { get; set; }
    }
}