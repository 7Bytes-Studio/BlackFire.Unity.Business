/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace BlackFire.Unity.Business
{
    /// <summary>
    /// 场景。
    /// </summary>
    [Serializable]
    public class Command
    {

        /// <summary>
        /// 命令的Id。
        /// </summary>
        public string Id;

        /// <summary>
        /// 场景对象的Id。
        /// </summary>
        public string SOId; 
        
        /// <summary>
        /// 时间戳。
        /// </summary>
        public float CreateTime;

        /// <summary>
        /// 命令索引。
        /// </summary>
        public string Key;

        /// <summary>
        /// 命令内容。
        /// </summary>
        public string Body;
        
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Scene Object ID : {0}",this.SOId));
            sb.AppendLine(string.Format("Command ID : {0}",this.Id));
            sb.AppendLine(string.Format("Create Time : {0}",this.CreateTime));
            sb.AppendLine(string.Format("Key : {0}",this.Key));
            sb.AppendLine(string.Format("Body : {0}",this.Body));
            return sb.ToString();
        }
        
        
    }
}