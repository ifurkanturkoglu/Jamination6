using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] RectTransform openObject,closeObject;
    [SerializeField]public InputField passwordInput;
    float timer;
    void Start()
    {
        StartCoroutine(OpenCloseUIObject(openObject,closeObject));
        print(Data.Instance.transitions[0].key);
    }

    
    void Update()
    {
        
    }


    
    IEnumerator OpenCloseUIObject(RectTransform openObject,RectTransform closeObject){
        while(timer <=1){
            Vector3 timePosOpen = new Vector3(Time.deltaTime,Time.deltaTime, Time.deltaTime);
            openObject.localScale += timePosOpen;
            Vector3 timePosClose = new Vector3(Time.deltaTime,Time.deltaTime, Time.deltaTime); 
            closeObject.localScale -= timePosClose;
            timer += Time.deltaTime;
            yield return null;
        }
        openObject.localScale = Vector3.one;
        closeObject.localScale = Vector3.zero;
    }
}
