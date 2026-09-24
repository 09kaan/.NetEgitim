using System.ComponentModel.DataAnnotations;

namespace Gun16.Application.DTOs;

public class CreateBrandDto
{
    // TODO: Marka adını taşıyan public string property
    // TODO: Null başlamasın
    // TODO: Zorunlu olsun ve en fazla 100 karakter kabul etsin
    [Required(ErrorMessage = "Marka adı zorunludur.")]
    [StringLength(
        100,
        ErrorMessage = "Marka adı max 100 karakter olmalıdır."
    )]
    public string Name {get; set; } = "";
}