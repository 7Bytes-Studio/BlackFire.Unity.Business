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
    public class Scene
    {

        /// <summary>
        /// 场景的Id。
        /// </summary>
        public string Id;
        
        /// <summary>
        /// 场景对象集合。
        /// </summary>
        public IEnumerable<SceneObject> SceneObjects = null;


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Scene ID : {0}",this.Id));
            if (null!=SceneObjects)
            {
                foreach (var item in SceneObjects)
                {
                    sb.AppendLine(string.Format("Scene Object : {0}",item.Id));
                }
            }
            return sb.ToString();
        }
    }
}