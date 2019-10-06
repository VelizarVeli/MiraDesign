namespace MiraDesign.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
