// Microsoft.AspNetCore.Mvc alanını ekle.
using Microsoft.AspNetCore.Mvc;
// Bu class'ın API controller olduğunu belirten attribute'u ekle.
[ApiController]
[Route("api/[controller]")]
// Temel adresi api/[controller] olarak belirleyen attribute'u ekle.

// BooksController isminde public bir class oluştur.
// ControllerBase class'ından kalıtım al.
public class BooksController : ControllerBase
{
    private static readonly string[] Books =
        {
            "Clean Code",
            "C# in Depth"
        };
   // Bu action'ın GET isteğini karşılayacağını belirten
    // attribute'u ekle.
    // GetAll isminde public bir action metodu oluştur.
    // Dönüş tipi IActionResult olsun.
    [HttpGet]
    public IActionResult GetAll()
    {
        // "Clean Code" ve "C# in Depth" değerlerinden
        // oluşan bir string dizisi oluştur.
        
        return Ok(Books);
        // Diziyi 200 OK ile döndür.
    }

    // int route parametresi kabul eden HttpGet attribute'u

    // GetByIndex isimli public action
    // Dönüş tipi IActionResult
    // int index parametresi
    [HttpGet("{index:int}")]
    public IActionResult GetByIndex(int index){
        // index 0'dan küçük VEYA Books.Length'e eşit/büyük mü?
        if (index < 0 || index >= Books.Length){
            // NotFound ile hata nesnesi döndür.
            return NotFound(new{
                Message = "Kitap bulunamadı."
            });
        }
            // Books dizisindeki ilgili elemanı Ok ile döndür.
        return Ok(Books[index]);
    }
}