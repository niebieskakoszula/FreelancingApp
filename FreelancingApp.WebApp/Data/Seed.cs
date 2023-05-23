using FreelancingApp.WebApp.Helpers;
using FreelancingApp.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FreelancingApp.WebApp.Data
{
    public class Seed
    {
        //private static readonly ILogger<Seed> _logger = LoggerFactory.Create();

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

            var con = context.Experiences.Include(x => x.Skill);
            var res = await con.FirstOrDefaultAsync(x => x.Skill.Name == "C#" && x.Level >= 5);

            if (!await context.Jobs.AnyAsync())
            {
                var jobs = new List<Job>()
                {
                    new Job()
                    {
                        Title = "Senior .NET Developer",
                        Description = "We are looking for a .NET developer to join our team",
                        Company = await context.Companies.FirstOrDefaultAsync(x => x.CompanyName == "Boogle") ?? throw new ArgumentNullException("Company"),
                        Currency = await context.Currencies.FirstOrDefaultAsync(x => x.Name == "USD") ?? throw new ArgumentNullException("Currency"),
                        PaymentAmount = 100,
                        IsHourly = true,
                        CreatedAt = DateTime.Now,
                        Deadline = DateTime.Now.AddDays(30),
                        RequiredExperience = new List<Experience>()
                        {
                            res ?? throw new ArgumentNullException("Experiences")
                        }
                    }
                };
                context.Jobs.AddRange(jobs);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedCompanies(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var factory = serviceScope.ServiceProvider.GetService<ILoggerFactory>();
            var _logger = new Logger<Seed>(factory);
            _logger.LogCritical("==================================Seeding companies...==================================");

            var context = serviceScope.ServiceProvider.GetService<AppDbContext>() ?? throw new ArgumentNullException();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>() ?? throw new ArgumentNullException();

            _logger.LogInformation("==================================Initialization complete...==================================");
            if (!await context.Companies.AnyAsync())
            {
                _logger.LogInformation("==================================No Companies found==================================");
                var owner = await userManager!.FindByEmailAsync("richard.gates@freelancing.com") ?? throw new ArgumentNullException("Owner");
                var moder = await userManager!.FindByEmailAsync("john.doe@freelancing.com") ?? throw new ArgumentNullException("Moder");
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
                        Owner = owner,
                        Moderators = new List<AppUser>()
                        {
                            moder
                        }
                    }
                };
                context.Companies.AddRange(companies);
                await context.SaveChangesAsync();
            }
            else 
                _logger.LogInformation("==================================Companies found==================================");
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
        public static async Task SeedUsersAsync(IApplicationBuilder builder)//, Action<ILoggingBuilder> log
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>() ?? throw new ArgumentNullException();
            var factory = serviceScope.ServiceProvider.GetService<ILoggerFactory>();
            var _logger = new Logger<Seed>(factory);

            _logger.LogInformation("==================================Seeding users...==================================");
            #region admin
            var adminEmail = "admin1234@freelancing.com";
            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                _logger.LogInformation("==================================admin is null==================================");
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
                _logger.LogInformation("==================================Creating admin==================================");
                var userResult = await userManager.CreateAsync(newAdmin, "N9a3^2438Uhw0z");
                _logger.LogInformation($"==================================result: {userResult}==================================");
                _logger.LogInformation("==================================Adding admin to role==================================");
                var roleResult = await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
                _logger.LogInformation($"==================================result: {roleResult}==================================");
            }
            else
            {
                _logger.LogInformation("==================================admin is not null==================================");
            }
            #endregion

            _logger.LogInformation("==================================Seeding first freelancer==================================");
            #region freelancer
            var freelancerEmail = "freebird@freelancing.com";
            var freelancer = await userManager.FindByEmailAsync(freelancerEmail);
            if (freelancer == null)
            {
                _logger.LogInformation("==================================freelancer is null==================================");
                var newFreelancer = new AppUser()
                {
                    UserName = "LynyrdSkynyrd",
                    Email = freelancerEmail,
                    Contact = new ContactInfo()
                    {
                        Email= freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/lynyrd-skynyrd/"
                    }
                };
                _logger.LogInformation("==================================Creating freelancer==================================");
                var userResult = await userManager.CreateAsync(newFreelancer, "Ct606&oZM*x^fN");
                _logger.LogInformation($"==================================result: {userResult}==================================");
                _logger.LogInformation("==================================Adding freelancer to role==================================");
                var roleResult = await userManager.AddToRoleAsync(newFreelancer, UserRoles.Freelancer);
                _logger.LogInformation($"==================================result: {roleResult}==================================");
            }
            else
            {
                _logger.LogInformation("==================================freelancer is not null==================================");
            }
            #endregion

            _logger.LogInformation("Seeding company Owner");
            #region companyOwner
            var companyOwnerEmail = "richard.gates@freelancing.com";
            var companyOwner = await userManager.FindByEmailAsync(companyOwnerEmail);
            if (companyOwner == null)
            {
                _logger.LogInformation("==================================companyOwner is null==================================");
                var newCompanyOwner = new AppUser()
                {
                    UserName = "RichardGates",
                    Email = companyOwnerEmail,
                    Contact = new ContactInfo()
                    {
                        Email = freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/richard-gates/"
                    }
                };
                _logger.LogInformation("==================================Creating companyOwner==================================");
                var userResult = await userManager.CreateAsync(newCompanyOwner, "y5A64#*6NSgF9d");
                _logger.LogInformation($"==================================result: {userResult}==================================");
                _logger.LogInformation("==================================Adding companyOwner to role==================================");
                var roleResult = await userManager.AddToRoleAsync(newCompanyOwner, UserRoles.CompanyWorker);
                _logger.LogInformation($"==================================result: {roleResult}==================================");
            }
            else
            {
                _logger.LogInformation("==================================companyOwner is not null==================================");
            }
            #endregion

            _logger.LogInformation("Seeding company Worker");
            #region companyWorker
            var companyWorkerEmail = "john.doe@freelancing.com";
            var companyWorker = await userManager.FindByEmailAsync(companyWorkerEmail);
            if (companyWorker == null)
            {
                _logger.LogInformation("==================================companyWorker is null==================================");
                var newCompanyWorker = new AppUser()
                {
                    UserName = "JohnDoe",
                    Email = companyWorkerEmail,
                    Contact = new ContactInfo()
                    {
                        Email = freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/john-doe/"
                    }
                };
                _logger.LogInformation("==================================Creating companyWorker==================================");
                var userResult = await userManager.CreateAsync(newCompanyWorker, "55wK5R%P87Rv");
                _logger.LogInformation($"==================================result: {userResult}==================================");
                _logger.LogInformation("==================================Adding companyWorker to role==================================");
                var roleResult = await userManager.AddToRoleAsync(newCompanyWorker, UserRoles.CompanyWorker);
                _logger.LogInformation($"==================================result: {roleResult}==================================");
            }
            else
            {
                _logger.LogInformation("==================================companyWorker is null==================================");
            }
            #endregion

            _logger.LogInformation("Seeding second freelancer");
            #region secondFreelancer
            var secondFreelancerEmail = "matthew.perry@freelancing.com";
            var secondFreelancer = await userManager.FindByEmailAsync(secondFreelancerEmail);
            if (secondFreelancer == null)
            {
                _logger.LogInformation("==================================second freelancer is null==================================");
                var newSecondFreelancer = new AppUser()
                {
                    UserName = "MatthewPerry",
                    Email = secondFreelancerEmail,
                    Contact = new ContactInfo()
                    {
                        Email = freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/matthew-perry/"
                    }
                };
                _logger.LogInformation("==================================Creating second freelancer==================================");
                var userResult = await userManager.CreateAsync(newSecondFreelancer, "I52i%0^mwp6ztX");
                _logger.LogInformation($"==================================result: {userResult}==================================");
                _logger.LogInformation("==================================Adding second freelancer to role==================================");
                var roleResult = await userManager.AddToRoleAsync(newSecondFreelancer, UserRoles.Freelancer);
                _logger.LogInformation($"==================================result: {roleResult}==================================");
            }
            else
            {
                _logger.LogInformation("==================================second freelancer is not null==================================");
            }
            #endregion

            _logger.LogInformation("Seeding fresh user");
            #region freshUser
            var freshUserEmail = "john.smith@freelancing.com";
            var freshUser = await userManager.FindByEmailAsync(freshUserEmail);
            if (freshUser == null)
            {
                _logger.LogInformation("==================================fresh user is null==================================");
                var newFreshUser = new AppUser()
                {
                    UserName = "JohnSmith",
                    Email = freshUserEmail,
                    Contact = new ContactInfo()
                    {
                        Email = freelancerEmail,
                        PhoneNumber = "123456789",
                        LinkedIn = "https://www.linkedout.com/in/john-smith/"
                    }
                };
                _logger.LogInformation("==================================Creating fresh user==================================");
                var userResult = await userManager.CreateAsync(newFreshUser, "Ih837dhcT^r3SK");
                _logger.LogInformation($"==================================result: {userResult}==================================");
                _logger.LogInformation("==================================Adding fresh user to role==================================");
                var roleResult = await userManager.AddToRoleAsync(newFreshUser, UserRoles.User);
                _logger.LogInformation($"==================================result: {roleResult}==================================");
            }
            else
            {
                _logger.LogInformation("==================================fresh user is null==================================");
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
            var t = serviceScope.ServiceProvider.GetService<ILoggerFactory>();
            var _logger = new Logger<Seed>(t);

            if (!await context.Freelancers.AnyAsync())
            {
                if (!await context.Experiences.AnyAsync())
                    await SeedExpieriences(builder);
                var appUser = await context.Users.FirstOrDefaultAsync(x => x.UserName == "LynyrdSkynyrd");
                var appUser2 = await context.Users.FirstOrDefaultAsync(x => x.UserName == "MatthewPerry");

                if(appUser == null || appUser2 == null)
                {
                    throw new Exception("AppUser is null");
                }
                var experiences = await context.Experiences.Include(x => x.Skill).ToListAsync();
                //_logger.LogCritical($"==================================experiences count: {experiences.Count}==================================");
                //experiences.ForEach(x => _logger.LogInformation(x.Skill.Name +  " " + x.Level.ToString()));

                var freelancer = new Freelancer()
                {
                    AppUserId = appUser.Id,
                    AppUser = appUser!,
                    Description = "I'm as free as a bird now, And this bird you can not change.",
                    Experience = new List<Experience>()
                    {
                        experiences.FirstOrDefault(x => x.Skill.Name == "C#" && x.Level == 1) ?? throw new ArgumentNullException("Experience not found"),
                        experiences.FirstOrDefault(x => x.Skill.Name == "Java" && x.Level == 4) ?? throw new ArgumentNullException("Experience not found")
                    }
                };

                var freelancer2 = new Freelancer()
                {
                    AppUserId = appUser2.Id,
                    AppUser = appUser2!,
                    Description = "I'm a senior C# developer",
                    Experience = new List<Experience>()
                    {
                        experiences.FirstOrDefault(x => x.Skill.Name == "C#" && x.Level == 6) ?? throw new ArgumentNullException("Experience not found")
                    }
                };

                //await context.Freelancers.AddRangeAsync(new Freelancer[] {freelancer, freelancer2});
                _logger.LogInformation("==================================Trying to add freelancers==================================");
                await context.Freelancers.AddAsync(freelancer);
                await context.Freelancers.AddAsync(freelancer2);
                await context.SaveChangesAsync();
                _logger.LogInformation("==================================Freelancers added==================================");
                _logger.LogCritical($"==================================Freelancers count: {await context.Freelancers.CountAsync()}==================================");
                var res1 = await context.Freelancers.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id);
                _logger.LogCritical($"==================================Freelancer exist: {res1 != null}==================================");
                var res2 = await context.Freelancers.FirstOrDefaultAsync(x => x.AppUserId == appUser2.Id);
                _logger.LogCritical($"==================================Freelancer exist: {res2 != null}==================================");
                appUser.FreelancerProfile = freelancer;
                appUser2.FreelancerProfile = freelancer2;
                await context.SaveChangesAsync();
            }
        }
    }
}
