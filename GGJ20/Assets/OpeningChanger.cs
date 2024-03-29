﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningChanger : MonoBehaviour
{
   public string targetScene = "SampleScene";

    bool transitioning = false;
    float secondsToTransition = 8.2f;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SceneTransitionTimer());
        StartCoroutine(SceneTransitionKey());
    }

    
    private IEnumerator SceneTransitionTimer() {
        yield return new WaitForSeconds(secondsToTransition);
        TransitionScene();
    }
    

    private IEnumerator SceneTransitionKey() {
        while (!Input.anyKey) {
            yield return null;
        }
        TransitionScene();
    }

    private void TransitionScene() {
        if (!transitioning) {
            transitioning = true;
            SceneManager.LoadScene(targetScene);
        }
    }
}
