using UnityEditor;
using UnityEngine;


public class SceneControllerEditor_EditContent : EditorWindow
{
    private static SceneControllerEditor_SceneContent content;
    private static Editor scriptableEditor;
    public static void ShowWindow()
    {
        content = AssetDatabase.LoadAssetAtPath<SceneControllerEditor_SceneContent>(
            "Assets/Scripts/UnityEditor/GameSceneController/Content/Scene Controller.asset");
        
        scriptableEditor = Editor.CreateEditor(content);
        var window = GetWindow<SceneControllerEditor_EditContent>();
        window.titleContent = new GUIContent("Edit Content");
        window.Show();
    }

    private void OnGUI()
    {
        ///scriptableEditor.OnInspectorGUI();

        foreach (var item in content.sceneItems)
        {
            item.scenepath = AssetDatabase.GetAssetPath(item.obj);
           
            GUILayout.BeginHorizontal();
            item.obj =(SceneAsset) EditorGUILayout.ObjectField(item.sceneName, item.obj,typeof(SceneAsset));
            item.sceneName =item.obj == null?"-": item.obj.name;
            if (GUILayout.Button("-",GUILayout.Width(20)))
            {
                content.sceneItems.Remove(item);
            }
            if (GUILayout.Button("↓",GUILayout.Width(20)))
            {
                
            }
            if (GUILayout.Button("↑",GUILayout.Width(20)))
            {
                
            }
            
            GUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Add"))
        {
            // var file = EditorUtility.OpenFilePanel("Select Scene", Application.dataPath, "unity");
            // if (file.Length != 0)
            // {
            //     Debug.Log(file);
            // }
            
            content.sceneItems.Add(new SceneItem());
        }
        
        
    }
}
