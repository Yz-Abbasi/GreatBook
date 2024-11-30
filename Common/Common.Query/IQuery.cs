using MediatR;

namespace Common.Query;
    public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {
        
    }

    public class QueryFilter<TResponse, TParam> : IRequest<TResponse> where TResponse : BaseFilter where TParam : BaseFilterParam
    {
        public TParam FilterParam { get; set; }
        public QueryFilter(TParam filterParam)
        {
            FilterParam = filterParam;
        }
    }