using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
	#region Fields
	[SerializeField] private FadeScreen _fadeScreen;
    private static SceneTransitionManager _instance;
    #endregion

    #region Properties
    public static SceneTransitionManager Instance
    {
        get
        {
            return _instance;
        }
    }
	#endregion

	#region Unity Callbacks
	private void Awake()
    {
        if (_instance && _instance != this)
            Destroy(_instance);

        _instance = this;
    }
	#endregion

	#region Methods
	public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        _fadeScreen.FadeOut();
        yield return new WaitForSeconds(_fadeScreen.FadeDuration);

        SceneManager.LoadScene(sceneIndex);
    }

    public void GoToSceneAsync(int sceneIndex)
    {
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }

    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        _fadeScreen.FadeOut();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;
        while(timer <= _fadeScreen.FadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }

	#endregion
}
