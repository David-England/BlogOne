using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IAuthor
    {
        public string GetForename();
        public string GetMiddleNames();
        public string GetSurname();
        public string GetMiddleNameInitials();
    }
}
