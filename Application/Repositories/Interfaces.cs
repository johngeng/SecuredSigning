using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IFormRepository
    {
        Task SaveFormDetails(Form form);
    }
}
