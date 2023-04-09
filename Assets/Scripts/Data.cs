using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Data : MonoBehaviour
{
    public static Data Instance;
    public RectTransform browser, website1, website2, website3, mainScreen, loginScreen,encryptedFile,history;
    public string password = "05082007";
    public string encryptedFilePassword = "4595";
    string [] keys = {"Jamination6","6655822413","Mahmut Yazar"};
    public List<Transition> transitions = new List<Transition>();
    public string urlKey;
    [System.Serializable]
    public struct Transition
    {
        public string key { get; set; }
        public RectTransform openObject { get; set; }
    }
    void Awake()
    {
        for (int i = 1; i < 4; i++)
        {
            RectTransform b = GameObject.Find("Website" + i).GetComponent<RectTransform>();
            Transition c = new Transition{key = keys[i-1], openObject = b};
            transitions.Add(c);
            
        }
    }
    void Start()
    {
        Instance = this;
    }


    void Update()
    {

    }
    public RectTransform SearchBrowserWebsite(){
        if(keys.Contains(UIController.Instance.searchInput.text)){
            urlKey = transitions.Find(a=> a.key == UIController.Instance.searchInput.text).key;
            return transitions.Find(a=> a.key == UIController.Instance.searchInput.text).openObject;
        }
        else{
            return null;
        }
    }
    public bool Search(){
         if(keys.Contains(UIController.Instance.searchInput.text)){
            return true;
        }
        else{
            return false;
        }
    }
}
