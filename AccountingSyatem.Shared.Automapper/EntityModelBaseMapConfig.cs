using AutoMapper;

namespace AccountingSyatem.Shared.Automapper
{
    public abstract class EntityModelBaseMapConfig<TEntity, TModel> : IMapConfig
    {
        protected abstract void MapToModel(IMappingExpression<TEntity, TModel> map);

        protected abstract void MapToEntity(IMappingExpression<TModel, TEntity> map);

        public virtual void ConfigMapToSource(IMapperConfiguration cfg)
        {
            MapToModel(cfg.CreateMap<TEntity, TModel>());
        }

        public virtual void ConfigMapToDestination(IMapperConfiguration cfg)
        {
            MapToEntity(cfg.CreateMap<TModel, TEntity>());
        }
    }
}
