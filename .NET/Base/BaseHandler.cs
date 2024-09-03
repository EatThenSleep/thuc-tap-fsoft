public abstract BaseQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    protected readonly DbContext _context;
    protected readonly IMapper _mapper;

    public BaseQueryHandler(DbContext context, IMapper _mapper)
    {
        _context = context;
        _mapper = _mapper;
    }

    public abstract Task<TResponse> Handle(TRequest request);
}

public abstract class BaseCommandHandler<TRequest, TResponse> : BaseQueryHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    protected readonly IUserService _userService;
    protected BaseCommandHandler(DbContext context, IUserService userService, IMapper mapper) : base(context, mapper)
    {
        _userService = userService;
    }
}
