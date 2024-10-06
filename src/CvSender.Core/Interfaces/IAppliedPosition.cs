namespace CvSender.Core.Interfaces
{
        public interface IAppliedPosition
        {
                public string? Company { get; set; }

                public string Position { get; set; }

                public string? ContactPerson { get; set; }

                public DateTime CreatedUtc { get; set; }
        }
}
