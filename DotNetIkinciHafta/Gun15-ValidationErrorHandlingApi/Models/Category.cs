/*Category class → Categories tablosu
Category nesnesi → Tablodaki bir satır
Id property → Id sütunu
Name property → Name sütunu
*/

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public List<Product> Products{get;set;} = new();

}