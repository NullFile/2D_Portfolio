using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    protected bool isFade = true;

    [SerializeField] 
    protected Image Panel;

    [SerializeField]
    [Range(2.0f, 4.0f)]
    protected float fadeTime = 2.0f;
    protected float calcFade = 0.0f;    
    
    [SerializeField]
    [Range(2.0f, 4.0f)]
    protected float delayTime = 2.0f;
    protected float calcDelay = 0.0f;

    protected Color calcColor = new Color();

    protected virtual void FadeStart()
    {
        calcFade = fadeTime;
    }

    protected virtual void FadeUpdate()
    {
        if (0.0f < calcDelay)
            calcDelay -= Time.deltaTime;
        else
        {
            if (isFade == true)
                FadeIn();
            else
                FadeOut();
        }
    }

    #region Fade In
    protected virtual void FadeIn()
    {
        if (0.0f < calcFade)
        {
            calcFade -= Time.deltaTime;

            calcColor = Panel.color;
            calcColor.a = calcFade;
            Panel.color = calcColor;

            if (calcFade < 0.0f)
            {
                calcFade = 0.0f;
                isFade = false;
                calcDelay = delayTime;
            }
        }
    }    
    
    protected virtual void FadeInScene(string name)
    {
        if (0.0f < calcFade)
        {
            calcFade -= Time.deltaTime;

            calcColor = Panel.color;
            calcColor.a = calcFade;
            Panel.color = calcColor;

            if (calcFade < 0.0f)
            {
                calcFade = 0.0f;
                SceneManager.LoadScene(name);
            }
        }
    }
    #endregion

    #region Fade Out
    protected virtual void FadeOut()
    {
        if (calcFade < fadeTime)
        {
            calcFade += Time.deltaTime;

            calcColor = Panel.color;
            calcColor.a = calcFade;
            Panel.color = calcColor;

            if (fadeTime < calcFade)
            {
                calcFade = fadeTime;
                isFade = true;
                calcDelay = delayTime;
            }
        }
    }    
    
    protected virtual void FadeOutScene(string name)
    {
        if (calcFade < fadeTime)
        {
            calcFade += Time.deltaTime;

            calcColor = Panel.color;
            calcColor.a = calcFade;
            Panel.color = calcColor;

            if (fadeTime < calcFade)
            {
                calcFade = fadeTime;
                SceneManager.LoadScene(name);
            }
        }
    }
    #endregion
}
