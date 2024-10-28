using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Pages;
public partial class Home
{
    private List<TaskModel>? taskList;

    protected override async Task OnInitializedAsync()
    {
        // デフォルトのタスクリストを初期化
        taskList ??= new List<TaskModel>
        {
            new TaskModel { Title = "タスク1", DueDate = DateTime.Today.AddDays(2), Status = TaskModel.TaskStatus.NotStarted, Content = "タスク1の内容" },
            new TaskModel { Title = "タスク2", DueDate = DateTime.Today.AddDays(1), Status = TaskModel.TaskStatus.InProgress, Content = "タスク2の内容" },
            new TaskModel { Title = "タスク3", DueDate = DateTime.Today.AddDays(3), Status = TaskModel.TaskStatus.Completed, Content = "タスク3の内容" }
        };

        // TaskState の状態が存在するか確認し、なければ初期化
        if (TaskState.HasState)
        {
            taskList = TaskState.State!;
        }
        else
        {
            TaskState.State = taskList;
        }

        TaskState.State!.Sort();
        
        await Task.CompletedTask;
    }

    async Task LoadTask()
    {
        await Task.Yield();

        if (TaskState.HasState)
        {
            TaskState.State = taskList;
            return;
        }
    }

    private void NavigateToAddTask()
    {
        NavigationManager.NavigateTo("/add-task");
    }
    private string GetStatusColor(TaskModel.TaskStatus status)
    {
        return status switch
        {
            TaskModel.TaskStatus.NotStarted => "#6c757d", // Gray
            TaskModel.TaskStatus.InProgress => "#ffc107", // Yellow
            TaskModel.TaskStatus.Completed => "#28a745", // Green
            TaskModel.TaskStatus.Ignored => "#dc3545", // Red
            _ => "#007bff" // Blue
        };
    }
}
