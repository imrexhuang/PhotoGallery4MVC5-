using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace photoGallery.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
		
        public ClaimsIdentity GenerateUserIdentity(UserManager<ApplicationUser> manager)
        {
            var userIdentity =  manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }		
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("photoGallery", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // https://blog.yowko.com/aspnet-identity-2-entityframework-oracle/
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //這必需在第一行
            base.OnModelCreating(modelBuilder);
            //schema 名稱，如果建立時沒有刻意指定小寫，預設就是大寫
            //modelBuilder.HasDefaultSchema("dbo");
            //以下依實際情境來調整 table name
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins");

            // http://blogs.uuu.com.tw/Articles/post/2018/01/10/ASPNET-Identity-Core%E5%85%A5%E9%96%80-1.aspx
            //IdentityUser ：代表個別使用者資訊。
            //IdentityRole：代表使用者角色（Role）資訊。
            //IdentityUserRole：用來定義使用者隸屬於特定的群組。
            //IdentityUserClaim：代表特定的使用者宣告（Claim）。
            //IdentityUserLogin：代表使用者登入。
            //IdentityUserToken：代表一個使用者的驗證（authentication）
            //IdentityRoleClaim：代表特定的角色宣告（Claim）。
        }

    }
}