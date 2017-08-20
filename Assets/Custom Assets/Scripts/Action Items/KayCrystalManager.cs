using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

namespace YenensTale
{
    public class KayCrystalManager : MonoBehaviour
    {

        public static KayCrystalManager Instance;

        public AudioSource aSource;
        public AudioClip fadingTransition;

        public GameObject player;
        public Transform otherPos;
        Vector3 startPos;
        int startCull;

        private void Awake()
        {
            Instance = this;
            startPos = player.transform.position;
            startCull = Camera.main.cullingMask;
        }

        public void DoTransition()
        {
            StartCoroutine(DelayFade());
        }

        IEnumerator DelayFade()
        {
            //print(Time.time);
            yield return new WaitForSeconds(4);
            //print(Time.time);
            //Scene currentScene = SceneManager.GetActiveScene();
            aSource.PlayOneShot(fadingTransition);
            GameObject[] rootObjs = SceneManager.GetSceneAt(0).GetRootGameObjects();
            bool[] isActive = new bool[rootObjs.Length];
            for (int i = 0; i < rootObjs.Length; i++)
            {
                isActive[i] = rootObjs[i].activeSelf;
                if (rootObjs[i] != gameObject && rootObjs[i] != player) //&& !rootObjs[i].CompareTag("Needed"))
                    rootObjs[i].SetActive(false);
            }
            SceneManager.LoadScene("Par'n Kay Crystal (Crossroad)", LoadSceneMode.Additive);
            player.transform.position = otherPos.position;
            Camera.main.cullingMask = -1;
            yield return new WaitForSeconds(15);
            //SceneManager.LoadScene("Par'n Terrain", LoadSceneMode.Additive);                 Fix this line!!
            SceneManager.UnloadSceneAsync("Par'n Kay Crystal (Crossroad)");
            player.transform.position = startPos;
            Camera.main.cullingMask = startCull;
            for (int i = 0; i < rootObjs.Length; i++)
            {
                if (isActive[i])
                    rootObjs[i].SetActive(true);
            }
        }
    }
}
