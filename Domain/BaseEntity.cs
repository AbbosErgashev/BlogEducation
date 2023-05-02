using System.ComponentModel.DataAnnotations;

namespace BlogEducation.Domain;

public class BaseEntity
{
    [Key]
    public virtual int Id { get; set;}
}