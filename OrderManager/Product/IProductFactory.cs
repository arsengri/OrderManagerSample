namespace OrderManager
{
    public interface IProductFactory
    {
        Product CreateProduct(string pName, double pPrice, int pQuanity, bool pIsImported);
    }
}