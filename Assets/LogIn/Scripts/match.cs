using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class match : MonoBehaviour
{
    
    public RectTransform content;
    private RectTransform txtHieght;
    public GameObject FGameObject;

    public GameObject ChildGameobject;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    //set context size
    public void matchHeight()
    {
        var height = ChildGameobject.GetComponent<RectTransform>().rect.height;
        content.sizeDelta=new Vector2(content.rect.width, height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
