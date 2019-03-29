using System;
using System.Collections.Generic;

namespace Appreciation.Core.Interfaces
{
    public interface IAppreciationRepository
    {
        List<Models.Appreciation> GetAppreciations(DateTime from, DateTime to);
    }
}
