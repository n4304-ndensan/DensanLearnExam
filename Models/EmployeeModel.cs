using System;

namespace BlazorApp.Models
{
    public class EmployeeModel : IComparable<EmployeeModel>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime JoiningDate { get; set; }
        public EmploymentType Type { get; set; }
        public string Remarks { get; set; } = string.Empty;

        // 状態を文字列で取得する
        public string GetTypeText()
        {
            return this.Type switch
            {
                EmploymentType.FullTime => "正社員",
                EmploymentType.Contract => "嘱託",
                EmploymentType.Partner => "協力会社",
                _ => "不明"
            };
        }

        public int CompareTo(EmployeeModel other)
        {
            int stateComparison = this.Type.CompareTo(other.Type);
            if (stateComparison != 0)
            {
                return stateComparison;
            }

            return this.JoiningDate.CompareTo(other.JoiningDate);
        }

        // タスクの状態を表す列挙型
        public enum EmploymentType
        {
            FullTime = 0,   // 正社員
            Contract = 1,   // 嘱託
            Partner = 3      // 協力会社
        }
    }
}
