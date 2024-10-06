using CvSender.Core.Interfaces;

namespace CvSender.Core
{
        internal class CoreAppliedPosition : IAppliedPosition
        {
                public string? Company { get; set; }

                public required string Position { get; set; }

                public string? ContactPerson { get; set; }

                public DateTime CreatedUtc { get; set; }
        }
}
