using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroTextManager : MonoBehaviour {

    public float delayInSeconds;
    public int LevelToLoad = 0;
    private List<GameObject> textObjects;
    private int currentText = -1;
    private FadeText currentElement;
    private int numberOfChildren;

    void Start()
    {
        textObjects = new List<GameObject>();
        numberOfChildren = gameObject.transform.childCount;
        for (int i = 0; i < numberOfChildren; i++)
        {
            textObjects.Add(gameObject.transform.GetChild(i).gameObject);
        }

        currentElement = new FadeText();
        currentElement.IsEnded = true;
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            FadeOutCurrentTextElement();
        }

        if (currentElement.IsEnded)
        {
            if (currentText < numberOfChildren -1)
            {
                SetNextElement();
                FadeInCurrentTextElement();
            }
            else
            {
                SceneManager.LoadScene(LevelToLoad);
            }
        }
	}

    private void FadeInCurrentTextElement()
    {
        StartCoroutine(currentElement.FadeTextToFullAlpha(delayInSeconds, textObjects[currentText].GetComponent<Text>()));
    }

    private void FadeOutCurrentTextElement()
    {
        StopAllCoroutines();
        StartCoroutine(currentElement.FadeTextToZeroAlpha(delayInSeconds, textObjects[currentText].GetComponent<Text>()));
    }

    private void SetNextElement()
    {
        currentText++;
        currentElement = textObjects[currentText].GetComponent<FadeText>();
    }
}
