using DataAccess.Configuration;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class NordaShopDbContext : DbContext
    {
        public NordaShopDbContext(DbContextOptions<NordaShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CodeResetConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PostReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SlideConfiguration());
            modelBuilder.ApplyConfiguration(new TokenConfirmConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductOptionConfiguration());
            modelBuilder.ApplyConfiguration(new OptionConfiguration());
            modelBuilder.ApplyConfiguration(new WishListConfiguration());
            modelBuilder.ApplyConfiguration(new StoreLocationConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new PostCommentConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new TagInPostConfiguration());
            modelBuilder.ApplyConfiguration(new TagInProductConfiguration());
            modelBuilder.ApplyConfiguration(new GiftExchangeConfiguration());

            modelBuilder.Initialize();
            //base.OnModelCreating(modelBuilder);
        }

    }
}
