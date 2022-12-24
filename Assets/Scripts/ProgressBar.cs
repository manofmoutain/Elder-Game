using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    #if UNITY_EDITOR
    [MenuItem("GameObject/UI/ProgressBar")]
    public static void AddProgressBar(){
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/ProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform,false);
    }
    
    [MenuItem("GameObject/UI/ProgressCircle")]
    public static void AddProgressCircle(){
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/ProgressCircle"));
        obj.transform.SetParent(Selection.activeGameObject.transform,false);
    }
    [MenuItem("GameObject/UI/ProgressRewardBar")]
    public static void AddProgressRewardBar(){
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/ProgressRewardBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform,false);
    }
    #endif
    public Image mask;
    public Image fill;
    public Image Reward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GetCurrentFill(float maximum, float current,Color color){
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
        fill.color = color;
    }
    public void GetCurrentFillValue(float maximum, float current){
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
    
    public void GetCurrentFillCircle(float maximum, float current,Color color){
        float fillAmount = (float)current / (float)maximum;
        fill.fillAmount = fillAmount;
        fill.color = color;
    }
    public void GetCurrentFillValueCircle(float maximum, float current){
        float fillAmount = (float)current / (float)maximum;
        fill.fillAmount = fillAmount;
    }
    public void GetCurrentFillRewardBar(float maximum, float current,Color color,Sprite sprite){
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
        fill.color = color;
        Reward.sprite = sprite;
    }
    
}
