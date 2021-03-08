namespace ShareURLink.Models
{
    public class LikeModel
    {        
        public int Id { get; set; }
        public UserModel User { get; set; }      
        public LinkModel Link { get; set; }
        public bool IsLiked { get; set; }
    }
}
