using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.InterfaceService
{
    public interface ISequenceService
    {
        Task<int> GetCadidateNewId();
    }
}
