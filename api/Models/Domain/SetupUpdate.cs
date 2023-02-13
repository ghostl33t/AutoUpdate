using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Domain;
public class SetupUpdate
{
    [Key]
    [Column(TypeName ="bigint")]
    public long Id { get; set; }
    [Required]
    [Column(TypeName = "smallint")]
    public int RepeatUpdateMinutes { get; set; }
    [Required]
    [Column(TypeName = "smallint")]
    public int ClearDLLTableMinutes { get; set; }
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(4000)]
    public string DLLServerPath { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(4000)]
    public string OtherServerPath { get; set; } = string.Empty;

}
