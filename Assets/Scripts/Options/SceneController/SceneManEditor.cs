#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
public partial class SceneMan : ScriptableObject, ISerializationCallbackReceiver
{
    public SceneAsset sceneAsset;

    public void OnAfterDeserialize()
    {
       
    }

    public void OnBeforeSerialize()

    {

        if (sceneAsset != null)
        {
            if (SceneName.Equals(sceneAsset.name) == false)
            {
                SceneName = sceneAsset.name;
            }
        }
        else SceneName = string.Empty;
    }
}
#endif