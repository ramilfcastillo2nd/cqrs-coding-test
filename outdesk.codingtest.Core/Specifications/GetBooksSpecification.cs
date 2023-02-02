using outdesk.codingtest.Core.Entities;

namespace outdesk.codingtest.Core.Specifications
{
    public class GetBooksSpecification: BaseSpecification<Book>
    {
        public GetBooksSpecification(BookSpecParams specParams)
            :base(x =>
                  (x.Name.ToLower().Contains(specParams.Search))
            )
        {
            AddOrderBy(x => x.Name);
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }
    }
}
