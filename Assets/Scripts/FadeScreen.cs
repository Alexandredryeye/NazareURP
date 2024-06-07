using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration;
    public Color fadeColor;
    private Renderer Renderer;
   

    void Start()
    {
        Renderer = GetComponent<Renderer>();
        if (fadeOnStart)       
            FadeIn();
        
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }
    public void FadeIn()
    {
        Fade(1,0);
        print("Coloriu");
    }
    public void FadeOut()
    {
         
         Fade(0,1);
    }
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            Renderer.material.SetColor("_BaseColor", newColor);
            timer += Time.deltaTime;
            
            yield return null;

        }
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        Renderer.material.SetColor("_BaseColor", newColor2);
        
    }
}
