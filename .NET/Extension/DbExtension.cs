// DelFlg is used for soft delete
// 0: is not deleted
// 1: is deleted

namespace Project.Application.Databases
{
    /*
        var maxMinTourQuery = _context.MstTourTariffs
                                      .AsNoTracking()
                                      .Where(x => x.DelFlg == 0)
                                      .WhereIfNotNull(periodFrom, x => x.ValidPeriodFrom >= periodFrom)
                                      .GroupBy(x => x.SicKey)
                                      .ToList();
    */
    public static class DbContextExtension
    {   
        public static IQueryable<T> WhereIfNotNull<T>(this IQueryable<T> query, object input, Expression<Func<T,bool>> whereClause)
        {
            if(input != null)
            {
                // If input is not null and not string, just apply condition
                if(input is not string str)
                {
                    return query.Where(whereClause);
                }
                else
                {
                    if(!string.IsNullOrEmpty(str.Trim()))
                    {
                        return query.Where(whereClause);
                    }
                }
            }
            return query;
        }

        /*
            _context.ItnLuggages.CreateWithTracking(itnLuggages, _userService.UserId)
        */
        public static void CreateWithTracking<T>(this DbSet<T> entityStore,
                                                T entity, string empCode) where T : EntityMaster
        {
            entity.InsDate = DateTime.UtcNow;
            entity.UpdDate = DateTime.UtcNow;
            entity.InsEmpCode = empCode;
            entity.UpdEmpCode = empCode;
            entityStore.Add(entity);   
        }

        /*
            _context.ItnSaleAir.UpdateWithTracking(item, request.EmpCode);
        */
        public static void UpdateWithTracking<T>(this DbSet<T> entityStore,
        T entity, string empCode) where T : EntityMaster
        {
            entity.UpdDate = DateTime.UtcNow;
            entity.UpdEmpCode = empCode;
            entityStore.UpdDate(entity);
        }

        
        public static void BatchUpdateWithTracking(this DbSet<T> entityStore,
        ICollection<T> entities, string empCode) where T : EntityMaster
        {
            foreach(var entity in entities)
            {
                entity.UpdDate = DateTime.UtcNow;
                entity.UpdEmpCode = empCode;
                entityStore.Update(entity);
            }
        }

        public static void BatchCreateWithTracking(this DbSet<T> entityStore,
        ICollection<T> entities, string empCode) where T : EntityMaster
        {
            var currentDate = DateTime.UtcNow;
            foreach(var entity in entities)
            {
                entity.InsDate = currentDate;
                entity.UpdEmpCode = currentDate;
                entity.InsEmpCode = empCode;
                entity.UpdEmpCode = empCode;
                entityStore.Add(entity);
            }
        }

        public static void DeleteWithTracking<T>(this DbSet<T> entityStore,
        T entity, string empCode) where T : EntityMaster
        {
            entity.DelFlg = 1;
            entity.UpdDate = DateTime.UtcNow;
            entity.UpdEmpCode = empCode;
            entityStore.Update(entity);
        }

        public static void BatchDeleteWithTracking<T>(this DbSet<T> entityStore,
        ICollection<T> entities, string empCode) where T : EntityMaster
        {
            foreach(var entity in entities)
            {
                entity.DelFlg = 1;
                entity.UpdDate = DateTime.UtcNow;
                entity.UpdEmpCode = empCode;
                entityStore.Update(entity);
            }
        }


    }

}