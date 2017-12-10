using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;
        private Employer employer;
        private Location location;
        private CoreCompetency coreCompetency;
        private PositionType positionType;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            Job job = jobData.Find(id);
            return View(job);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (Employer field in jobData.Employers.ToList())
                {
                    if(field.ID == newJobViewModel.EmployerID)
                    {
                        employer = field;
                    }
                }

                foreach (Location field in jobData.Locations.ToList())
                {
                    if (field.ID == newJobViewModel.LocationID)
                    {
                        location = field;
                    }
                }

                foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
                {
                    if (field.ID == newJobViewModel.CoreCompetencyID)
                    {
                        coreCompetency = field;
                    }
                }

                foreach (PositionType field in jobData.PositionTypes.ToList())
                {
                    if (field.ID == newJobViewModel.PositionTypeID)
                    {
                        positionType = field;
                    }
                }

                Job newJob = new Job
                {
                    Name = newJobViewModel.Name,
                    Employer = employer,
                    Location = location,
                    CoreCompetency = coreCompetency,
                    PositionType = positionType
                };

                jobData.Jobs.Add(newJob);
                string newUrl = "/Job?id="+newJob.ID.ToString();

                return Redirect(newUrl);
            }
            return View(newJobViewModel);
        }
    }
}
