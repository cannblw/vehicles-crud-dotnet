using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclesTest.Models
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
