using FreelancingApp.WebApp.Helpers;
using FreelancingApp.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FreelancingApp.WebApp.Data
{
    public class Seed
    {
        public async static void SeedData(IApplicationBuilder builder)
        {
            await SeedCurrencies(builder);
            await SeedSkills(builder);
            await SeedRolesAsync(builder);
            await SeedUsersAsync(builder);
            await SeedExpieriences(builder);
            await SeedFreelancers(builder);
            await SeedCompanies(builder);
            await SeedJobs(builder);
        }

        public static async Task SeedJobs(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>() ?? throw new ArgumentNullException();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>() ?? throw new ArgumentNullException();
            if (!await context.Jobs.AnyAsync())
            {
                var jobs = new List<Job>()
                {
                    new Job()
                    {
                        Title = "Senior .NET Developer",
                        Description = "We are looking for a .NET developer to join our team",
                        Company = await context.Companies.FirstOrDefaultAsync(x => x.CompanyName == "Boogle") ?? throw new ArgumentNullException(),
                        Currency = await context.Currencies.FirstOrDefaultAsync(x => x.Name == "USD") ?? throw new ArgumentNullException(),
                        PaymentAmount = 100,
                        IsHourly = true,
                        CreatedAt = DateTime.Now,
                        Deadline = DateTime.Now.AddDays(30),
                        RequiredExperience = new List<Experience>()
                        {
                            await context.Experiences.Include(x => x.Skill).FirstOrDefaultAsync(x => x.Skill.Name == "C#" && x.Level >= 5) ?? throw new ArgumentNullException()
                        }
                    }
                };
            }

            await context.SaveChangesAsync();
        }
        public static async Task SeedCompanies(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>() ?? throw new ArgumentNullException();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>() ?? throw new ArgumentNullException();

            if (!await context.Companies.AnyAsync())
            {
                var companies = new List<Company>()
                {
                    new Company()
                    {
                        CompanyName = "Boogle",
                        Description = "Boogle is an Indian multinational technology company that specializes in IT Support-related services and products, which include online advertising technologies, a help desk, never ending tickets and curry",
                        ContactInfo = new ContactInfo()
                        {
                            Email = "support@boogle.com",
                            PhoneNumber = "+1 666-253-0000",
                            LinkedIn = "https://www.linkedout.com/company/boogle/",
                        },
                        Owner = await userManager!.FindByEmailAsync("richard.gates@freelancing.com")!,
                        Moderators = new List<AppUser>()
                        {
                            await userManager!.FindByEmailAsync("john.doe@freelancing.com")!
                        }
                    }
                };
            }

            await context.SaveChangesAsync();
        }
        public static async Task SeedSkills(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>() ?? throw new ArgumentNullException();

            if (!await context.Skills.AnyAsync())
            {
                var skills = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "C#",
                    },
                    new Skill()
                    {
                        Name = "Java",
                    },
                    new Skill()
                    {
                        Name = "Python",
                    },
                    new Skill()
                    {
                        Name = "PHP",
                    },
                    new Skill()
                    {
                        Name = "C++",
                    },
                    new Skill()
                    {
                        Name = "C",
                    },
                    new Skill()
                    {
                        Name = "JavaScript",
                    },
                    new Skill()
                    {
                        Name = "TypeScript",
                    },
                    new Skill()
                    {
                        Name = "Swift",
                    },
                    new Skill()
                    {
                        Name = "R",
                    },
                    new Skill()
                    {
                        Name = "Kotlin",
                    },
                    new Skill()
                    {
                        Name = "GO",
                    },
                    new Skill()
                    {
                        Name = "Ruby",
                    },
                    new Skill()
                    {
                        Name = "Scala",
                    },
                    new Skill()
                    {
                        Name = "Perl",
                    },
                    new Skill()
                    {
                        Name = "Rust",
                    },
                    new Skill()
                    {
                        Name = "Dart",
                    },
                    new Skill()
                    {
                        Name = "Elixir",
                    },
                    new Skill()
                    {
                        Name = "Julia",
                    },
                    new Skill()
                    {
                        Name = "Haskell",
                    },
                    new Skill()
                    {
                        Name = "Erlang",
                    },
                    new Skill()
                    {
                        Name = "Clojure",
                    },
                    new Skill()
                    {
                        Name = "Groovy",
                    },
                    new Skill()
                    {
                        Name = "D",
                    },
                    new Skill()
                    {
                        Name = "Lua",
                    },
                    new Skill()
                    {
                        Name = "Matlab",
                    },
                    new Skill()
                    {
                        Name = "Visual Basic",
                    },
                    new Skill()
                    {
                        Name = "Objective-C",
                    },
                    new Skill()
                    {
                        Name = "Assembly",
                    },
                    new Skill()
                    {
                        Name = "PL/SQL",
                    },
                    new Skill()
                    {
                        Name = "Scratch",
                    },
                    new Skill()
                    {
                        Name = "Delphi",
                    }
                };
                await context.Skills.AddRangeAsync(skills);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedCurrencies(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>() ?? throw new ArgumentNullException();

            if (!await context.Currencies.AnyAsync())
            {
                var currencies = CurrencyTools.GetCurrencyMap();
                foreach (var currency in currencies)
                {
                    await context.Currencies.AddAsync(new Currency()
                    {
                        Name = currency.Key,
                        Symbol = currency.Value
                    });
                }
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedRolesAsync(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>() ?? throw new ArgumentNullException();
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await roleManager.RoleExistsAsync(UserRoles.Freelancer))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Freelancer));
            if (!await roleManager.RoleExistsAsync(UserRoles.CompanyWorker))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.CompanyWorker));
        }
        public static async Task SeedUsersAsync(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>() ?? throw new ArgumentNullException();

            #region admin
            var adminEmail = "admin1234@freelancing.com";
            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                var newAdmin = new AppUser()
                {
                    UserName = "admin",
                    Email = adminEmail,
                    Contact = new ContactInfo()
                    {
                        Email = adminEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedin.com/in/przemyslaw-budzisz/"
                    }
                };
                await userManager.CreateAsync(newAdmin, "Admin1234!");
                await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
            }
            #endregion

            #region freelancer
            var freelancerEmail = "freebird@freelancing.com";
            var freelancer = await userManager.FindByEmailAsync(freelancerEmail);
            if (freelancer == null)
            {
                var newFreelancer = new AppUser()
                {
                    UserName = "Lynyrd Skynyrd",
                    Email = freelancerEmail,
                    Contact = new ContactInfo()
                    {
                        Email= freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/lynyrd-skynyrd/"
                    }
                };
                await userManager.CreateAsync(newFreelancer, "3_kwietnia_1973");
                await userManager.AddToRoleAsync(newFreelancer, UserRoles.Freelancer);
            }
            #endregion

            #region companyOwner
            var companyOwnerEmail = "richard.gates@freelancing.com";
            var companyOwner = await userManager.FindByEmailAsync(companyOwnerEmail);
            if (companyOwner == null)
            {
                var newCompanyOwner = new AppUser()
                {
                    UserName = "Richard Gates",
                    Email = companyOwnerEmail,
                    Contact = new ContactInfo()
                    {
                        Email = freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/richard-gates/"
                    }
                };
                await userManager.CreateAsync(newCompanyOwner, "win_7_forever");
                await userManager.AddToRoleAsync(newCompanyOwner, UserRoles.CompanyWorker);
            }
            #endregion

            #region companyWorker
            var companyWorkerEmail = "john.doe@freelancing.com";
            var companyWorker = await userManager.FindByEmailAsync(companyWorkerEmail);
            if (companyWorker == null)
            {
                var newCompanyWorker = new AppUser()
                {
                    UserName = "John Doe",
                    Email = companyWorkerEmail,
                    Contact = new ContactInfo()
                    {
                        Email = freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/john-doe/"
                    }
                };
                await userManager.CreateAsync(newCompanyWorker, "password");
                await userManager.AddToRoleAsync(newCompanyWorker, UserRoles.CompanyWorker);
            }
            #endregion

            #region secondFreelancer
            var secondFreelancerEmail = "matthew.perry@freelancing.com";
            var secondFreelancer = await userManager.FindByEmailAsync(secondFreelancerEmail);
            if (secondFreelancer == null)
            {
                var newSecondFreelancer = new AppUser()
                {
                    UserName = "Matthew Perry",
                    Email = secondFreelancerEmail,
                    Contact = new ContactInfo()
                    {
                        Email = freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/matthew-perry/"
                    }
                };
                await userManager.CreateAsync(newSecondFreelancer, "password");
                await userManager.AddToRoleAsync(newSecondFreelancer, UserRoles.Freelancer);
            }
            #endregion

            #region freshUser
            var freshUserEmail = "john.smith@freelancing.com";
            var freshUser = await userManager.FindByEmailAsync(freshUserEmail);
            if (freshUser == null)
            {
                var newFreshUser = new AppUser()
                {
                    UserName = "John Smith",
                    Email = freshUserEmail,
                    Contact = new ContactInfo()
                    {
                        Email = freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/john-smith/"
                    }
                };
                await userManager.CreateAsync(newFreshUser, "p@$$w0rD");
                await userManager.AddToRoleAsync(newFreshUser, UserRoles.User);
            }
            #endregion
        }
        public static async Task SeedExpieriences(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>() ?? throw new ArgumentNullException();

            if(!await context.Experiences.AnyAsync())
            {
                if(!await context.Skills.AnyAsync())
                    await SeedSkills(builder);

                var experiences = new List<Experience>()
                {
                    new Experience()
                    {
                        Skill = context.Skills.FirstOrDefault(x => x.Name == "C#")!,
                        Years = 1,
                        Description = "Trainee",
                        Level = 1
                    },
                    new Experience()
                    {
                        Skill = context.Skills.FirstOrDefault(x => x.Name == "C#")!,
                        Years = 3,
                        Description = "Mid",
                        Level = 3
                    },
                    new Experience()
                    {
                        Skill = context.Skills.FirstOrDefault(x => x.Name == "C#")!,
                        Years = 10,
                        Description = "Senior",
                        Level = 6
                    },
                    new Experience()
                    {
                        Skill = context.Skills.FirstOrDefault(x => x.Name == "Java")!,
                        Years = 10,
                        Description = "Upper Mid",
                        Level = 4
                    }
                };
                await context.Experiences.AddRangeAsync(experiences);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedFreelancers(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>() ?? throw new ArgumentNullException();
            if (!await context.Freelancers.AnyAsync())
            {
                if (!await context.Experiences.AnyAsync())
                    await SeedExpieriences(builder);
                var appUser = await context.Users.FirstOrDefaultAsync(x => x.UserName == "Lynyrd Skynyrd");
                var appUser2 = await context.Users.FirstOrDefaultAsync(x => x.UserName == "Matthew Perry");
                var experiences = await context.Experiences.ToListAsync();

                var freelancer = new Freelancer()
                {
                    AppUser = appUser!,
                    Description = "I'm as free as a bird now, And this bird you can not change.",
                    Experience = new List<Experience>()
                    {
                        experiences.FirstOrDefault(x => x.Skill.Name == "C#" && x.Level == 1)!,
                        experiences.FirstOrDefault(x => x.Skill.Name == "Java" && x.Level == 4)!
                    }
                };

                var freelancer2 = new Freelancer()
                {
                    AppUser = appUser2!,
                    Description = "I'm a senior C# developer",
                    Experience = new List<Experience>()
                    {
                        experiences.FirstOrDefault(x => x.Skill.Name == "C#" && x.Level == 6)!
                    }
                };

                await context.Freelancers.AddRangeAsync(new Freelancer[] {freelancer, freelancer2});
                appUser.FreelancerProfile = freelancer;
                appUser2.FreelancerProfile = freelancer2;
                await context.SaveChangesAsync();
            }
        }
    }
}
