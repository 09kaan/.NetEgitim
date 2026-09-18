using System.ComponentModel.DataAnnotations;

public class CreateProductDto
{
    // Zorunlu olsun.
    // En az 2, en fazla 60 karakter olsun.
    [Required(ErrorMessage = "Ürün adı zorunludur.")]
    [StringLength(
        60,                                                     //Maks yazmayırouz StringLengthin olayı ilki max min yazmak istersen yazıyla yaz yoksa 0
        MinimumLength = 2,
        ErrorMessage = "Ürün adı 2-60 karakter olmalıdır."
    )]
    public string Name { get; set; } = "";

    // En az 0.01, en fazla 1000000 olsun.
    [Range(
        typeof(decimal),
        "0.01",
        "1000000",
        ErrorMessage = "Fiyat 0'dan büyük olmalıdır."
    )]
    public decimal Price { get; set; }

    // CategoryId en az 1 olsun.
    [Range(
        1,
        int.MaxValue,
        ErrorMessage = "Geçerli bir kategori seçilmelidir."
    )]
    public int CategoryId { get; set; }
}