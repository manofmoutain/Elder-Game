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
    #endif
    public int maximum;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill(){
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
        fill.color = color;
    }
}
