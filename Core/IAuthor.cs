using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IAuthor
    {
        public string Forename { get; }
        public string MiddleNames { get; }
        public string Surname { get; }
        public string MiddleNameInitials { get; }
    }
}
