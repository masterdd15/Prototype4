using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassmateLogic : MonoBehaviour
{
    //Shiny background
    [SerializeField] private GameObject shineSprite;

    //Sprites used for when hand is raised or not
    [SerializeField] private Sprite angryHandImage;
    [SerializeField] private Sprite angryFaceImage;

    //The classmate Sprite Holder
    [SerializeField] private SpriteRenderer cmSpriteHolder;

    public List<AudioClip> audioList;

    private AudioSource myAudio;

    //This bool will help us make sure our hand is raised
    public bool handRaised = false;

    //We will generate a random number to wait for a hand raise
    private float timer = -1;

    private void Awake()
    {
        shineSprite = transform.Find("Shine_Sprite").gameObject;
        myAudio = GetComponent<AudioSource>();
        cmSpriteHolder = transform.Find("SpriteHolder").GetComponent<SpriteRenderer>();

        audioList = new List<AudioClip>(Resources.LoadAll<AudioClip>("AngrySounds"));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!handRaised && (timer == -1)) //We need to set our hand
        {
            Debug.Log("Resetting the timer and hand");
            timer = Random.Range(3f, 10f);
            StartCoroutine("TestHandRaise");
        }
        else //Waiting on hand
        {

        }
    }

    private void OnMouseEnter()
    {
        shineSprite.SetActive(true);
        //RaiseHand();
    }

    private void OnMouseExit()
    {
        shineSprite.SetActive(false);
        //cmSpriteHolder.sprite = angryFaceImage;
    }

    public void StartCritic()
    {
        StartCoroutine("AngryCritic");
    }

    IEnumerator AngryCritic()
    {
        LowerHand();
        int randomGen = Random.Range(0, audioList.Count - 1);
        myAudio.clip = audioList[randomGen];
        myAudio.Play();
        yield return new WaitForSeconds(myAudio.clip.length);
        handRaised = false;
    }

    public void RaiseHand()
    {
        cmSpriteHolder.sprite = angryHandImage;
    }

    public void LowerHand()
    {
        cmSpriteHolder.sprite = angryFaceImage;
    }

    IEnumerator TestHandRaise()
    {
        Debug.Log("HAND WILL GO UP");
        yield return new WaitForSeconds(timer);
        RaiseHand();
        handRaised = true;
        timer = -1;
        yield return null;
    }
}

