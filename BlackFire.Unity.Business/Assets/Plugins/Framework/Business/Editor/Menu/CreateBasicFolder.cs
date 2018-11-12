/*********************************************************
*
*		Title: "FireOnline"	Unity文件创建
*				主题：	脚本创建文件夹
*		Description：						
*			   功能：	脚本创建文件夹
*
*		Date：	2018年10月15日 17:17:22
*		Version：	1.1版本
*		Modify Recoder：
*       Name:ZPF
*
**********************************************************/

using System.IO;
using UnityEditor;
using UnityEngine;

namespace BlackFire.Unity.Business.Editor
{
    public static class CreateBasicFolder
    {
        [MenuItem("BlackFire/Business/CreateBasicFolder")]
        private static void OnCreateBasicFolder()
        {
            CreateDefaultFolder();
        }
        
        /*
        private static void GenerateFolder()
        {
            // 文件路径
            string prjPath = Application.dataPath;
            string mainPath = prjPath + "/__Main__";
            
            Directory.CreateDirectory(mainPath);
            Directory.CreateDirectory(mainPath + "/Logic");
            Directory.CreateDirectory(mainPath + "/Logic/Common");
            Directory.CreateDirectory(mainPath + "/Logic/Develop");
            Directory.CreateDirectory(mainPath + "Logic/Develop/_Main_");
            Directory.CreateDirectory(mainPath + "/Logic/Develop/ReplaceYourName/Script/CS");
            Directory.CreateDirectory(mainPath + "/Logic/Develop/ReplaceYourName/Scene");
            Directory.CreateDirectory(mainPath + "/Logic/Develop/ReplaceYourName/Prefab");
            Directory.CreateDirectory(mainPath + "/Resource");
            Directory.CreateDirectory(mainPath + "/Resource/Art");
            Directory.CreateDirectory(mainPath + "/Resource/Resources");
            Directory.CreateDirectory(mainPath + "/Resource/Scene");
            Directory.CreateDirectory(mainPath + "/Resource/" + "Scene" + "/" + "Build");
            Directory.CreateDirectory(mainPath + "/Resource" + "/" + "Scene" + "/" + "Test");
            Directory.CreateDirectory(prjPath + "Gizmos");
            Directory.CreateDirectory(prjPath + "Plugins");
            Directory.CreateDirectory(prjPath + "/Plugins/Framework");
            Directory.CreateDirectory(prjPath + "/Plugins/" + "Framework"+"/"+"BasicFramework");
            Directory.CreateDirectory(prjPath + "/Plugins/" + "Framework" + "/" + "BusinessFramework");
            Directory.CreateDirectory(prjPath + "/Plugins/Framework" + "/" + "ProjectFramework");
            
            Directory.CreateDirectory(prjPath + "Ignore");
            Directory.CreateDirectory(prjPath + "StreamingAssets");
            
            AssetDatabase.Refresh();
#if DEVELOP_KING_LOG
            Debug.Log("创建完成");
#endif

        }
*/

        private static void CreateDefaultFolder()
        {
            var guids = AssetDatabase.FindAssets("BasicFolder");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                if (path.Contains("BasicFolder.txt"))
                {
                    var fullPath = GetAssetsFolder() + path;
                    var text = File.ReadAllText(fullPath);
                    var ps = text.Split('\n');
                    if (null!=ps)
                    {
                        for (int i = 0; i < ps.Length; i++)
                        {
                            if (string.IsNullOrEmpty(ps[i]))
                            {
                                continue;
                            }
                            BlackFire.Utility.IO.ExistsOrCreateFolder(Path.Combine(Application.dataPath,ps[i].Trim()));
                        }
                        AssetDatabase.Refresh();
                    }
                }
            }
        }

        private static string GetAssetsFolder()
        {
            var dataPath = Application.dataPath;
            var s = new char[dataPath.Length-6];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = dataPath[i];
            }
            return new string(s);
        }

    }
}
