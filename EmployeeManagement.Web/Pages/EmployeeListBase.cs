using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase :ComponentBase
    {


        
        public bool ShowFooter { get; set; } = true;



        public IEnumerable<Employee> Employees { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

       

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
            base.OnInitializedAsync();
        }


        protected int SelectedEmployeesCount { get; set; } = 0;

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }

        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }

        /*  private void LoadEmployees()
          {
              Employee e1= new Employee();
              e1.FirstName = "e1.Firstname";
              e1.LastName = "e1.LastName";
              e1.DepartmentId = 1 ;
              e1.Email = "e1.Email";
              e1.EmployeeId = 1;
              e1.PhotoPath = "Images/images.jfif";

              Employee e2 = new Employee
              {
                  FirstName = "e2.Firstname",
                  LastName = "e2.LastName",
                  DepartmentId = 2,
                  Email = "e2.Email",
                  EmployeeId = 1,
                  PhotoPath = "Images/images.png"
              };

              Employees = new List<Employee> { e1, e2 };
          }
        */
    }
}
