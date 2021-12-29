using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesCrud.Domain
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
