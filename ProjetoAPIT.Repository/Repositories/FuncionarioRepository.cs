using Microsoft.EntityFrameworkCore;
using ProjetoAPIT.Repository.Contexts;
using ProjetoAPIT.Repository.Entities;
using ProjetoAPIT.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAPIT.Repository.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        //=======================================================
        private readonly SqlServerContext _context;
        public FuncionarioRepository(SqlServerContext context)
        {
            _context = context;
        }
        //=======================================================


        //=======================================================
        public void Create(Funcionario obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }
        //=======================================================
        public void Update(Funcionario obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        //=======================================================
        public void Delete(Funcionario obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }
        //=======================================================
        public List<Funcionario> GetAll()
        {
            return _context.Funcionario.ToList();
        }
        //=======================================================
        public Funcionario GetById(int id)
        {
            return _context.Funcionario.Find(id);
        }
        //=======================================================
    }
}


/*
return _context.Funcionario.FirstOrDefault(u => u.Email.Equals(email));
return _context.Funcionario.FirstOrDefault(u => u.Email.Equals(email)
                                              && u.Senha.Equals(senha)
                                           );
 */