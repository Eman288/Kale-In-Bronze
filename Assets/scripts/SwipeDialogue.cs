using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;

public class SwipeDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    //List<GameObject> dialogues = new List<GameObject>();
    //List<GameObject> questions = new List<GameObject>();

    public GameObject logic;
    public GameObject music;
    private int d = 37;
    public int q = 0;

    int dIndex = 0;
    //int currentIndex = 0;

    private Animator animator1;
    private Animator animator2;
    public GameObject Aron;
    public GameObject Kale;
    public GameObject textBox;

    public Text uiText;
    private String fullText = "OW!! i think i hit my head at something...";

    private float delay = .04f;

    private Coroutine typingCoroutine;

    void Awake()
    {
        animator1 = Kale.GetComponent<Animator>();
        animator2 = Aron.GetComponent<Animator>();

        StartTyping(fullText);


        if (logic == null)
        {

            logic = GameObject.FindGameObjectWithTag("Logic");
        }
        if (music == null)
        {
            music = GameObject.FindGameObjectWithTag("Music");
        }
        animator2.Play("NotAmusedAron");
    
    }

    // Update is called once per frame
    void Update()
    {
            if (dIndex < d)
            {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                dIndex += 1;
                switch (dIndex)
                {
                    case 1:
                        // Aron
                        fullText = "hello...? This place is huge. Is someone here?...\n" +
                            "I guess this place is really empty";
                        animator2.Play("NormalAron");
                        animator1.Play("NormalNoTalkingKale");
                        break;
                    case 2:
                        // Kale
                        fullText = "Hi! a human! it has been a while since I saw one!!";
                        animator1.Play("NormalKale");
                        animator2.Play("NoTalkingNormalAron");
                        break;
                    case 3:
                        // Aron
                        fullText = "Whoa! What is that?!";
                        animator2.Play("NotAmusedAron");
                        animator1.Play("NormalNoTalkingKale");
                        break;
                    case 4:
                        // Aron
                        fullText = "a-a child?...you scared me!\n...wait, why are you floating...?";
                        break;
                    case 5:
                        // Kale
                        fullText = "Cause i am a ghost, duh";
                        animator1.Play("NormalKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 6:
                        // Aron
                        fullText = "a what now?!";
                        animator2.Play("NotAmusedAron");
                        animator1.Play("NormalNoTalkingKale");
                        break;
                    case 7:
                        // Kale
                        fullText = "a ghost! I live here since...umm...I was born!";
                        animator1.Play("NormalKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 8:
                        // Kale
                        fullText = "oh! I am Kale! what is your name?! wanna be friends?!\n" +
                            "i wanna! i wanna!";
                        break;
                    case 9:
                        // Aron
                        fullText = "f-friends? wait- no!\n" +
                            "that is it, i knew it was a bad idea. i am leaving";
                        animator2.Play("NotAmusedAron");
                        animator1.Play("NormalNoTalkingKale");
                        break;
                    case 10:
                        // Kale
                        fullText = "eh? but no humans can leave after entering this place...actually nothing really can get out even me";
                        animator1.Play("NotHappyKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 11:
                        // Aron
                        fullText = "you are joking, right? I can't die young! i still have so many games left to play!";
                        animator2.Play("ReallyAron");
                        animator1.Play("NotHappyNoTalkingKale");
                        break;
                    case 12:
                        // Kale
                        fullText = "oh? we can play together! come on..I know a lot of good games like...umm...tag? or! or! we can play-";
                        animator1.Play("NormalKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 13:
                        // Kale
                        fullText = "a cooking game and cook some food together! i have a lot of monster's eyes in the basement, it taste good with the black sauce";
                        break;
                    case 14:
                        // Kale
                        fullText = "oh...wait right, humans can't eat monsters eyes";
                        animator2.Play("NotTalkingReallyAron");
                        break;
                    case 15:
                        // Aron
                        fullText = "I am not playing any games!\n" +
                            "is there no way out really?";
                        animator2.Play("NotAmusedAron");
                        animator1.Play("NormalNoTalkingKale");
                        break;
                    case 16:
                        // Kale
                        fullText = "hmm...oh! yeah, there is. but it might be hard on a weak creature like a human yourself...";
                        animator1.Play("NotHappyKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 17:
                        // Aron
                        fullText = "just say it...";
                        animator1.Play("NormalNoTalkingKale");
                        animator2.Play("NotAmusedAron");
                        break;
                    case 18:
                        // Kale
                        fullText = "The only way to get out is to make this mansion's curse disappear. and that is by solving the main mystery here";
                        animator1.Play("NotHappyKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 19:
                        // Aron
                        fullText = "and what is the mystery about?";
                        animator2.Play("NotAmusedAron");
                        animator1.Play("NotHappyNoTalkingKale");
                        break;
                    case 20:
                        // Kale
                        fullText = "Unraveling the mystery of the one who took my life in this mansion long ago...";
                        animator1.Play("NotHappyKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 21:
                        // Kale
                        fullText = "There was someone so cruel that they dared to snuff out my life... an innocent child's life...";
                        animator1.Play("CreepyKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 22:
                        // Kale
                        fullText = "I yearn—no, I crave—to know who it was, no matter the cost. I will stop at nothing to expose the monster-";
                        animator2.Play("NotTalkingReallyAron");
                        break;
                    case 23:
                        fullText = "lurking in the darkness. you will help, right?...Aron....";
                        break;
                    case 24:
                        // Aron
                        fullText = "oook....i did not tell you my name....that is creepy\n";
                        animator1.Play("NotTalkingCreepyKale");
                        animator2.Play("ReallyAron");
                        break;
                    case 25:
                        // Aron
                        fullText = "i guess i don't have any other choice anyway...fine I will help you...";
                        animator2.Play("NotAmusedAron");
                        break;
                    case 26:
                        // Kale
                        fullText = "yay! i knew you were more than my dinner today! ";
                        animator1.Play("NormalKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 27:
                        //Aron
                        fullText = "wait, what?";
                        animator2.Play("ReallyAron");
                        animator1.Play("NormalNoTalkingKale");
                        break;
                    case 28:
                        // Kale
                        fullText = "anyway, before you can actually start. i need to test you a bit";
                        animator1.Play("NormalKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 29:
                         // Aron
                        fullText = "test?";
                        animator2.Play("NotAmusedAron");
                        animator1.Play("NormalNoTalkingKale");
                        break;
                    case 30:
                        // Kale
                        fullText = "yeah, a test! normally the curse will eat the humans' life and they can't really survive here for a long time";
                        animator1.Play("NormalKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 31:
                        // Kale
                        fullText = "so i need to lend you some of my ghost energy!";
                        break;
                    case 32:
                        // Aron
                        fullText = "oh..";
                        animator2.Play("NotAmusedAron");
                        animator1.Play("NormalNoTalkingKale");
                        break;
                    case 33:
                        // Kale
                        fullText = "but again, I need to determine how much can your body bear my energy";
                        animator1.Play("NormalKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                    case 34:
                        // Kale
                        fullText = "don't worry! it is just some simple questions...or scenarios to be exact";
                        break;
                    case 35:
                        // Aron
                        fullText = "...ok then...i am ready, i guess..";
                        animator2.Play("NotAmusedAron");
                        animator1.Play("NormalNoTalkingKale");
                        break;
                    case 36:
                        // Kale
                        fullText = "Great! let's start!";
                        animator1.Play("NormalKale");
                        animator2.Play("NoTalkingNotAmusedAron");
                        break;
                }

                StopTyping();
                StartTyping(fullText);
            }
                Debug.Log(dIndex);
                
                    if (dIndex == d - 1 && q == 0)
                    {
                        Aron.SetActive(false);
                        Kale.SetActive(false);
                        textBox.SetActive(false);        

                        DontDestroyOnLoad(logic);
                        DontDestroyOnLoad(music);
                        SceneManager.LoadScene(3);
                    }
                    
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
