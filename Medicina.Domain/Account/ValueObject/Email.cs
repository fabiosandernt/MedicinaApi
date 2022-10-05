using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Domain.Account.ValueObject
{
    public class Email
    {
        public Email()
        {

        }

        public Email(string email)
        {
            Valor = email ?? throw new ArgumentNullException(nameof(email));
        }

        public string Valor { get; set; }
    }
}
