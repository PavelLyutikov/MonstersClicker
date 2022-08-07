using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitlesScrollView : MonoBehaviour
{

    private ScrollRect scrollRect;
    [SerializeField] private float scrollSpeed = 0.0001f;
    [SerializeField] private GameObject titlesPanel;

    public void StartScroll()
    {

        scrollRect = GetComponent<ScrollRect>();
        StartCoroutine(Scrolling());
    }


    private IEnumerator Scrolling()
    {
        yield return new WaitForSeconds(0.001f);

        if (scrollRect != null)
        {
            if (scrollRect.verticalNormalizedPosition >= 0.2f)
            {
                scrollRect.verticalNormalizedPosition -= scrollSpeed;
            }

            StartCoroutine(Scrolling());
        }

    }

    private void Update()
    {
        if(scrollRect.verticalNormalizedPosition <= 0.2f)
        {
            titlesPanel.SetActive(false);
            scrollRect.verticalNormalizedPosition = 0.5f;
        }
    }
}
