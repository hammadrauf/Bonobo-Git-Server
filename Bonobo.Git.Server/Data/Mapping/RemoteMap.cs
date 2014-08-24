using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bonobo.Git.Server.Data.Mapping
{
    public class RemoteMap : EntityTypeConfiguration<Remote>
    {
        public RemoteMap()
        {
            SetPrimaryKey();
            SetProperties();
            SetTableAndColumnMappings();
           // SetRelationships();
        }

        private void SetTableAndColumnMappings()
        {
            ToTable("Remote");
            Property(t => t.RepositoryId).HasColumnName("Repo. ID");
            Property(t => t.RemoteId).HasColumnName("Remote ID");
            Property(t => t.RemoteDescription).HasColumnName("Description");
            Property(t => t.Username).HasColumnName("User Name");
            Property(t => t.Password).HasColumnName("Password");
        }

        private void SetProperties()
        {
            Property(t => t.RepositoryId)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.RemoteId)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.RemoteDescription)
                .HasMaxLength(255);

            Property(t => t.Username)
                .HasMaxLength(255);

            Property(t => t.Password)
                .HasMaxLength(255);
        }

        private void SetPrimaryKey()
        {
            //Multiple property primary-key, as per MSDN link http://msdn.microsoft.com/en-us/library/gg671266(v=vs.113).aspx
            HasKey(t => new { t.RepositoryId, t.RemoteId });
        }
    }
}
