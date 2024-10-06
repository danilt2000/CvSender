using CvSender.Core.Models;

namespace CvSender.Core.Interfaces
{
        public interface ICVManager
        {
                public void SendCvToUnappliedPositions(string link, UserInfo userInfo);
        }
}
