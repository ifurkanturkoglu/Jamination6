using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;
    [SerializeField] RectTransform browser,website1,website2,website3,mainScreen;
    public string password = "deneme";
    public List<Transition> transitions = new List<Transition>();
    [System.Serializable]
    public struct Transition
    {
        public string key{get; set; }
        public RectTransform openObject{get; set; }
    }
    void Start()
    {
        Instance = this;
        print(GameObject.Find("Website"+1).GetComponent<RectTransform>());
        for (int i = 1; i < 4; i++)
        {   
            RectTransform b = GameObject.Find("Website"+i).GetComponent<RectTransform>();
            transitions.Add(new Transition{key = "şifre"+i,openObject = b});
    }
    }

    
    void Update()
    {
        
    }
}
