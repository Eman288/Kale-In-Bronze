using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    public Text uiText; // Assign your Text object in the Inspector
    private string fullText = "Hello there! Welcome to Version 0 of the 'Kale in Bronze' Game!\n" +
                         "I’m really excited for you to give this version a try. It's a fun little experience, and I hope it adds a bit of joy to your day!\n" +
                         "Please feel free to share any thoughts or suggestions you might have. I’d love to hear from you! Your feedback is important, and it helps me make the game even better.\n" +
                         "Thanks for joining me on this leafy adventure, and stay tuned for more updates!\n" +
                         ":D";
    public float delay = 0.04f; // Delay between each character

    private string currentText = "";

    private Coroutine typingCoroutine;

    int index = 0;

    void Start()
    {
        StartTyping(fullText);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            index += 1;
            switch (index)
            {
                case 1:
                    fullText = "Note!!\n" +
                        "the music in this game for now are copyrighted to the original authors. i am planning to change them soon!\n" +
                        "thanks again :)";
                    break;
                case 2:
                    fullText = "Hope you have a good time!\n";
                    break;
                case 3:
                    fullText = "One night, as you and your friends gathered at your house, " +
                        "the games took an unexpected turn. What began as playful banter quickly escalated into weird challenges, " +
                        "and suddenly you found yourself the reluctant target. Your friends dared you to venture to the old mansion perched atop " +
                        "the town’s cliff, its silhouette ominous against the moonlit sky. ";
                    break;
                case 4:
                    fullText = "Laughter filled the room, but it was laced with a hint of unease. Some giggled nervously, while others " +
                        "declared it a ridiculous idea, their voices wavering. The mansion had long been the subject of ghost stories and " +
                        "whispered legends—a place where shadows moved on their own and doorways seemed to beckon the unwary.";
                    break;
                case 5:
                    fullText = "But who were you to back down from a little fun, especially in front of your friends? With your heart pounding, " +
                        "you grabbed a flashlight and stepped into the chill of the night, the air thick with dread and anticipation. As you approached " +
                        "the mansion, the wind howled like a lost soul, and the faint creaking of the ancient building echoed in the silence. Was that " +
                        "laughter fading behind you, or the wind playing tricks? You couldn’t tell. All you knew was that something awaited you inside " +
                        "the dark, crumbling walls—something that had been waiting for a long, long time.";
                    break;
                case 6:
                    fullText = "BANG!! BANG!!\n" +
                        "You knock on the wide door, but silence answers. Taking a deep breath, you slide it open, heart pounding. Shadows dance in the dim light, and a chilling breeze whispers your name as you step inside, the door creaking ominously shut behind you.";
                        break;
                case 7:
                    StopTyping();
                    SceneManager.LoadScene(2);
                    break;
            }

            StopTyping();
            StartTyping(fullText);
        }
    }

    public void StartTyping(string newText)
    {
        // Stop any existing coroutine
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Start a new coroutine for the typewriter effect
        typingCoroutine = StartCoroutine(TypeText(newText));
    }

    public void StopTyping()
    {
        // Stop the current coroutine and clear the text
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        uiText.text = ""; // Clear the text (optional, can leave the current text)
    }

    IEnumerator TypeText(string fullText)
    {
        uiText.text = ""; // Clear the text initially

        for (int i = 0; i <= fullText.Length; i++)
        {
            uiText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }

        // Coroutine finishes
        typingCoroutine = null;
    }
}
