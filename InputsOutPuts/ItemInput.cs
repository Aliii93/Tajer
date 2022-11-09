using System.ComponentModel.DataAnnotations;

namespace TajerTest.InputsOutPuts
{
    
    public class ItemInput
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(13,MinimumLength = 10)]
        public string Description { get; set; }
        [DateItemInputValidation]
        public DateTime Date { get; set; }
        [Range(1,1000000)]
        public double Price { get; set; }
    }
}
