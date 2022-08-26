using Core.Intarfaces;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {

        private  IGenericRepo<T> _repo;

        

        private readonly DataContext _context;


        public IGenericRepo<T> repo
        {
            get
            {
                return _repo ?? (_repo = new GenericRepo<T>(_context));

            }
        }

        public UnitOfWork(DataContext context)
        {
            _context = context;

        }


        public void save()
        {
            _context.SaveChanges();
        }
    }
}
