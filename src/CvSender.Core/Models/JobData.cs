namespace CvSender.Core.Models
{
        internal class JobData
        {
                public ContactInfo ContactInfo { get; set; }

                public required List<JobLink> JobsLinks { get; set; }
        }
}
