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
using UnityEngine;
using WebSocket4Net;

namespace BlackFire.Unity.Business
{
    public class PlayerPrefsOrmProvider : IOrmProvider
    {
        
        
        public PlayerPrefsOrmProvider()
        {
            Init();
        }

        private void Init()
        {
           
        }


        private SceneList SeriSceneList()
        {
            SceneList sceneList = null;
            if (PlayerPrefs.HasKey(PlayerPrefsKey.SceneList))
            {
                sceneList = Utility.Json.FromJson<SceneList>(PlayerPrefs.GetString(PlayerPrefsKey.SceneList));
            }
            else
            {
                sceneList = new SceneList();
            }
            return sceneList;
        }

        private List<Scene> m_SceneList = new List<Scene>();

        public void AcquireScenes(Action<IEnumerable<Scene>> completeCallback)
        {
            var sceneList = SeriSceneList();
            foreach (var scene in sceneList.Scenes)
            {
                m_SceneList.Add(new Scene()
                {
                    Id = scene
                });
            }

            if (null!=completeCallback)
            {
                completeCallback.Invoke(m_SceneList);
            }
        }

        private SceneObjectList m_SOList = new SceneObjectList();
        public void AcquireSceneObjects(Scene scene, Action<IEnumerable<SceneObject>> completeCallback)
        {
            if (PlayerPrefs.HasKey(scene.Id))
            {
                var sceneJson = PlayerPrefs.GetString(scene.Id);
                m_SOList = Utility.Json.FromJson<SceneObjectList>(sceneJson);
            }

            var soList = new List<SceneObject>();
            foreach (var so in m_SOList.SceneObjects)
            {
                soList.Add(new SceneObject()
                {
                    Id = so,
                    SId = scene.Id
                });
            }
            
            if (null!=completeCallback)
            {
                completeCallback.Invoke(soList);
            }
        }

        public void AcquireCommands(SceneObject sceneObject, Action<IEnumerable<Command>> completeCallback)
        {
            var key = string.Format("{0}_{1}", sceneObject.SId, sceneObject.Id);
            var cmdList = new CommandList();
            if (PlayerPrefs.HasKey(key))
            {
                var sceneObjectJson = PlayerPrefs.GetString(key);
                cmdList = Utility.Json.FromJson<CommandList>(sceneObjectJson);
            }

            var cmds = new List<Command>();
            foreach (var cmd in cmdList.Commands)
            {
                var json = PlayerPrefs.GetString(string.Format("{0}_{1}_{2}", sceneObject.SId, sceneObject.Id,cmd));
                var t = Utility.Json.FromJson<Command>(json);
                if (null!=t)
                {
                    cmds.Add(t);
                }
            }
            
            if (null!=completeCallback)
            {
                completeCallback.Invoke(cmds);
            }
        }
        
    }
    
    
    
    
    
    
}