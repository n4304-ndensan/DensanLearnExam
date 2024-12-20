using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Pages;
public partial class Home
{
    private List<EmployeeModel>? employeeList;

    protected override async Task OnInitializedAsync()
    {
        // デフォルトのタスクリストを初期化
        employeeList ??= new List<EmployeeModel>
        {
            new EmployeeModel { Name = "社員A", JoiningDate = new DateTime(2020, 1, 1), Type = EmployeeModel.EmploymentType.FullTime, Remarks = "備考A" },
            new EmployeeModel { Name = "社員B", JoiningDate = new DateTime(2021, 2, 1), Type = EmployeeModel.EmploymentType.Contract, Remarks = "備考B" },
            new EmployeeModel { Name = "社員C", JoiningDate = new DateTime(2022, 3, 1), Type = EmployeeModel.EmploymentType.Partner, Remarks = "備考C" },
            new EmployeeModel { Name = "社員D", JoiningDate = new DateTime(2023, 4, 1), Type = EmployeeModel.EmploymentType.FullTime, Remarks = "備考D" },
            new EmployeeModel { Name = "社員E", JoiningDate = new DateTime(2024, 5, 1), Type = EmployeeModel.EmploymentType.Contract, Remarks = "備考E" }
        };

        // EmployeeState の状態が存在するか確認し、なければ初期化
        if (EmployeeState.HasState)
        {
            employeeList = EmployeeState.State!;
        }
        else
        {
            EmployeeState.State = employeeList;
        }

        EmployeeState.State!.Sort();
        
        await Task.CompletedTask;
    }

    async Task LoadTask()
    {
        await Task.Yield();

        if (EmployeeState.HasState)
        {
            EmployeeState.State = employeeList;
            return;
        }
    }

    private void NavigateToAddEmployee()
    {
        NavigationManager.NavigateTo("/add-employee");
    }
    private string GetTypeColor(EmployeeModel.EmploymentType type)
    {
        return type switch
        {
            EmployeeModel.EmploymentType.FullTime => "#007bff", // Blue
            EmployeeModel.EmploymentType.Contract => "#28a745", // Green
            EmployeeModel.EmploymentType.Partner => "#ffc107", // Yellow
            _ => "#6c757d" // Gray
        };
    }
}
