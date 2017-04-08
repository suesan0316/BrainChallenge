using BrainChallenge.Common.Data.Service.Interface;
using System.Collections.Generic;
using BrainChallenge.Common.Data.Connection;
using BrainChallenge.Common.Data.Entity.General;
using System.Linq;

namespace BrainChallenge.Common.Data.DataService.Implement
{
   public class SampleDataService : IGeneralDataService<SampleEntity>
    {
        public bool insert(SampleEntity t)
        {
            using (var con = ConnectionProvider.getConnection())
            {
                var result = con.Insert(t);

                if (result == 1) return true;

                return false;
            }
        }

        public List<SampleEntity> select()
        {
            using (var con = ConnectionProvider.getConnection()) {
                var result = from record in con.Table<SampleEntity>() select record;

                return result.Count() != 0 ? result.ToList() : null;
            }
        }

        public List<SampleEntity> select(SampleEntity t)
        {
            using (var con = ConnectionProvider.getConnection())
            {
                var result = from record in con.Table<SampleEntity>() select record;

                if(t.Id != -1)
                {
                    result = result.Where(data => data.Id == t.Id);
                }
                if(t.Name != null)
                {
                    result = result.Where(data => data.Name.Equals(t.Name));
                }

                return result.Count() != 0 ? result.ToList() : null;
            }
        }
    }
}
