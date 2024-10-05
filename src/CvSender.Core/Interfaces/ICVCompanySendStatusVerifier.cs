namespace CvSender.Core.Interfaces
{
        public interface ICVCompanySendStatusVerifier
        {
                public bool IsCvWasSendedToCompany(string company, string jobTitle);

                public bool IsCvWasSendedToPerson(string contactPerson, string jobTitle);
        }
}
