using Microsoft.AspNetCore.Identity;
using StefaniniChallenge.Domain.Entities;
using StefaniniChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniChallenge.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext ctx, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager).Wait();
            SeedAdministrators(userManager).Wait();
            SeedSellers(userManager).Wait();

            if (!ctx.Region.Any())
            {
                SeedRegions(ctx);
            }

            if (!ctx.City.Any())
            {
                SeedCities(ctx);
            }

            if (!ctx.Classification.Any())
            {
                SeedClassifications(ctx);
            }

            if (!ctx.Gender.Any())
            {
                SeedGenders(ctx);
            }
        }

        private static void SeedRegions(ApplicationContext ctx)
        {
            String[] regions = { "Sul", "Sudeste", "Centro-Oeste", "Norte", "Nordeste" };
            foreach (var region in regions)
            {
                var regionObj = ctx.Region.FirstOrDefault(r => r.Name.Equals(region));
                if (regionObj == null)
                {
                    regionObj = new Region
                    {
                        Name = region
                    };

                    ctx.Add(regionObj);
                    ctx.SaveChanges();
                }
            }
        }

        private static void SeedGenders(ApplicationContext ctx)
        {
            String[] genders = { "Female", "Male" };
            foreach (var gender in genders)
            {
                var genderObj = ctx.Gender.FirstOrDefault(r => r.Name.Equals(gender));
                if (genderObj == null)
                {
                    genderObj = new Gender
                    {
                        Name = gender
                    };

                    ctx.Add(genderObj);
                    ctx.SaveChanges();
                }
            }
        }

        private static void SeedClassifications(ApplicationContext ctx)
        {
            String[] classifications = { "VIP", "Regular", "Sporadic" };
            foreach (var classification in classifications)
            {
                var classificationObj = ctx.Classification.FirstOrDefault(r => r.Name.Equals(classification));
                if (classificationObj == null)
                {
                    classificationObj = new Classification
                    {
                        Name = classification
                    };

                    ctx.Add(classificationObj);
                    ctx.SaveChanges();
                }
            }
        }

        private static void SeedCities(ApplicationContext ctx)
        {
            var regionObj = ctx.Region.FirstOrDefault(r => r.Name.Equals("Sul"));
            var cityObj = new City
            {
                Name = "Porto Alegre",
                Region = regionObj
            };
            ctx.Add(cityObj);
            ctx.SaveChanges();
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdministrators(UserManager<IdentityUser> userManager)
        {
            var userAdm = userManager.FindByEmailAsync("admin@sellseverything.com");

            if (userAdm.Result == null)
            {
                var newAdministrator = new IdentityUser
                {
                    UserName = "admin@sellseverything.com",
                    Email = "admin@sellseverything.com"
                };

                var administratorPwd = "admin123";
                IdentityResult checkAdministrator = await userManager.CreateAsync(newAdministrator, administratorPwd);

                if (checkAdministrator.Succeeded)
                {
                    IdentityUser administratorObj = await userManager.FindByEmailAsync("admin@sellseverything.com");
                    await userManager.AddToRoleAsync(administratorObj, Enum.GetName(typeof(Roles), Roles.Administrator));
                }
            }
        }

        private static async Task SeedSellers(UserManager<IdentityUser> userManager)
        {
            String[] sellers = { "seller1@sellseverything.com", "seller2@sellseverything.com" };

            foreach (var seller in sellers)
            {
                var sellerUser = userManager.FindByEmailAsync(seller);

                if (sellerUser.Result == null)
                {
                    var newSeller = new IdentityUser
                    {
                        UserName = seller,
                        Email = seller
                    };

                    var sellerPwd = "seller1123";
                    if (seller == "seller2@sellseverything.com")
                    {
                        sellerPwd = "seller2123";
                    }
                    IdentityResult checkSeller = await userManager.CreateAsync(newSeller, sellerPwd);

                    if (checkSeller.Succeeded)
                    {
                        IdentityUser sellerObj = await userManager.FindByEmailAsync(seller);
                        await userManager.AddToRoleAsync(sellerObj, Enum.GetName(typeof(Roles), Roles.Seller));
                    }
                }
            }
        }
    }
}
