using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] public InputField passwordInput, searchInput, encryptInput;
    [SerializeField] GameObject wrongPasswordText, wrongPasswordEncryptText;
    [SerializeField] TextMeshProUGUI url;
    RectTransform currentObject;
    float timer;
    bool encryptIsOpen, encryptFileIsOpen, historyIsOpen, homeIsOpen;
    void Start()
    {
        Instance = this;
    }


    void Update()
    {

    }

    public void PasswordCheck()
    {
        print(passwordInput.text);
        print(Data.Instance.password);
        if (passwordInput.text.Equals(Data.Instance.password))
        {
            StartCoroutine(OpenCloseUIObject(Data.Instance.mainScreen, Data.Instance.loginScreen));
        }
        else
        {
            StartCoroutine(WrongPasswordTextShow(wrongPasswordText));
        }
    }
    public void EncryptPasswordCheck()
    {
        if (encryptInput.text.Equals(Data.Instance.encryptedFilePassword))
        {
            print("başarılı");
            SceneManager.LoadScene(2);
            //Ara sahne gelicek
        }
        else
        {
            StartCoroutine(WrongPasswordTextShow(wrongPasswordEncryptText));
        }
    }
    public void OpenBrowser()
    {
        StartCoroutine(OpenCloseUIObject(Data.Instance.browser, Data.Instance.mainScreen));
        searchInput.GetComponent<RectTransform>().localScale = Vector3.one;
    }
    public void CloseBrowser()
    {
        StartCoroutine(OpenCloseUIObject(Data.Instance.mainScreen, Data.Instance.browser));
        CloseAllWebsite();
    }
    public void BrowserReturnMainPage()
    {
        if (currentObject != null && !homeIsOpen)
        {
            StartCoroutine(OpenCloseUIObject(searchInput.GetComponent<RectTransform>(), null));
            historyIsOpen = false;
            homeIsOpen = true;
            CloseAllWebsite();
        };
        url.text = "www.jamination6.com";
    }
    public void OpenWebsite()
    {
        if (Data.Instance.Search())
        {
            StartCoroutine(OpenCloseUIObject(Data.Instance.SearchBrowserWebsite(), searchInput.GetComponent<RectTransform>()));
            currentObject = Data.Instance.SearchBrowserWebsite();
            url.text = "www." + Data.Instance.urlKey + ".com";
            homeIsOpen = false;
        }

    }
    public void OpenHistory()
    {
        if (!historyIsOpen)
        {
            StartCoroutine(OpenCloseUIObject(Data.Instance.history, searchInput.GetComponent<RectTransform>()));
            historyIsOpen = true;
            currentObject = Data.Instance.history;
            homeIsOpen = false;
        }
    }
    public void OpenEncryptedFile()
    {
        if (!encryptFileIsOpen)
        {
            StartCoroutine(OpenCloseUIObject(Data.Instance.encryptedFile, null));
            encryptFileIsOpen = true;
        }
    }
    public void CloseEncryptedFile()
    {
        encryptFileIsOpen = false;
        StartCoroutine(OpenCloseUIObject(null, Data.Instance.encryptedFile));
    }
    public string SearchingWords()
    {
        return searchInput.text;
    }
    void CloseAllWebsite()
    {
        Data.Instance.history.localScale = Vector3.zero;
        Data.Instance.website1.localScale = Vector3.zero;
        Data.Instance.website2.localScale = Vector3.zero;
        Data.Instance.website3.localScale = Vector3.zero;
    }
    public void ClosePC()
    {
        Data.Instance.history.localScale = Vector3.zero;
        Data.Instance.website1.localScale = Vector3.zero;
        Data.Instance.website2.localScale = Vector3.zero;
        Data.Instance.website3.localScale = Vector3.zero;
        Data.Instance.browser.localScale = Vector3.zero;
        Data.Instance.mainScreen.localScale = Vector3.zero;
        Data.Instance.loginScreen.localScale = Vector3.zero;
        Data.Instance.encryptedFile.localScale = Vector3.zero;

    }
    public IEnumerator OpenCloseUIObject(RectTransform openObject, RectTransform closeObject)
    {
        while (timer <= 1)
        {
            Vector3 timePosOpen = new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            if (openObject != null)
                openObject.localScale += timePosOpen;
            Vector3 timePosClose = new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            if (closeObject != null)
                closeObject.localScale -= timePosClose;
            timer += Time.deltaTime;
            yield return null;
        }
        if (openObject != null)
            openObject.localScale = Vector3.one;
        if (closeObject != null)
            closeObject.localScale = Vector3.zero;

        timer = 0;
    }

    IEnumerator WrongPasswordTextShow(GameObject text)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(2);
        text.SetActive(false);
    }

}
