using AutoMapper;

namespace AccountingSyatem.Shared.Automapper
{
    public interface IMapConfig
    {
        void ConfigMapToSource(IMapperConfiguration cfg);
        void ConfigMapToDestination(IMapperConfiguration cfg);
    }
}