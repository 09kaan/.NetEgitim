/* CONTROLLER ve ROUTİNG
Minimal endpoint’lerden controller yapısına geçerek ilgili HTTP işlemlerini ayrı class’larda toplamaya başladık. 
[ApiController], [Route], [HttpGet], ControllerBase ve IActionResult yapılarını kullandık. 
Route parametresiyle /api/products/1 gibi adreslerden ID alıp ürün aradık. 
Bulunan ürün için Ok, bulunamayan ürün için NotFound döndürdük ve aynı route’un-
iki kez tanımlanmasının AmbiguousMatchException oluşturduğunu gördük.