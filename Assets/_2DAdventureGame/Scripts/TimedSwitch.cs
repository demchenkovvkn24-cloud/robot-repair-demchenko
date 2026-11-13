using System.Collections;
using UnityEngine;

public class TimedSwitch : MonoBehaviour
{
    [Header("Налаштування перемикача")]
    public GameObject door;
    public float openTime = 4f;

    private bool isActivated = false;
    private SpriteRenderer spriteRenderer;
    private Color defaultColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            defaultColor = spriteRenderer.color;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            StartCoroutine(ActivateSwitch());
        }
    }

    private IEnumerator ActivateSwitch()
    {
        isActivated = true;

        if (spriteRenderer != null) spriteRenderer.color = Color.green;
        if (door != null) door.SetActive(false);

        yield return new WaitForSeconds(openTime);

        if (door != null) door.SetActive(true);
        if (spriteRenderer != null) spriteRenderer.color = defaultColor;

        isActivated = false;
    }
}