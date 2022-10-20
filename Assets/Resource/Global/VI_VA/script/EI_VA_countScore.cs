using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EI_VA_countScore : MonoBehaviour
{
    // Start is called before the first frame update
    public float totle;
    public float currect;
    public float dismiss;
    public float miss;
    public float oneTestScore;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"> 0=currect;1=dismistake;2=miss</param>
    public void switchScore(int i) {
        if (i == 0) {
            totle += oneTestScore;
            currect++;
        }
        else if (i == 1)
        {
            dismiss++;
        }
        else if (i == 2)
        {
            miss++;
        }
    }
}
