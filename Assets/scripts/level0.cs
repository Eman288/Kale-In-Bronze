using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions.Must;

public class level0 : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> dialogues = new List<GameObject>();
    List<GameObject> dialogues2 = new List<GameObject>();
    List<GameObject> questions = new List<GameObject>();
    private player player;

    public GameObject logic;
    public GameObject music;
    public int d;
    public int dd;
    public int q = 0;

    public Text c;
    public Text s;
    public Text r;

    int dIndex = 0;
    int ddIndex = 0;
    int qIndex = 0;

    static int clicked = -1;

    private Animator animator1;
    private Animator animator2;
    public GameObject Aron;
    public GameObject Kale;

    void Awake()
    {
        Aron.SetActive(false);
        Kale.SetActive(false);

        animator1 = Kale.GetComponent<Animator>();
        animator2 = Aron.GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        if (logic == null)
        {

            logic = GameObject.FindGameObjectWithTag("Logic");
        }
        if (music == null)
        {
            music = GameObject.FindGameObjectWithTag("Music");
        }
        for (int i = 0; i < d; i++)
        {
            string name = 'd' + i.ToString();
            GameObject obj = GameObject.Find(name);
            if (obj != null)
            {
                dialogues.Add(obj);
                obj.SetActive(false);
            }
        }
        if (q != 0)
        { 
            
            for (int i = 0; i < q; i++)
            {
                string name = "QA" + i.ToString();
                GameObject obj = GameObject.Find(name);
                if (obj != null)
                {
                    questions.Add(obj);
                    obj.SetActive(false);
                }
            }
        }
        for (int i = 0; i < dd; i++)
        {
            string name = "dd" + i.ToString();
            GameObject obj = GameObject.Find(name);
            if (obj != null)
            {
                dialogues2.Add(obj);
                obj.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dIndex < d)
        {
            if (!(dialogues[dIndex].activeSelf))
            {
                dialogues[dIndex].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogues[dIndex].SetActive(false);
                dIndex += 1;
            }
        }
        else if (q != 0 && qIndex < q)
        {
            music.SetActive(false);
            if (clicked == -1)
            {
                questions[qIndex].SetActive(true);
                GameObject question = questions[qIndex].transform.GetChild(0).gameObject;
                GameObject answer = questions[qIndex].transform.GetChild(1).gameObject;

                question.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    question.SetActive(false);
                    answer.SetActive(true);
                    clicked = 0; // if it is 0 wait for an answer
                }
            }
            else if (clicked != 0)
            {
                questions[qIndex].transform.GetChild(1).gameObject.SetActive(false);
                questions[qIndex].SetActive(false);
                qIndex += 1;
                Debug.Log(clicked);
                clicked = -1;
            }
            if (qIndex == d)
            {
                music.SetActive(true);
                // testing
                Debug.Log(player.courage);
                Debug.Log(player.strength);
                Debug.Log(player.reason);
                // making sure the player starts with at least 5 points each
                if (player.courage <= 0)
                {
                    player.courageChanger(5);
                }
                if (player.strength <= 0)
                {
                    player.strengthChanger(5);
                }
                if (player.reason <= 0)
                {
                    player.reasonChanger(5);
                }

                // setting the courage reactions
                if (player.courage >= 80)
                {
                    c.text = $"Wow, you must be so brave to score such a high score. your courage level was {player.courage}";
                }
                else if (player.courage >= 50)
                {
                    c.text = $"your courage level is...{player.courage}.\nwell, i didn't expect much from a human...good enough i guess";
                }
                else
                {
                    c.text = $"....won't it be easier for me to just kill you right now? why waste my time...ugh...\n" +
                        $"your courage level is {player.courage}...";
                }

                // setting the strength reactions
                if (player.strength >= 80)
                {
                    s.text = $"your strength level is {player.strength}!! that what i call a strong mind!! wow..you made me amazed, human...";
                }
                else if (player.strength >= 50)
                {
                    s.text = $"mhm...not too weak...i guess it is fine for a human. your strength level is...{player.strength}.";
                }
                else
                {
                    s.text = $"ugh...you must be kidding me...if i just appeared suddenly in front of you, you might start crying...\n" +
                        $"whatever...your strength level is {player.strength}";
                }
                // setting the reason reacitons
                if (player.reason >= 80)
                {
                    r.text = $"...well that is impressive. it will be hard to shake your steal mind. good job..\n" +
                        $"your reason level is {player.reason}";
                }
                else if (player.reason >= 50)
                {
                    r.text = $"your reason level is {player.reason}.\n" +
                        $"enough to not die fast i guess...";
                }
                else
                {
                    r.text = $"...how old are you again? you are not a kid, right? i might be a ghost but i don't wanna kids to play this game..." +
                        $"well..your reason level is {player.reason}";
                }
            }
        }
        else if (ddIndex < dd)
        {
            Debug.Log(ddIndex);
            Aron.SetActive(true);
            Kale.SetActive(true);

            if (ddIndex == 1)
            {
                if (player.courage >= 80)
                {
                    animator1.Play("NormalKale");
                    animator2.Play("NoTalkingNormalAron");
                }
                else if (player.courage >= 50)
                {
                    animator1.Play("NotHappyKale");
                    animator2.Play("NoTalkingNotAmusedAron");
                }
                else
                {
                    animator1.Play("CreepyKale");
                    animator2.Play("NotTalkingReallyAron");
                }
            }
            else if (ddIndex == 2)
            {
                if (player.strength >= 80)
                {
                    animator1.Play("NormalKale");
                    animator2.Play("NoTalkingNormalAron");
                }
                else if (player.strength >= 50)
                {
                    animator1.Play("NotHappyKale");
                    animator2.Play("NoTalkingNotAmusedAron");
                }
                else
                {
                    animator1.Play("CreepyKale");
                    animator2.Play("NotTalkingReallyAron");
                }
            }
            else if (ddIndex == 3)
            {
                if (player.reason >= 80)
                {
                    animator1.Play("NormalKale");
                    animator2.Play("NoTalkingNormalAron");
                }
                else if (player.reason >= 50)
                {
                    animator1.Play("NotHappyKale");
                    animator2.Play("NoTalkingNotAmusedAron");
                }
                else
                {
                    animator1.Play("CreepyKale");
                    animator2.Play("NotTalkingReallyAron");
                }
            }
            else if (ddIndex == 7)
            {
                animator1.Play("CreepyKale");
                animator2.Play("NotTalkingReallyAron");
            }
            else
            {
                animator1.Play("NormalKale");
                animator2.Play("NoTalkingNormalAron");
            }
           

            if (ddIndex == 7 && music.activeSelf == true) // no music for scary effect
            {
                music.SetActive(false);
            }
            else if (music.activeSelf == false)
            {
                music.SetActive(true);
            }

            if (!(dialogues2[ddIndex].activeSelf))
            {
                dialogues2[ddIndex].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogues2[ddIndex].SetActive(false);
                ddIndex += 1;
            }
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }

    public void getAnswer(int click)
    {
        clicked = click;
        switch (click)
        {
            case 1:
                player.courageChanger(10);
                player.strengthChanger(-5);
                player.reasonChanger(20);
                break;
            case 2:
                player.courageChanger(10);
                player.strengthChanger(20);
                player.reasonChanger(-5);
                break;
            case 3:
                player.courageChanger(20);
                player.strengthChanger(10);
                player.reasonChanger(-5);
                break;
            case 4:
                player.courageChanger(-5);
                player.strengthChanger(10);
                player.reasonChanger(20);
                break;
            case 5:
                player.courageChanger(20);
                player.strengthChanger(10);
                player.reasonChanger(-5);
                break;
            case 6:
                player.courageChanger(-5);
                player.strengthChanger(10);
                player.reasonChanger(20);
                break;
            case 7:
                player.courageChanger(10);
                player.strengthChanger(20);
                player.reasonChanger(-5);
                break;
            case 8:
                player.courageChanger(10);
                player.strengthChanger(-5);
                player.reasonChanger(20);
                break;
            case 9:
                player.courageChanger(-5);
                player.strengthChanger(20);
                player.reasonChanger(10);
                break;
            case 10:
                player.courageChanger(-5);
                player.strengthChanger(10);
                player.reasonChanger(20);
                break;
            case 11:
                player.courageChanger(10);
                player.strengthChanger(20);
                player.reasonChanger(-5);
                break;
            case 12:
                player.courageChanger(20);
                player.strengthChanger(-5);
                player.reasonChanger(10);
                break;
            case 13:
                player.courageChanger(10);
                player.strengthChanger(-5);
                player.reasonChanger(20);
                break;
            case 14:
                player.courageChanger(20);
                player.strengthChanger(10);
                player.reasonChanger(-5);
                break;
            case 15:
                player.courageChanger(10);
                player.strengthChanger(20);
                player.reasonChanger(-5);
                break;
            case 16:
                player.courageChanger(-5);
                player.strengthChanger(10);
                player.reasonChanger(20);
                break;
            case 17:
                player.courageChanger(-5);
                player.strengthChanger(10);
                player.reasonChanger(20);
                break;
            case 18:
                player.courageChanger(20);
                player.strengthChanger(10);
                player.reasonChanger(-5);
                break;
            case 19:
                player.courageChanger(-5);
                player.strengthChanger(20);
                player.reasonChanger(10);
                break;
            case 20:
                player.courageChanger(10);
                player.strengthChanger(-5);
                player.reasonChanger(20);
                break;
        }
    }
}
