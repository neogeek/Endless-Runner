using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField]
    private string _sceneName;

    public void LoadScene()
    {

        SceneManager.LoadScene(_sceneName);

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)

        {

            LoadScene();

        }

    }

}
