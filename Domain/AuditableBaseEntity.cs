using System.ComponentModel.DataAnnotations;

namespace BlogEducation.Domain;

public class AuditableBaseEntity
{
    [Key]
    public virtual int Id { get; set;}
    public string CreatedBy { get; set;}
    public DateTime Created { get; set;}
    public string LastModifiedBy { get; set;}
    public DateTime LastModified { get; set;}
}