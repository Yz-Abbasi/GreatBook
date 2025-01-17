using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain.Utils;

namespace Common.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public string Phone { get; private set; }

    public PhoneNumber(string phone)
    {
        if(string.IsNullOrWhiteSpace(phone) || phone.IsText() || phone.Length != 11)
            throw new InvalidDomainDataException("Phone number is not valid!");
        
        Phone = phone;
    }
}