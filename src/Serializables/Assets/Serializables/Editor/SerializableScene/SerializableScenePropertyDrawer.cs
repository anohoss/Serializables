using UnityEditor;
using UnityEngine;

namespace Anoho.Serializables
{
    [CustomPropertyDrawer(typeof(SerializableScene))]
    public class SerializableScenePropertyDrawer : PropertyDrawer
    {
        private class Constraints
        {
            public readonly string AssetPathName;

            public readonly string SceneAssetName;

            public Constraints()
            {
                AssetPathName = "_assetPath";
                SceneAssetName = "_sceneAsset";
            }
        }



        private Constraints _constraints;



        private void Init()
        {
            _constraints ??= new Constraints();
        }



        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }



        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Init();

            var sceneAssetProperty = GetSceneAssetProperty(property);
            sceneAssetProperty.objectReferenceValue = EditorGUI.ObjectField(
                new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
                label,
                sceneAssetProperty.objectReferenceValue,
                typeof(SceneAsset),
                false);
            position.y += EditorGUIUtility.singleLineHeight;
        }



        public bool IsSceneAssetAttached(SerializedProperty property)
        {
            if (property is null)
            {
                return false;
            }

            var assetPath = property.FindPropertyRelative(_constraints.AssetPathName);
            if (assetPath is null || string.IsNullOrEmpty(assetPath.stringValue))
            {
                return false;
            }

            return true;
        }



        public SerializedProperty GetSceneAssetProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative(_constraints.SceneAssetName);
        }
    }
}
