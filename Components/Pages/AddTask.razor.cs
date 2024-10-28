using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Pages;

public partial class AddTask
{
    private TaskModel newTask = new TaskModel
    {
        Status = TaskModel.TaskStatus.NotStarted,
        DueDate = DateTime.Today
    };

    private List<string> errorMessages = new();

    private List<dynamic> newTaskStatusList = new()
    {
        new { Text = "未着手", Value = TaskModel.TaskStatus.NotStarted },
        new { Text = "仕掛中", Value = TaskModel.TaskStatus.InProgress },
        new { Text = "完了", Value = TaskModel.TaskStatus.Completed },
        new { Text = "無視", Value = TaskModel.TaskStatus.Ignored }
    };

    private async Task SaveNewTaskAsync()
    {
        errorMessages.Clear();
        
        if (string.IsNullOrWhiteSpace(newTask.Title))
        {
            errorMessages.Add("題名を入力してください。");
        }

        if (errorMessages.Count == 0)
        {
            TaskState.State!.Add(newTask);
            NavigationManager.NavigateTo("/");
        }
    }

    private void Cancel()
    {
        NavigationManager.NavigateTo("/");
    }
}
