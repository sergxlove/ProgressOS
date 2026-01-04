using ProgressOS.Core.Services;

namespace ProgressOS.Core.Abstractions
{
    public interface IEncryptionService
    {
        EncryptionResponce DecryptionData(string cryptingData);
        EncryptionResponce EncryptionData(string data);
    }
}