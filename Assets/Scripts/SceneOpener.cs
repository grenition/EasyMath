using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OpenSceneWithAnimation(string sceneName)
    {
        SceneTransitionAnimationController.instance.OpenTransition();
        StartCoroutine(WaitToOpenScene(sceneName, SceneTransitionAnimationController.instance.fadeOpenDuration));
    }

    private IEnumerator WaitToOpenScene(string sceneName, float time)
    {
        yield return new WaitForSeconds(time);
        OpenScene(sceneName);
    }
}
