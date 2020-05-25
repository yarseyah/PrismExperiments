namespace PrismDialogsMdix.Services
{
    using System.Linq;

    public class FruitService : IFruitService
    {
        private string[] fruit = { "Apple", "Orange", "Pear", "Banana" };

        public string[] GetAll() => fruit.ToArray();
    }

    public interface IFruitService
    {
        string[] GetAll();
    }
}
