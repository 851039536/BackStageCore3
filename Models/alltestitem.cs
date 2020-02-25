using System.ComponentModel.DataAnnotations;

namespace BackStageCore3.Models
{
    public class alltestitem
    {
        // <summary>
        /// 机型
        /// </summary>
        [Key]
        public string 机型 { get; set; }

        /// <summary>
        /// 测试项目
        /// </summary>
        public string 测试项目 { get; set; }
        /// <summary>
        /// 耳机指令
        /// </summary>
        public string 耳机指令 { get; set; }
        /// <summary>
        /// 数值上限
        /// </summary>
        public string 数值上限 { get; set; }
        /// <summary>
        /// 数值下限
        /// </summary>
        public string 数值下限 { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public int 编号 { get; set; }

    }
}
