using System;

namespace BlazorApp.Models
{
    public class TaskModel : IComparable<TaskModel>
    {
        public string Title { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public string Content { get; set; } = string.Empty;

        // 状態を文字列で取得する
        public string GetStatusText()
        {
            return Status switch
            {
                TaskStatus.NotStarted => "未着手",
                TaskStatus.InProgress => "仕掛中",
                TaskStatus.Completed => "完了",
                TaskStatus.Ignored => "無視",
                _ => "不明"
            };
        }

        public int CompareTo(TaskModel other)
        {
            int stateComparison = this.Status.CompareTo(other.Status);
            if (stateComparison != 0)
            {
                return stateComparison;
            }

            return this.DueDate.CompareTo(other.DueDate);
        }

        // タスクの状態を表す列挙型
        public enum TaskStatus
        {
            NotStarted = 0,
            InProgress = 1,
            Completed = 2,
            Ignored = 9
        }
    }
}
