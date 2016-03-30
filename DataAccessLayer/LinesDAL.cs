using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class LinesDAL
    {
        public static void Add(IList<Entities.Line> list)
        {
            using (var data = new GraphEntities())
            {
                foreach (var entity in list)
                {
                    var dbItem = data.Lines.FirstOrDefault(item => 
                        item.Id == entity.Id && item.Id != 0 
                        || item.NodeIdFrom == entity.NodeIdFrom && item.NodeIdTo == entity.NodeIdTo
                        || item.NodeIdFrom == entity.NodeIdTo && item.NodeIdTo == entity.NodeIdFrom);
                    var isExist = dbItem != null;
                    if (!isExist)
                        dbItem = new Line();
                    dbItem.NodeIdFrom = entity.NodeIdFrom;
                    dbItem.NodeIdTo = entity.NodeIdTo;
                    if (!isExist)
                        data.Lines.Add(dbItem);
                }
                data.SaveChanges();
            }
        }

        public static int AddOrUpdate(Entities.Line entity)
        {
            using (var data = new GraphEntities())
            {
                var dbItem = data.Lines.FirstOrDefault(item =>
                        item.Id == entity.Id && item.Id != 0
                        || item.NodeIdFrom == entity.NodeIdFrom && item.NodeIdTo == entity.NodeIdTo
                        || item.NodeIdFrom == entity.NodeIdTo && item.NodeIdTo == entity.NodeIdFrom);
                var isExist = dbItem != null;
                if (!isExist)
                    dbItem = new Line();
                dbItem.NodeIdFrom = entity.NodeIdFrom;
                dbItem.NodeIdTo = entity.NodeIdTo;
                if (!isExist)
                    data.Lines.Add(dbItem);
                data.SaveChanges();
                return dbItem.Id;
            }
        }

        public static IList<Entities.Line> Get(Expression<Func<Line, bool>> whereExpression = null)
        {
            using (var data = new GraphEntities())
            {
                var query = whereExpression != null ? data.Lines.Where(whereExpression) : data.Lines;
                return query.ToList().Select(item => new Entities.Line(item.NodeIdFrom,item.NodeIdTo, item.Id)).ToList();
            }
        }
    }
}
