namespace Basic4ServicesDI.AllServices
{
    public interface ITrans
    {
        public int Add();
    }

    public interface IScoped
    {
        public int Add();
    }

    public interface ISingle
    {
        public int Add();
    }
}