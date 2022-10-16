using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassmateLogic : MonoBehaviour
{

    public GameObject shineSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("Player is hovering");
        shineSprite.SetActive(true);
    }

    private void OnMouseExit()
    {
        Debug.Log("Player has left");
        shineSprite.SetActive(false);
    }
}

