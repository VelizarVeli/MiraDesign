using System.ComponentModel.DataAnnotations;
using MiraDesign.Models.Contracts;

namespace MiraDesign.Models
{
    public abstract class BaseId : IBaseId<int>
    {
        [Key]
        public int Id { get; set; }
    }
}
