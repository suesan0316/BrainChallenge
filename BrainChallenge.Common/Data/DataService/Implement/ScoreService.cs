using System;
using System.Collections.Generic;
using System.Linq;
using BrainChallenge.Common.Data.Connection;
using BrainChallenge.Common.Data.Entity.General;
using BrainChallenge.Common.Data.Service.Interface;

namespace BrainChallenge.Common.Data.DataService.Implement
{
    public class ScoreService : IGeneralDataService<ScoreEntity>
    {
        public List<ScoreEntity> Select()
        {
            using (var con = ConnectionProvider.GetConnection())
            {
                var result = from record in con.Table<ScoreEntity>() select record;
                var scoreEntities = result as IList<ScoreEntity> ?? result.ToList();
                return scoreEntities.Count() != 0 ? scoreEntities.ToList() : null;
            }
        }

        public List<ScoreEntity> Select(ScoreEntity t)
        {
            using (var con = ConnectionProvider.GetConnection())
            {
                var result = from record in con.Table<ScoreEntity>() select record;

                if (t.GameId != -1)
                    result = result.Where(data => data.GameId == t.GameId);
                if (t.Score != -1)
                    result = result.Where(data => data.Score == t.Score);
                if (!t.RegistDate.Equals(new DateTime()))
                    result = result.Where(data => data.RegistDate.Equals(t.RegistDate));
                var scoreEntities = result as IList<ScoreEntity> ?? result.ToList();
                return scoreEntities.Count() != 0 ? scoreEntities.ToList() : null;
            }
        }

        public bool Insert(ScoreEntity t)
        {
            using (var con = ConnectionProvider.GetConnection())
            {
                var result = con.Insert(t);
                return result == 1;
            }
        }
    }
}