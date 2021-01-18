using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup cv;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cv = GetComponent<CanvasGroup>();

        cv.interactable = false;
        cv.blocksRaycasts = false;
    }

    public void Show()
    {
        GetComponent<Animator>().Play("FadeInUI");
        cv.interactable = true;
        cv.blocksRaycasts = true;
    }

    public void Hide()
    {
        GetComponent<Animator>().Play("FadeOutUI");
        cv.interactable = false;
        cv.blocksRaycasts = false;
    }
}
