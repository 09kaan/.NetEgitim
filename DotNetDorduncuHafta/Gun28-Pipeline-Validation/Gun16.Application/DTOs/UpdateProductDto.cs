using System.ComponentModel.DataAnnotations;
namespace Gun16.Application.DTOs;

public class UpdateProductDto
{
    
    public string Name { get; set; } = "";

   
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
}