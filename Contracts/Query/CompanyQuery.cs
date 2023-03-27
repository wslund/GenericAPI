using GenericAPI.Contracts.Entities;
using System.Linq;

namespace GenericAPI.Contracts.Query
{
    public class CompanyQuery : PaigeListQuery<CompanyEntity, CompanyQuery>
    {
        public string? Name { get; set; }
        public string? Discription { get; set; }



        public override IQueryable<CompanyEntity?> AddFilter(IQueryable<CompanyEntity> quaryable, CompanyQuery query )
        {
            if (query == null)
                return quaryable;

            if (!string.IsNullOrEmpty(query.Name))
                quaryable = quaryable.Where(x => x.Name.ToUpper()
                    .Contains(query.Name.ToUpper()));
            

            if (!string.IsNullOrEmpty(query.Discription))
                quaryable = quaryable.Where(x => x.Discription.ToUpper()
                    .Contains(query.Discription.ToUpper()));


            return quaryable;
        }

        //public override IQueryable<CompanyEntity?> Including(IQueryable<CompanyEntity> quaryable)
        //{
        //    return quaryable;
        //}
    }
}
