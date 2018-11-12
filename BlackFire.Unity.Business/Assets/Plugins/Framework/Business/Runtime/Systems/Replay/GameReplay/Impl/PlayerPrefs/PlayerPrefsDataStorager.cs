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

namespace BlackFire.Unity.Business
{
    public class PlayerPrefsDataStorager:IDataStorager
    {

        public PlayerPrefsDataStorager()
        {
            Init();
        }

        private SceneList m_SceneList = null;
        
        private void Init()
        {
            if ( PlayerPrefs.HasKey(PlayerPrefsKey.SceneList))
            {
                var json = PlayerPrefs.GetString(PlayerPrefsKey.SceneList);
                if (!string.IsNullOrEmpty(json))
                {
                    m_SceneList = Utility.Json.FromJson<SceneList>(json);
                }
            }
            else
            {
                m_SceneList = new SceneList();
            }
        }
       
        
        public void SaveScene(Scene scene, Action completeCallback)
        {
            m_SceneList.Scenes.SafeAdd(scene.Id);
            PlayerPrefs.SetString(PlayerPrefsKey.SceneList,Utility.Json.ToJson(m_SceneList));
            var soList = new SceneObjectList();
            foreach (var so in scene.SceneObjects)
            {
                soList.SceneObjects.Add(so.Id);
            }
            PlayerPrefs.SetString(scene.Id,Utility.Json.ToJson(soList));
            if (null!=completeCallback)
            {
                completeCallback.Invoke();
            }
        }
        
        public void SaveSceneObject(SceneObject sceneObject, Action completeCallback)
        {
            var cmdList = new CommandList();
            foreach (var cmd in sceneObject.Commands)
            {
                cmdList.Commands.Add(cmd.Id);                
            }
            //Scene1_SceneObject1
            PlayerPrefs.SetString(string.Format("{0}_{1}",sceneObject.SId,sceneObject.Id),Utility.Json.ToJson(cmdList));
           
            if (null!=completeCallback)
            {
                completeCallback.Invoke();
            }
        }

        public void SaveCommand(SceneObject sceneObject, Command command, Action completeCallback)
        {
            var key = string.Format("{0}_{1}_{2}", sceneObject.SId, command.SOId,command.Id);
            PlayerPrefs.SetString(key,Utility.Json.ToJson(command));
        }
        
    }
    
    
    
    
    
    
}