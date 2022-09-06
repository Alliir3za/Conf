﻿#nullable disable
namespace ConfSys.Domain.Entity;

[Table(nameof(FamilyMember), Schema = nameof(Schema.Base))]

public class FamilyMember
{
    [Key]
    public int FamilyMemberId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public int UserId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [MaxLength(30)]
    public string Family { get; set; }

    [Required]
    public byte Age { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required]
    [Column(TypeName = "char")]
    [MaxLength(10)]
    public string NationalCode { get; set; }

    [Required] 
    public Relation Relation { get; set; }


}
