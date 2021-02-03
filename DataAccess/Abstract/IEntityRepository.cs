using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint :generik kısıtlama
    //class: referans tip olabilir demek
    //IEntity: IEntity olabilir ya da IEntity implemente eden bir nesne de olabilir.

    // IEntity soyuttur. Ben sout olsun istemiyorum. O nedenle IEntity engel olmak için:new
   public interface IEntityRepository<T> where T:class , IEntity , new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
