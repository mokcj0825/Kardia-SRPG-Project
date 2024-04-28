using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TextboxPosition
{
    Top, Middle, Bottom
}
/**
 * TODO: INCOMPLETE
 * Prefab used in this service: Assets > Resources > UIPrefabs
 * A service to invoke messagebox for the game.
 * User GameObject.AddComponent<> to instantiate.
 * */
public class TextboxService : MonoBehaviourBase
{

    public static TextboxService Instance;


    public GameObject topTextbox;
    public GameObject middleTextbox;
    public GameObject bottomTextbox;

    private void Awake()
    {

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("UIPrefabs/Textbox");
        if(prefab != null)
        {
            topTextbox = InstantPrefab(prefab, TextboxPosition.Top);
            middleTextbox = InstantPrefab(prefab, TextboxPosition.Middle);
            bottomTextbox = InstantPrefab(prefab, TextboxPosition.Bottom);


        } else
        {
            Debug.LogError("Failed to load TextboxPrefab from Resources");
        }
        topTextbox.SetActive(true);
        middleTextbox.SetActive(true);
        bottomTextbox.SetActive(true);
    }

    private GameObject InstantPrefab(GameObject prefab, TextboxPosition position)
    {
        GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(screenWidth * 0.8f, screenHeight * 0.2f);
        switch (position)
        {
            case TextboxPosition.Top:
                rectTransform.localPosition = new Vector2(screenWidth * 0.5f, screenHeight * 0.8f);
                break;
            case TextboxPosition.Middle:
                rectTransform.localPosition = new Vector2(screenWidth * 0.5f, screenHeight * 0.5f);
                break;
            case TextboxPosition.Bottom:
                rectTransform.localPosition = new Vector2(screenWidth * 0.5f, screenHeight * 0.2f);
                break;
        }
        return obj;
    }

    public void ShowText(string message, TextboxPosition position)
    {
        Debug.Log("Show Text");
        switch (position)
        {
            case TextboxPosition.Top:
                topTextbox.GetComponentInChildren<Text>().text = message;
                topTextbox.SetActive(true);
                break;
            case TextboxPosition.Middle:
                middleTextbox.GetComponentInChildren<Text>().text = message;
                middleTextbox.SetActive(true);
                break;
            case TextboxPosition.Bottom:
                bottomTextbox.GetComponentInChildren<Text>().text = message;
                bottomTextbox.SetActive(true);
                break;
        }
    }

    public void HideText(TextboxPosition position)
    {
        switch (position)
        {
            case TextboxPosition.Top:
                topTextbox.SetActive(false);
                break;
            case TextboxPosition.Middle:
                middleTextbox.SetActive(false);
                break;
            case TextboxPosition.Bottom:
                bottomTextbox.SetActive(false);
                break;
        }
    }
}
