namespace Entities.Enemies
{
    public interface ICatcheable
    {
        void Catch(ICatchHandler catchHandler);
    }
}