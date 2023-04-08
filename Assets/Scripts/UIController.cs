using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField]public InputField passwordInput,searchInput;
    RectTransform currentObject;
    float timer;
    void Start()
    {
        Instance = this;
    }

    
    void Update()
    {
        
    }

    public void PasswordCheck(){
        if(passwordInput.text.Equals(Data.Instance.password)){
            StartCoroutine(OpenCloseUIObject(Data.Instance.mainScreen,Data.Instance.loginScreen));
        }
        else{
            print("Hatalı giriş.");
        }
    }
    public void OpenBrowser(){
        StartCoroutine(OpenCloseUIObject(Data.Instance.browser,Data.Instance.mainScreen));
    }
    public void CloseBrowser(){
        StartCoroutine(OpenCloseUIObject(Data.Instance.mainScreen,Data.Instance.browser));
    }
    public void BrowserReturnMainPage(){
        if(currentObject != null){
            StartCoroutine(OpenCloseUIObject(searchInput.GetComponent<RectTransform>(),currentObject));
        };        
    }
    public void OpenWebsite(){
        StartCoroutine(OpenCloseUIObject(Data.Instance.SearchBrowserWebsite(),searchInput.GetComponent<RectTransform>()));
        currentObject = Data.Instance.SearchBrowserWebsite();
    }
    public string SearchingWords(){
        return searchInput.text;
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
