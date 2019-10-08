using System.ComponentModel.DataAnnotations;

namespace MiraDesign.Models.Contracts
{
    interface IBaseId<T>
    {
        [Key]
        T Id { get; set; }
    }
}
