using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Pages;

public partial class AddEmployee
{
    private EmployeeModel newEmployee = new EmployeeModel
    {
        Type = EmployeeModel.EmploymentType.FullTime,
        JoiningDate = DateTime.Today
    };

    private List<string> errorMessages = new();

    private List<dynamic> newEmployeeTypeList = new()
    {
        new { Text = "正社員", Value = EmployeeModel.EmploymentType.FullTime },
        new { Text = "嘱託", Value = EmployeeModel.EmploymentType.Contract },
        new { Text = "協力会社", Value = EmployeeModel.EmploymentType.Partner },
    };

    private async Task SaveNewEmployeeAsync()
    {
        errorMessages.Clear();
        
        if (string.IsNullOrWhiteSpace(newEmployee.Name))
        {
            errorMessages.Add("氏名を入力してください。");
        }

        if (errorMessages.Count == 0)
        {
            EmployeeState.State!.Add(newEmployee);
            NavigationManager.NavigateTo("/");
        }
    }

    private void Cancel()
    {
        NavigationManager.NavigateTo("/");
    }
}
