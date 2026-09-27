namespace Gun16.Application.Common.Results;

public static class CategoryErrors
{
    public static Error NotFound(int categoryId)
    {
        return new Error(
            "Category.NotFound",
            $"{categoryId} kimliğine sahip kategori bulunamadı."
        );
    }
}

public static class ProductErrors
{
    public static Error NotFound(int productId)
    {
        return new Error(
            "Product.NotFound",
            $"{productId} kimliğine sahip ürün bulunamadı."
        );
    }
}