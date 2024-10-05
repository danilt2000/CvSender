using CvSender.Core.Models;

namespace CvSender.Core.Interfaces
{
        public interface ICVManager
        {
                public void SendCv(string link, UserInfo userInfo);
        }
}
