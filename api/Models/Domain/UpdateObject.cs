using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Domain;
public class UpdateObject
{
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(200)]
    public string FileName { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "smallint")]
    public FileType FileType { get; set; } = FileType.DLL;
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(10)]
    public string FileVersion { get; set; } = string.Empty;
    [Column(TypeName = "smallint")]
    public AssemblyType AssemblyType { get; set; } = AssemblyType.Regsvr32;
    [Column(TypeName = "smallint")]
    public UpdateFile UpdateFile { get; set; } = UpdateFile.YES;

}
public enum FileType
{
    DLL = 0,
    Other = 1
}
public enum AssemblyType
{ 
    Regsvr32 = 0,
    Regasm= 1
}
public enum UpdateFile
{
    NO = 0,
    YES = 1
}
