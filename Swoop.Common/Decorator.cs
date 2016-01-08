namespace Swoop.Common
{
    public class Decorator<T>
    {
        public T model;

        public Decorator(T model)
        {
            this.model = model;
        }
    }
}
