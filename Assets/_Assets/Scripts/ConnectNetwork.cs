using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class ConnectNetwork : MonoBehaviour
{

    [SerializeField] GameObject elephant_Load;
    [SerializeField] GameObject retryLoad;

    private void Awake()
    {
        CheckInternetConnection();
    }


    private void CheckInternetConnection()
    {
        if(Application.internetReachability==NetworkReachability.NotReachable)
        {
            Debug.LogWarning("No Internet");
            StartCoroutine(RetryCheckInternet());
            
        }
        else if( Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            Debug.LogWarning("Wifi");
            StartCoroutine(PlayAfterAnimElephantLoad());
            
        }
        else if (Application.internetReachability==NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            Debug.LogWarning("4G");
            StartCoroutine(PlayAfterAnimElephantLoad());
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator RetryCheckInternet()
    {
        elephant_Load.SetActive(true);
        yield return new WaitForSeconds(2);
        retryLoad.SetActive(true);
    }
    IEnumerator PlayAfterAnimElephantLoad()
    {
        elephant_Load.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level1");
    }

}
