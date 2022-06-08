namespace CrowdsourcingX.Web.Models
{
    public class PictureModel : BaseModel
    {
        public string Data { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        
    }
}
