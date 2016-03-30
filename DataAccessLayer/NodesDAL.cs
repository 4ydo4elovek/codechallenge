using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class NodesDAL
    {
        public static int AddOrUpdate(Entities.Node entity)
        {
            using (var data = new GraphEntities())
            {
                var dbItem = data.Nodes.FirstOrDefault(item => item.Id == entity.Id);
                var isExist = dbItem != null;
                if (!isExist)
                    dbItem = new Node();
                dbItem.Label = entity.Label;
                if (!isExist)
                    data.Nodes.Add(dbItem);
                data.SaveChanges();
                return dbItem.Id;
            }
        }

        public static IList<Entities.Node> Get(Expression<Func<Node,bool>> whereExpression = null)
        {
            using (var data = new GraphEntities())
            {
                var query = whereExpression != null ? data.Nodes.Where(whereExpression) : data.Nodes;
                return query.ToList().Select(item => new Entities.Node(item.Label, LinesDAL.Get(l => l.NodeIdFrom == item.Id
                    || l.NodeIdTo == item.Id),item.Id)).ToList();
            }
        }
    }
}
