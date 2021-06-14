using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Core.Domain.Common.Data
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
