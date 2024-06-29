namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        public static List<Product> Products
        {
            get { return _products; }
        }
        static Repository()
        {
            //Repository sınıfı ilk kez kullanılmadan önce çalışır. burada bunu yazmamızın sebebi ilk kez çalışıp kendi veritabanımızı oluşturmak için.
            //_categories listesine Category sınıfından yeni nesneler ekliyor.
            _categories.Add(new Category { CategoryId = 1, Name = "Telefon" });
            _categories.Add(new Category { CategoryId = 2, Name = "Bilgisayar" });
            _products.Add(new Product { ProductID = 1, Name = "IPhone 14", Price = 40000, Image = "1.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductID = 2, Name = "IPhone 15", Price = 50000, Image = "2.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductID = 3, Name = "IPhone 16", Price = 60000, Image = "3.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductID = 4, Name = "IPhone 17", Price = 70000, Image = "4.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductID = 5, Name = "Macbook Air", Price = 80000, Image = "5.jpg", IsActive = true, CategoryId = 2 });
            _products.Add(new Product { ProductID = 6, Name = "Macbook Pro", Price = 90000, Image = "6.jpg", IsActive = true, CategoryId = 2 });
        }
        private static readonly List<Category> _categories = new();
        public static List<Category> Categories
        {
            get { return _categories; }
        }
        public static void CreateProduct(Product entitiy)
        {
            _products.Add(entitiy);
        }
    }
}