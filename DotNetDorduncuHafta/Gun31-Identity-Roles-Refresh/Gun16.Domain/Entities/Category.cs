/*Category class → Categories tablosu
Category nesnesi → Tablodaki bir satır
Id property → Id sütunu
Name property → Name sütunu
*/

namespace Gun16.Domain.Entities;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public List<Product> Products{get;set;} = new();

}