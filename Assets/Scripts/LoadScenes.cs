using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public static int groupNum;
    public static int group5Num;
    public static int healthNum;
    public void Load(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        if(scenename=="sign in"){
            PlayerPrefs.DeleteKey("account");
            PlayerPrefs.DeleteKey("password");
        }
        SceneManager.LoadScene(scenename);
    }
    public void LoadGroup(int group) // 0健康促進 1情緒調節 2腦力提升
    {
        groupNum = group;
        Debug.Log("sceneName to load: form");
        SceneManager.LoadScene("form");
    }
    public void LoadGroup5(int group5) // 健康促進(小知識、動手做) 情緒調節(小知識、動手做) 腦力提升(小知識)
    {
        group5Num = group5;
        Debug.Log("sceneName to load: form 1");
        SceneManager.LoadScene("form 1");
    }
    public void LoadHealth(int health) //0步數 1心率 2壓力
    {
        healthNum = health;
        Debug.Log("sceneName to load: health 1");
        Debug.Log(healthNum);
        SceneManager.LoadScene("health 1");
    }
    public void Exit(){
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
