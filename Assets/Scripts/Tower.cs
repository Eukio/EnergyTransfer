using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    bool alive;
    [SerializeField] Game game;

    Energy[] blocks = new Energy[4];
    SpriteRenderer sp;
    [SerializeField] Sprite[] spriteArray;
  [SerializeField] int poleNumber;


    void Start()
    {
       sp  = gameObject.GetComponent<SpriteRenderer>();
        sp.sprite = spriteArray[0];
    }

    // Update is called once per frame
    void Update()
    {
       
    }
 
 
    public void OnMouseDown()
    {if(game.Alive())
        game.Click(poleNumber);
    }
    public Energy[] GetEnergies()
    {
        return blocks;
    }
    public void SetGraphicOn()
    {
            sp.sprite = spriteArray[1];
    }
    public void SetGraphicOff()
    {
         sp.sprite = spriteArray[0];
    }
    public void SetGraphicDead()
    {
        sp.sprite = spriteArray[2];
    }

}

