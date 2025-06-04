using Anoho.Serializables;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Button loadButton;

    [SerializeField]
    private SerializableScene scene;

    private void Start()
    {
        if (loadButton != null)
        {
            loadButton.onClick.AddListener(() => SceneManager.LoadScene(scene.BuildIndex));
        }
    }

    private void OnDestroy()
    {
        if (loadButton != null)
        {
            loadButton.onClick.RemoveAllListeners();
        }
    }
}
