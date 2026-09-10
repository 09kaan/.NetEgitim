/*1. Client JSON gönderir
            ↓
2. ASP.NET Core JSON'u dto yapar
            ↓
3. Controller dto'yu doğrular
            ↓
4. Controller id ve dto'yu service'e verir
            ↓
5. Service id ile Product'ı bulur
            ↓
6. Service dto.Name değerini product.Name'e aktarır
            ↓
7. Service dto.Price değerini product.Price'a aktarır
            ↓
8. Service veritabanına kaydeder
            ↓
9. Service Product veya null döndürür
            ↓
10. Controller product is null kontrolü yapar
            ↓
11. 200 veya 404 döndürür
*/
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {   
        List<Product> products = await _service.GetAllAsync();
        // Products listesini 200 OK ile döndür.
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        // Service'in GetById metodunu çağır.
        // URL'den gelen id değerini metoda gönder.
        Product? product = await _service.GetByIdAsync(id);

        // Service null döndürdüyse ürün bulunamamıştır.
        if (product is null)
        {
            return NotFound(new
            {
                Message = "Ürün bulunamadı."
            });
        }

        // Bulunan ürünü 200 OK ile döndür.
        return Ok(product);
    }
    [HttpGet("expensive")]
    public async Task<IActionResult> GetExpensive()
    {
        List<Product> products =
        await _service.GetAllAsync();

        List<Product> expensiveProducts = products
            .Where(product => product.Price >= 500)
            .ToList();

        // Listeyi 200 OK ile döndür.
        return Ok(expensiveProducts);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {   
        // dto.Name boş, null veya yalnızca boşluklardan mı oluşuyor?
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return BadRequest(new
            {
                Message = "Ürün adı boş olamaz."
            });
        }
        // DTO'yu service'in Create metoduna gönder.
        // Service'in döndürdüğü ürünü product değişkenine koy.

        // dto.Price sıfır veya negatif mi?
        if (dto.Price <= 0)
        {
            return BadRequest(new
            {
                Message = "Fiyat pozitif olmalıdır."
            });
        }

        Product product = await _service.CreateAsync(dto);

        // Oluşturulan ürünü 201 Created ile döndür.
        return CreatedAtAction(
        nameof(GetById),
        new { id = product.Id },
        product
    );
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto dto)
    {
        // Ürün adı boş mu?
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return BadRequest(new
            {
                Message = "Ürün adı boş olamaz."
            });
        }

        // Fiyat sıfır veya negatif mi?
        if (dto.Price <= 0)
        {
            return BadRequest(new
            {
                Message = "Fiyat pozitif olmalıdır."
            });
        }

        // Service'in UpdateAsync metodunu çağır.
        Product? product = await _service.UpdateAsync(id, dto);  //product servisten gelen sonuç

        // Service null döndürdüyse ürün bulunamamıştır.
        if (product is null)
        {
            return NotFound(new
            {
                Message = "Ürün bulunamadı."
            });
        }

        // Güncellenen ürünü 200 OK ile döndür.
        return Ok(product);
    }

    [HttpPatch("{id:int}/price")]
    public async Task<IActionResult> UpdatePrice(int id, UpdatePriceDto dto )
    {
        // Yeni fiyat sıfır veya negatif mi?
        if (dto.Price <= 0)
        {
            return BadRequest(new
            {
                Message = "Fiyat pozitif olmalıdır."
            });
        }

        // ID ve DTO'yu service'e gönder.
        Product? product = await _service.UpdatePriceAsync(id, dto);

        // Service null döndürdüyse ürün bulunamadı.
        if (product is null)
        {
            return NotFound(new
            {
                Message = "Ürün bulunamadı."
            });
        }

        // Güncellenen ürünü 200 OK ile döndür.
        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        // ID değerini service'in DeleteAsync metoduna gönder.
        bool deleted =
            await _service.DeleteAsync(id);

        // deleted false ise ürün bulunamamıştır.
        if (deleted == false)
        {
            return NotFound(new
            {
                Message = "Ürün bulunamadı."
            });
        }

        // Silme başarılıysa 204 No Content döndür.
        return NoContent();
    }
}