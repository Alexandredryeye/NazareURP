using System.Collections;
using UnityEngine;

public class SoundDelayAndActivate : MonoBehaviour
{
    public AudioSource audioSource; // Refer�ncia ao componente AudioSource
    public GameObject objectToActivate; // Refer�ncia ao objeto a ser ativado
    public float delay = 3.0f; // Tempo de espera antes de come�ar a tocar o som

    private void Start()
    {
        // Inicialmente desativamos o objeto
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }

        // Inicia a corrotina para tocar o som ap�s um atraso
        StartCoroutine(PlaySoundAfterDelay());
    }

    private IEnumerator PlaySoundAfterDelay()
    {
        // Espera pelo tempo especificado
        yield return new WaitForSeconds(delay);

        // Toca o som
        if (audioSource != null)
        {
            audioSource.Play();

            // Inicia a corrotina para verificar quando o som termina
            StartCoroutine(ActivateObjectAfterSound());
        }
    }

    private IEnumerator ActivateObjectAfterSound()
    {
        // Espera at� que o som termine de tocar
        while (audioSource.isPlaying)
        {
            yield return null; // Espera um frame antes de continuar o loop
        }

        // Ativa o objeto
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}