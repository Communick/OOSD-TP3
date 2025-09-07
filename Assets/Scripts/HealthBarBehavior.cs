using System.Collections;
using UnityEngine;

public class HealthBarBehavior : MonoBehaviour
{
    [SerializeField]
    private RectTransform topBar;
    [SerializeField]
    private RectTransform bottomBar;
    private float fullWidth;
    private float targetWidth;
    private Coroutine adjustBarCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fullWidth = topBar.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AdjustBar(int amount)
    {
        var suddenChange = amount >=0 ? topBar : bottomBar;
        var slowChange = amount >=0 ? bottomBar : topBar;
        suddenChange.SetWidth(targetWidth);
        while (Mathf.Abs(suddenChange.rect.width - slowChange.rect.width) > 0.5f)
        {
            slowChange.SetWidth(Mathf.Lerp(slowChange.rect.width, targetWidth, Time.deltaTime * 10f));
            yield return null;
        }
        slowChange.SetWidth(targetWidth);
    }

    public void Change(ref int amount)
    {
        if (adjustBarCoroutine != null)
        {
            StopCoroutine(adjustBarCoroutine);
        }
        adjustBarCoroutine = StartCoroutine(AdjustBar(amount));
    }

    public float SetTarget(ref int value, ref float maxValue)
    {
        targetWidth = value * fullWidth / maxValue;
        return targetWidth;
    }
}
