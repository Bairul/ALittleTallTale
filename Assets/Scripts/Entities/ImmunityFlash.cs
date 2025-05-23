using System.Collections;
using UnityEngine;

public class ImmunityFlash : MonoBehaviour
{
    [SerializeField]
    private Material flashMaterial;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    private IEnumerator FlashRoutine(float flashDuration)
    {
        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.material = originalMaterial;

        flashRoutine = null;
    }

    public void Flash(float flashDuration)
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine(flashDuration));
    }
}
