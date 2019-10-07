namespace MiraDesign.Models
{
    public class Image : BaseId
    {
        public string Link { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
