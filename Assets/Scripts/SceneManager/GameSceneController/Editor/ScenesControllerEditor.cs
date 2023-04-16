using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UnityEditor.GameSceneController.Editor
{

    public class ScenesControllerEditor : EditorWindow
    {
        private SceneControllerEditor_SceneContent content;
        private readonly string parentDirect = "Assets/Scenes";
        private Vector2 scrollPos;

        [MenuItem("Window/Scenes #&_c")]
        private static void ShowWindow()
        {
            var window = GetWindow<ScenesControllerEditor>();
            window.titleContent = new GUIContent("Scenes");
            window.Show();
        }

        private void OnGUI()
        {

            content = AssetDatabase.LoadAssetAtPath<SceneControllerEditor_SceneContent>(
                "Assets/Scripts/UnityEditor/GameSceneController/Content/Scene Controller.asset");
            
            var skin = AssetDatabase.LoadAssetAtPath<GUISkin>(
                "Assets/Scripts/UnityEditor/GameSceneController/GUISkin.guiskin");

            GUILayout.Box("Assets/Scenes", skin.box);

            var filesName = Directory.GetFiles(parentDirect, "*.unity");

            if (content.sceneItems.Count == 0)
            {
                foreach (var fileName in filesName)
                {
                    var fileInfo = new FileInfo(fileName);
                    var sceneName = fileInfo.Name.Remove(fileInfo.Name.Length - 6, 6);
                    content.sceneItems.Add(new SceneItem{sceneName = sceneName,scenepath = fileName});
                }
            }
            scrollPos = GUILayout.BeginScrollView(scrollPos, skin.scrollView);
            for (int i = 0; i < content.sceneItems.Count; i++)
            {
                //var f = new FileInfo(filesName[i]);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button(content.sceneItems[i].sceneName, skin.button, GUILayout.MinWidth(50)))
                    LoadScene(content.sceneItems[i].scenepath);

                GUILayout.EndHorizontal();
            }

            GUILayout.EndScrollView();

            if (GUILayout.Button(AssetDatabase.LoadAssetAtPath<Texture>(
                    "Assets/Scripts/UnityEditor/GameSceneController/Textures/setting.png"), skin.customStyles[0]))
            {
                SceneControllerEditor_EditContent.ShowWindow();
            }

        }

        void LoadScene(string path)
        {
            var modified = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            if (modified)
                EditorSceneManager.OpenScene(path);

        }
    }
}