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

namespace BlackFire.Unity.Business
{
    /// <summary>
    /// 数据存储器接口。
    /// </summary>
    public interface IDataStorager
    {

        /// <summary>
        /// 保存场景。
        /// </summary>
        /// <param name="scene">场景。</param>
        /// <param name="completeCallback">保存成功回调。</param>
        void SaveScene(Scene scene,Action completeCallback);

        void SaveSceneObject(SceneObject sceneObject,Action completeCallback);

        void SaveCommand(SceneObject sceneObject,Command command,Action completeCallback);

    }
}