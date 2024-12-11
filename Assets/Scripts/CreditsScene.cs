using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class CreditsScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI creditsText;

    private float displayTime = 15f;

    private void Start()
    {
        StartCoroutine(DisplayCredits());
    }

    private IEnumerator DisplayCredits()
    {
        string[] credits = {
            "GAME CLEAR\n",
            "Made By: ÃÖÈ£À±, ¾ç¼Û¿í, ±è¹Î¼­, ±èÁøÈ¯\n",
            "For SW Basic Design\n",
            "Special Thanks to: Á¤½ÂÈ­ ±³¼ö´Ô\n"
        };

        float timePerText = displayTime / credits.Length;
        string fullText = "";

        for (int i = 0; i < credits.Length; i++)
        {
            fullText += credits[i] + "\n";
            creditsText.text = fullText;
            yield return new WaitForSeconds(timePerText);
        }

        SceneManager.LoadScene("MainMenu");
    }
}
