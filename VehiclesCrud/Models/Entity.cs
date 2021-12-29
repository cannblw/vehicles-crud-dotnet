using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesCrud.Models
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
