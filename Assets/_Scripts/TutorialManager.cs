using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Pages")]
    public GameObject[] tutorialPages;
    public GameObject tutorialPanel;

    private int currentPageIndex = 0;

    void Start()
    {
        if (tutorialPanel != null) tutorialPanel.SetActive(false);
    }

    public void OpenTutorial()
    {
        if (tutorialPanel != null) tutorialPanel.SetActive(true);
        currentPageIndex = 0;
        UpdatePages();
    }

    public void CloseTutorial()
    {
        if (tutorialPanel != null) tutorialPanel.SetActive(false);
    }

    public void NextPage()
    {
        if (currentPageIndex < tutorialPages.Length - 1)
        {
            currentPageIndex++;
            UpdatePages();
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            UpdatePages();
        }
    }

    private void UpdatePages()
    {
        for (int i = 0; i < tutorialPages.Length; i++)
        {
            // Pokud se číslo stránky rovná indexu, zapne se. Jinak se vypne.
            tutorialPages[i].SetActive(i == currentPageIndex);
        }
    }
}