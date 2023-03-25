using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patikaOdevApi.Model;

public interface IUnitOfWork : IDisposable
{
    void CompleteWithTransaction();
    void Complete();
}

