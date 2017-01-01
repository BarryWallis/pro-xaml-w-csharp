using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]
namespace ApressXaml.Usb
{
    public class UserLogOnService : IUserLogOnService
    {
        public UserLogOnService()
        {

        }

        public string GreetUser(string validName)
        {
            if (string.IsNullOrWhiteSpace(validName))
                throw new ArgumentNullException(nameof(validName));

            return $"Hello {validName}!";
        }
    }
}
