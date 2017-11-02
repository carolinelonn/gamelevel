using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour
{
    public static int scene_Load = 1;
    private Text _textComponent;
    public List<string> DialogueStrings = new List<string>();

    public float SecondsBetweenCharacters = 0.01f;
    public float CharacterRateMultiplier = 0.25f;

    public KeyCode DialogueInput = KeyCode.Return;

    private bool _isStringBeingRevealed = false;
    private bool _isDialoguePlaying = false;
    private bool _isEndOfDialogue = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;

    public string sceneName;

	// Use this for initialization
	void Start ()
	{
        sceneDialogueSelect();
	    _textComponent = GetComponent<Text>();
	    _textComponent.text = "";

        HideIcons();
	}
	
	// Update is called once per frame
	void Update () 
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        if (!_isDialoguePlaying)
	        {
                _isDialoguePlaying = true;
                StartCoroutine(StartDialogue());
            
            }
           
	    }
	}

    private void sceneDialogueSelect() {
        switch (scene_Load) {
            case 1:
                DialogueStrings.Clear();
                DialogueStrings.Add("YOU: What… what happened?...Where am I?");
                DialogueStrings.Add("GOD: You died, of course.");
                DialogueStrings.Add("YOU: There was a-a-a... a truck and I was skidding");
                DialogueStrings.Add("GOD: Yup. And now you're here");
                DialogueStrings.Add("YOU: I-I died?!");
                DialogueStrings.Add("GOD: Yea, but don't feel bad about it. Everybody dies");
                DialogueStrings.Add("YOU: Sooo...  What is this place? Who are you?... What now?");
                DialogueStrings.Add("GOD: This is Hea-");
                DialogueStrings.Add("YOU: Is my family alright?!");
                DialogueStrings.Add("GOD: This is what I like to see. Don't worry, they are good");
                DialogueStrings.Add("GOD: Don't worry, they will remember you as a good man");
                DialogueStrings.Add("YOU: So this is heaven, huh, what now?");
                DialogueStrings.Add("GOD: Well, you see you will be reincarnated");
                DialogueStrings.Add("YOU: So the Hindus were right?");
                DialogueStrings.Add("GOD: Nope, nobody was right.");
                DialogueStrings.Add("YOU: Soooo.. what is the point? I will just be a baby again, with no memories");
                DialogueStrings.Add("GOD: Nope. You have within you all the knowledge and experience from your past lives");
                DialogueStrings.Add("YOU: But I don't remember anything from before I was a kid");
                DialogueStrings.Add("GOD: You will. You just didn't stretch out yet. You are imense, trust me!");
                DialogueStrings.Add("YOU: Then, what is the point of this... cycle?");
                DialogueStrings.Add("GOD: You will become me. You need to aquire knowledge. You'll need to die lots of times");
                DialogueStrings.Add("YOU: Wait.. what? I don't wan't to die aga-");
                DialogueStrings.Add("GOD: Too late kiddo, talk later");
                break;
            case 2:
                DialogueStrings.Clear();
                DialogueStrings.Add("GOD: Welcome back! How is it?");
                DialogueStrings.Add("YOU: HORRIBLE!!! THE PAIN!!!");
                DialogueStrings.Add("god: now now, you'll get used to it");
                DialogueStrings.Add("you: I need answers. Why do I need to die?");
                DialogueStrings.Add("god: because it's funny");
                DialogueStrings.Add("you: no, it's not, why do I need to die?");
                break;
            case 3:
                DialogueStrings.Clear();
                DialogueStrings.Add("YOU: Listen here you monster");
                DialogueStrings.Add("GOD: That is no way to talk to yourself");
                DialogueStrings.Add("YOU: What?");
                DialogueStrings.Add("GOD: Ooopes... yeah, about that... we are kinda the same");
                DialogueStrings.Add("You: ...Oh... what does that mean");
                DialogueStrings.Add("GOD: Why do you think I want you to aquire knowledge?");
                DialogueStrings.Add("GOD: People... anything learns from mistakes. You learn from your mistakes");
                DialogueStrings.Add("YOu: Soooo....");
                DialogueStrings.Add("God: Knowledge is power. You need to become powerful. You are literarly a universe of consciesness");
                DialogueStrings.Add("GOD: You are a god... (harry)");
                DialogueStrings.Add("You: So I am learning to replace you? Are you dying? Is darkness attacking?!");
                DialogueStrings.Add("GOD: No, I am bored. Tired. I want to start annew. A new universe. But I can't leave");
                DialogueStrings.Add("You: So I am your replacement? Because you're bored? Can't I make another universe?");
                DialogueStrings.Add("God: No. You are this universe. You are everybody.");
                break;
            case 4:
                DialogueStrings.Clear();
                DialogueStrings.Add("God: That was a classic. You should do that again");
                DialogueStrings.Add("You: No. It wasn't. Trust me. It hurts... Anyways... how am I everybody?");
                DialogueStrings.Add("God: Think about it. I made you. And only you. Then I just recursively called your class");
                DialogueStrings.Add("You: What? A little confusing...");
                DialogueStrings.Add("GOD: No, think about it. Every gesture of kindness you made, you made it for yourself");
                DialogueStrings.Add("GOD: Everytime you helped, you helped yourself. You learned from yourself. From billlions of you");
                DialogueStrings.Add("You: So... Am I a god?");
                DialogueStrings.Add("God: No. You need to grow. You are just an... egg");
                DialogueStrings.Add("You: An egg?");
                DialogueStrings.Add("God: Yes. A universe. An egg. Infinites of you, growing building on itself. An unhatched egg");
                DialogueStrings.Add("God: Go now. Move to the next life");
                break;
            case 7:
                DialogueStrings.Clear();
                DialogueStrings.Add("GOD: Don't give up! Just learn their patterns. You are here to learn");
                DialogueStrings.Add("YOU: How did I get to be such an alchoolic?");
                DialogueStrings.Add("GOD: Students can't be alchoolics. It's in the dictionary.");
                break;
            case 5:
                DialogueStrings.Clear();
                DialogueStrings.Add("god: Ummmmmm. Do you really need a tip for this?");
                DialogueStrings.Add("you: Well, you should give me tips in this scene");
                DialogueStrings.Add("god: Sure... just... ummm, guillotines kill");
                break;
            case 6:
                DialogueStrings.Clear();
                DialogueStrings.Add("god: You pick stuff up from walking on it");
                DialogueStrings.Add("you: Strange, isn't it? Do I even have hands? How do I use stuff?");
                DialogueStrings.Add("god: Don't use your hands. Use your mind!");
                DialogueStrings.Add("you: That doesn't make sense. Maybe I should just find a way to cut that wire");
                DialogueStrings.Add("you: I also know that I am alergic to bees");
                break;
            case 8:
                DialogueStrings.Clear();
                DialogueStrings.Add("You: Well. When do I... hatch?");
                DialogueStrings.Add("god: Technically there was supposed to be another. But we don't have that becaues of... reasons");
                DialogueStrings.Add("You: So, I won't be able to be come a god without that level?");
                DialogueStrings.Add("god: Nah. I am a merciful god... you can just win. Close enough!");
                break;
        }
    }

    private IEnumerator StartDialogue()
    {
        int dialogueLength = DialogueStrings.Count;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed)
        {
            if (!_isStringBeingRevealed)
            {
                _isStringBeingRevealed = true;
                StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLength)
                {
                    _isEndOfDialogue = true;
                  

                }
            }

            yield return 0;
        }

        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
            }

            yield return 0;
        }

        HideIcons();
        _isEndOfDialogue = false;
        _isDialoguePlaying = false;
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        HideIcons();

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters*CharacterRateMultiplier);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
            else
            {
                break;
            }
        }

        ShowIcon();

        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
            }

            yield return 0;
        }

        HideIcons();

        _isStringBeingRevealed = false;
        _textComponent.text = "";
    }

    private void HideIcons()
    {
        ContinueIcon.SetActive(true);
        StopIcon.SetActive(false);
    }

    private void ShowIcon()
    {
        ContinueIcon.SetActive(true);
        if (_isEndOfDialogue)
        {
            StopIcon.SetActive(true);
            ContinueIcon.SetActive(false);
            return;
        }
    }
}
