using System;
using System.Collections.Generic;
using TechJobs.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TechJobs.ViewModels
{
    public class BaseViewModel
    {
        // View title
        public string Title { get; set; } = "";

        // All columns, for display
        public List<JobFieldType> Columns { get; set; }

        public BaseViewModel()
        {
            // Populate the list of all columns

            Columns = new List<JobFieldType>();

            foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType)))
            {
                Columns.Add(enumVal);
            }

        }
    }
}
