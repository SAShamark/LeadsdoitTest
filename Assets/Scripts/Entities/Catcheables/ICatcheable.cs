using Entities.Characters;

namespace Entities.Catcheables
{
    public interface ICatcheable
    {
        void Catch(ICatchHandler catchHandler);
    }
}