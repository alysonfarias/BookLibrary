using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]

        public long Id { get; set; }
    }
}
