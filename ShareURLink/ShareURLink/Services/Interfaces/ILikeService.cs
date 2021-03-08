using ShareURLink.Models;

namespace ShareURLink.Services.Interfaces
{
    public interface ILikeService
    {
        public void CreateLike(LinkModel link, UserModel user);
        public string ChangeStatus(LikeModel like);
    }
}
