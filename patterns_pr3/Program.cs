using patterns_pr3.Core.Builder;
using patterns_pr3.Core.DAO;
using patterns_pr3.Core.DAO.MYSQL;
using patterns_pr3.Core.Entities;
using patterns_pr3.Core.FakeDataGenerators;
using patterns_pr3.Core.Memento;
using patterns_pr3.Core.Observer;
using patterns_pr3.Core.Proxy;


namespace patterns_pr3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<DAOFactory>(); 
            builder.Services.AddSingleton<IUserDAO,MySQLUserDAO>(); 
            //builder.Services.AddSingleton<PublicationEditingService>(); 
            //builder.Services.AddSingleton<PublicationOriginator>(); 
            builder.Services.AddSingleton<PublicationCaretaker>(); 
            builder.Services.AddSingleton<AuthenticationService>(); 
            //builder.Services.AddSingleton<IAuthorDAO,MySQLAuthorDAO>(); 
            builder.Services.AddSingleton<AuthorDAOProxy>();
            builder.Services.AddDistributedMemoryCache(); // Use in-memory cache for session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true;
            });

            //builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
           
           
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}");


            app.MapRazorPages();

            app.Run();
        }

        private static void ObserverTest(DAOFactory factory)
        {
            try
            {
                Console.WriteLine("=== Author test ===");
                var authorDAO = factory.GetAuthorDAO();
                if (authorDAO == null) throw new Exception("Author DAO is null");
                string fileNameAuthor = "author_log";
                authorDAO.Attach(new LoggingListenerTXT(fileNameAuthor));
                authorDAO.Attach(new LoggingListenerJSON(fileNameAuthor));
                IFakeDataGenerator<Author> generatorAuthor = new AuthorDataGenerator();
                Author testAuthor = generatorAuthor.GetFakeData();
                authorDAO.AddAuthor(testAuthor);
                Author testAuthor1 = generatorAuthor.GetFakeData();
                authorDAO.UpdateAuthor(new AuthorBuilder().SetId(testAuthor.Id).SetSurname(testAuthor1.Surname).SetAddressId(testAuthor1.Address.Id).
                    SetCountry(testAuthor1.Address.Country).SetPhoneNumber(testAuthor1.PhoneNumber).Build());


                Console.WriteLine("=== Publication test ===");
                string fileNamePublication = "publication_log";
                var PublicationDAO = factory.GetPublicationDAO();
                if (PublicationDAO == null) throw new Exception("PublicationDAO is null");
                PublicationDAO.Attach(new LoggingListenerTXT(fileNamePublication));
                PublicationDAO.Attach(new LoggingListenerJSON(fileNamePublication));
                IFakeDataGenerator<Publication> generatorPublication = new PublicationDataGenerator();
                Publication testPublication = generatorPublication.GetFakeData();

                PublicationDAO.AddPublication(testPublication);

                PublicationDAO.UpdatePublication(new PublicationBuilder().SetId(testPublication.Id).SetGenre(Genre.Fantasy).SetPrintQuality(PrintQuality.Low).Build());

                Console.WriteLine("=== Order test ===");
                string fileName = "order_log";
                var OrderDAO = factory.GetOrderDAO();
                if (OrderDAO == null) throw new Exception("OrderDAO is null");
                OrderDAO.Attach(new LoggingListenerTXT(fileName));
                OrderDAO.Attach(new LoggingListenerJSON(fileName));
                IFakeDataGenerator<OrderBuilder> generator = new OrderDataGenerator();
                OrderBuilder test0 = generator.GetFakeData();

                Console.WriteLine("=== Customer test ===");
                string fileNameCustomer = "customer_log";
                var customerDAO = factory.GetCustomerDAO();
                if (customerDAO == null) throw new Exception("customer DAO is null");
                customerDAO.Attach(new LoggingListenerTXT(fileNameCustomer));
                customerDAO.Attach(new LoggingListenerJSON(fileNameCustomer));
                IFakeDataGenerator<Customer> generatorCustomer = new CustomerDataGenerator();
                Customer c = generatorCustomer.GetFakeData();
                customerDAO.AddCustomer(c);

                Console.WriteLine("=== Printing House Test ===");
                string fileNamePrintHouse = "printhouse_log";
                var PrintingHouseDAO = factory.GetPrintingHouseDAO();
                if (PrintingHouseDAO == null) throw new Exception("PrintingHouse DAO is null");
                PrintingHouseDAO.Attach(new LoggingListenerTXT(fileNamePrintHouse));
                PrintingHouseDAO.Attach(new LoggingListenerJSON(fileNamePrintHouse));
                IFakeDataGenerator<PrintingHouse> generatorPrintingHouse = new PrintingHouseDataGenerator();
                PrintingHouse pr = generatorPrintingHouse.GetFakeData();
                PrintingHouseDAO.AddPrintingHouse(pr);

                test0.SetCustomer(c).SetPrintingHouse(pr);
                Console.WriteLine("=== Add order House Test ===");
                Order otest0 = test0.Build();
                OrderDAO.AddOrder(otest0);
                Console.WriteLine("=== Update order Test ===");
                IFakeDataGenerator<Publication> publGenerator = new PublicationDataGenerator();
                OrderDAO.UpdateOrder(new OrderBuilder().SetId(otest0.Id).SetOrderStatus(OrderStatus.Pending)
                    .SetAcceptanceDate(DateTime.Now).Build());

                OrderDAO.UpdateOrderPublication(new OrderBuilder().SetId(otest0.Id)
                    .AddPublication(publGenerator.GetFakeData())
                    .AddPublication(publGenerator.GetFakeData())
                    .AddPublication(publGenerator.GetFakeData()).Build());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
