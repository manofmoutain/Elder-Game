using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace EI_VA { 
public class EI_VA_function 
{
    // Start is called before the first frame update
    
    public float totle;
        public float currect;
        public float dismiss;
        public float miss;
        // Start is called before the first frame update



        

        


        public IEnumerator WaitTimer(float time) { 
        yield return new WaitForSeconds(time);
        }

}
}

