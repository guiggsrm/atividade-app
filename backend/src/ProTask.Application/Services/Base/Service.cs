using AutoMapper;
using ProTask.Application.Interfaces.Base;
using ProTask.Domain.Interfaces.Base;

namespace ProTask.Application.Services.Base
{
    public abstract class Service<TDTO, TNEWDTO, TEntity, Key> : IService<TDTO, TNEWDTO, Key>
    {
        protected readonly IRepository<TEntity, Key> _repository;
        protected readonly IMapper _mapper;

        protected Service(IMapper mapper, IRepository<TEntity, Key> repository)
        {
            _mapper = mapper;
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        public virtual async Task<TDTO> Create(TNEWDTO modelDTO)
        {
            var newModel = _mapper.Map<TEntity>(modelDTO);
            var model = await _repository.CreateAsync(newModel);
            return _mapper.Map<TDTO>(model);
        }

        public virtual async Task<IEnumerable<TDTO>> Get()
        {
            return _mapper.Map<IEnumerable<TDTO>>((await _repository.GetAsync()));
        }

        public virtual async Task<TDTO?> Get(Key id)
        {
            return _mapper.Map<TDTO>((await _repository.GetAsync(id)));
        }

        public virtual async Task<bool> Remove(Key id)
        {
            var model = await _repository.GetAsync(id);
            if (model != null)
            {
                await _repository.RemoveAsync(model);
                return true;
            }
            return false;
        }
    }
}