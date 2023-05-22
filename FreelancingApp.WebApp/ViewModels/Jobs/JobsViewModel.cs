using FreelancingApp.WebApp.Models;

namespace FreelancingApp.WebApp.ViewModels.Jobs
{
    public class JobsViewModel
    {
        public List<Job>? Jobs { get; set; }
        public string? SearchString { get; set; }
    }
}
