using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patikaOdevApi.Model;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApiDbContext context;
    private bool disposed;

    public IGenericRepo<Staff> StaffRepo { get; private set; }

    public UnitOfWork(ApiDbContext context)
    {
        this.context = context;

        StaffRepo = new GenericRepo<Staff>(context);
    }

    public void Complete()
    {
        context.SaveChanges();
    }

    public void CompleteWithTransaction() 
    {
        using (var dbContextTransaction = context.Database.BeginTransaction()) 
        {
            try 
            {
                context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex) 
            {
                dbContextTransaction.Rollback();
            }
        }
    }

    protected virtual void Clean(bool disposing) 
    {
        if (!this.disposed) 
        {
            if (disposing) 
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose() 
    {
        Clean(true);
        GC.SuppressFinalize(this);
    }
}
