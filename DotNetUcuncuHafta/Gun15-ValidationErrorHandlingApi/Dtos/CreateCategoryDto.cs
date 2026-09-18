using System.ComponentModel.DataAnnotations;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Kategori adı zorunludur.")]
    [StringLength(
        50,
        MinimumLength = 2,
        ErrorMessage = "Kategori adı 2-50 karakter olmalıdır."
    )]
    public string Name { get; set; } = "";
}