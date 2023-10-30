using TMPro;
using UnityEngine;

public class FadeAndDisable : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 15.0f;
    [SerializeField] private TextMeshProUGUI[] textsToFade;

    private float fadeTimer = 0.0f;

    void Start()
    {
        // Make sure the objects are active at the very start of the game
        foreach (TextMeshProUGUI text in textsToFade)
        {
            if (text != null)
            {
                text.gameObject.SetActive(true);

                // Set the alpha of the text to 1 (fully visible) at the start
                Color startColor = text.color;
                startColor.a = 1.0f;
                text.color = startColor;
            }
            else
            {
                Debug.LogError("One of the TextMeshPro components is not assigned in the inspector.");
            }
        }
    }

    void Update()
    {
        foreach (TextMeshProUGUI text in textsToFade)
        {
            if (text == null)
            {
                continue;
            }

            // Gradually decrease the alpha value over time
            fadeTimer += Time.deltaTime;
            float alpha = 1.0f - (fadeTimer / fadeDuration);

            // Set the new alpha value to the text color
            Color newColor = text.color;
            newColor.a = alpha;
            text.color = newColor;

            // Check fade completion
            if (fadeTimer >= fadeDuration)
            {
                text.gameObject.SetActive(false);
                // Disable this script to stop further updates
                enabled = false;
            }
        }
    }
}
