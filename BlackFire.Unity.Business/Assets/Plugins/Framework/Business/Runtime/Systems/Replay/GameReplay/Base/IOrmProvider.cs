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
    /// 数据提供接口。
    /// </summary>
    public interface IOrmProvider
    {

        /// <summary>
        /// 获取所有的场景。（从数据层获取数据并转换成业务场景。）
        /// </summary>
        /// <param name="completeCallback">获取成功回调。</param>
        void AcquireScenes(Action<IEnumerable<Scene>> completeCallback);

        /// <summary>
        /// 获取目标场景下所有的场景对象。
        /// </summary>
        /// <param name="scene">目标场景。</param>
        /// <param name="completeCallback">获取成功回调。</param>
        void AcquireSceneObjects(Scene scene,Action<IEnumerable<SceneObject>> completeCallback);
        
        /// <summary>
        /// 获取目标场景对象的所有命令回调。
        /// </summary>
        /// <param name="sceneObject">场景对象。</param>
        /// <param name="completeCallback">获取成功回调。</param>
        void AcquireCommands(SceneObject sceneObject,Action<IEnumerable<Command>> completeCallback);

    }
}