using Microsoft.AspNet.Identity.EntityFramework;

namespace OrderEntry.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AzureConnection")
        {
        }

        public System.Data.Entity.DbSet<OrderEntry.Models.Line> Lines { get; set; }

        public System.Data.Entity.DbSet<OrderEntry.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<OrderEntry.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<OrderEntry.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<OrderEntry.Models.ShipTo> ShipTos { get; set; }

        public System.Data.Entity.DbSet<OrderEntry.Models.Warehouse> Warehouses { get; set; }

        public System.Data.Entity.DbSet<OrderEntry.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<OrderEntry.Models.Tendering.Check> Checks { get; set; }

        public System.Data.Entity.DbSet<OrderEntry.Models.Tendering.CreditCard> CreditCards { get; set; }

        public System.Data.Entity.DbSet<OrderEntry.Models.Tender> Tenders { get; set; }
    }
}