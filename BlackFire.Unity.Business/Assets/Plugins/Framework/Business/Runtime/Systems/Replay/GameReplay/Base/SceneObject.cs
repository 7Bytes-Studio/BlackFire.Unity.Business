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
    /// 场景对象。
    /// </summary>
   [Serializable]
    public class SceneObject
    {
        
        /// <summary>
        /// 场景对象的Id。
        /// </summary>
        public string Id;

        /// <summary>
        /// 场景的Id。
        /// </summary>
        public string SId;

        /// <summary>
        /// 命令集合。
        /// </summary>
        public IEnumerable<Command> Commands = null;
        
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Scene Object ID : {0}",this.Id));
            if (null!=Commands)
            {
                foreach (var item in Commands)
                {
                    sb.AppendLine(string.Format("Command Object : {0}",item.Id));
                }
            }
            return sb.ToString();
        }
        
    }
}