using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityObject = UnityEngine.Object;

namespace Anoho.Serializables
{
    [Serializable]
    public class SerializableScene: ISerializationCallbackReceiver
    {
        [SerializeField, HideInInspector]
        private UnityObject _sceneAsset;

        [SerializeField, HideInInspector]
        private string _assetPath;

        [SerializeField, HideInInspector]
        private int _buildIndex;

        public string AssetPath
        {
            get
            {
#if UNITY_EDITOR
                return UnityEditor.AssetDatabase.GetAssetPath(_sceneAsset);
#else
                return _assetPath;
#endif
            }
        }



        public int BuildIndex
        {
            get
            {
#if UNITY_EDITOR
                return SceneUtility.GetBuildIndexByScenePath(AssetPath);
#else
                return _buildIndex;
#endif
            }
        }




        public static implicit operator string(SerializableScene scene)
        {
            return scene?.AssetPath;
        }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            _assetPath = UnityEditor.AssetDatabase.GetAssetPath(_sceneAsset);
            _buildIndex = SceneUtility.GetBuildIndexByScenePath(_assetPath);
#endif
        }

        public void OnAfterDeserialize() { }
    }
}
