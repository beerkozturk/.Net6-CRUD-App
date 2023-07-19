using System;
using System.ComponentModel.DataAnnotations;
namespace CRUD_APP.ViewModel
{
	public class StatsViewModel
	{
        public float maxSalary { get; set; }
        public float minSalary { get; set; }
        public float maxWorker { get; set; }
        public float avgSalary  { get; set; }
    }
}

