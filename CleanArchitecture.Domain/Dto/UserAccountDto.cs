using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Dto
{
    public class UserAccountDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
