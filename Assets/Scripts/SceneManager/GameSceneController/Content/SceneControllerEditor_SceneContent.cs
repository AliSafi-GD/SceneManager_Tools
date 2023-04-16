using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


    [CreateAssetMenu(fileName = "Scene Controller", menuName = "scenes contents", order = 0)]
    public class SceneControllerEditor_SceneContent : ScriptableObject
    {
        #if UNITY_EDITOR
        public List<SceneItem> sceneItems;
        #endif
    }
#if UNITY_EDITOR

    [System.Serializable]
    public class SceneItem
    {
        public string sceneName;
        public string scenepath;
        public SceneAsset obj;
    }
#endif
