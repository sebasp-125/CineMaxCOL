
namespace CineMaxCOL_DAL.Repository.Interface
{
    public interface ISendEmail
    {
        Task<bool> ExtractInformationAboutEmail();
    }
}