using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class SceneControlIntro : MonoBehaviour
{

        public VideoPlayer videoPlayer;
        public string nextSceneName = "Game";

        void Start()
        {
            videoPlayer.loopPointReached += OnVideoFinished;
        }

        void OnVideoFinished(VideoPlayer vp)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    

}
