using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Tower t1;
    [SerializeField] Tower t2;
    [SerializeField] Tower t3;
    [SerializeField] Energy l1;
    [SerializeField] Energy l2;
    [SerializeField] Energy l3;
    [SerializeField] Energy l4;
    [SerializeField] Energy zapped;
    [SerializeField] Text message;
    [SerializeField] List<AudioClip> sounds;
    bool alive;
    bool overload;
    bool win;
    Tower movedTo = null;

    int selected;

    void Start()
    {
        message.text = "";
        t1.GetEnergies()[0] = l1;
        t1.GetEnergies()[1] = l2;
        t1.GetEnergies()[2] = l3;
        t1.GetEnergies()[3] = l4;
        zapped.GetComponent<Renderer>().enabled = false;
        alive = true;
        selected = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Win();


        if (Input.GetKeyUp(KeyCode.R) && (Win() || !alive))
        {
            Reset();
        }

       

    }
    public void Click(int pole)
    {
        if (selected == -1) // never selected
        {
            selected = pole;
            if (pole == 1)
            {
                t1.SetGraphicOn();


            }
            else if (pole == 2)
            {
                t2.SetGraphicOn();

            }
            else if (pole == 3)
            {
                t3.SetGraphicOn();

            }
        }
        else
        { int pos1 = -1;
            if (selected == 1 && pole == 2) // higher energy moved on lower then overload
            {
                if (GetLowestEnergy(t1) != null)
                { //check 1st tower
            pos1 = GetLowestEnergy(t1).GetEnergyLevel() -1; //lowest position
                    GetLowestEnergy(t1).transform.position = new Vector3(t2.transform.position.x, GetLowestEnergy(t1).transform.position.y, 0);
                    //  GetLowestEnergy(t1) get 2nd tower; to check overload
                    overload = Overload(t2, GetLowestEnergy(t1));
                    t2.GetEnergies()[pos1] = GetLowestEnergy(t1); // Swap
                    t1.GetEnergies()[pos1] = null; // null
                    Deselect();
                    movedTo = t2;
                    GetComponent<AudioSource>().PlayOneShot(sounds[0]);
                }

            }
            else if (selected == 1 && pole == 3)
            {
                if (GetLowestEnergy(t1) != null)
                { //check 1st tower
                    pos1 = GetLowestEnergy(t1).GetEnergyLevel() - 1; //lowest position
                    GetLowestEnergy(t1).transform.position = new Vector3(t3.transform.position.x, GetLowestEnergy(t1).transform.position.y, 0);
                    //  GetLowestEnergy(t1) get 2nd tower; to check overload
                    overload = Overload(t3, GetLowestEnergy(t1));
                    t3.GetEnergies()[pos1] = GetLowestEnergy(t1); // Swap
                    t1.GetEnergies()[pos1] = null; // null
                    GetComponent<AudioSource>().PlayOneShot(sounds[0]);
                    Deselect();
                    movedTo = t3;

                }
            }
            else if (selected == 2 && pole == 1)
            {
                if (GetLowestEnergy(t2) != null)
                { //check 1st tower
                    pos1 = GetLowestEnergy(t2).GetEnergyLevel() - 1; //lowest position
                    GetLowestEnergy(t2).transform.position = new Vector3(t1.transform.position.x, GetLowestEnergy(t2).transform.position.y, 0);
                    //  GetLowestEnergy(t1) get 2nd tower; to check overload
                    overload = Overload(t1, GetLowestEnergy(t2));
                    t1.GetEnergies()[pos1] = GetLowestEnergy(t2); // Swap
                    t2.GetEnergies()[pos1] = null; // null
                    GetComponent<AudioSource>().PlayOneShot(sounds[0]);
                    Deselect();
                    movedTo = t1;

                }
            }
            else if (selected == 2 && pole == 3)
            {

                if (GetLowestEnergy(t2) != null)
                { //check 1st tower
                    pos1 = GetLowestEnergy(t2).GetEnergyLevel() - 1; //lowest position
                    GetLowestEnergy(t2).transform.position = new Vector3(t3.transform.position.x, GetLowestEnergy(t2).transform.position.y, 0);
                    //  GetLowestEnergy(t1) get 2nd tower; to check overload
                    overload = Overload(t3, GetLowestEnergy(t2));
                    t3.GetEnergies()[pos1] = GetLowestEnergy(t2); // Swap
                    t2.GetEnergies()[pos1] = null; // null
                    GetComponent<AudioSource>().PlayOneShot(sounds[0]);
                    Deselect();
                    movedTo = t3;

                }
            }
            else if (selected == 3 && pole == 1)
            {
                if (GetLowestEnergy(t3) != null)
                { //check 1st tower
                    pos1 = GetLowestEnergy(t3).GetEnergyLevel() - 1; //lowest position
                    GetLowestEnergy(t3).transform.position = new Vector3(t1.transform.position.x, GetLowestEnergy(t3).transform.position.y, 0);
                    //  GetLowestEnergy(t1) get 2nd tower; to check overload
                    overload = Overload(t1, GetLowestEnergy(t3));
                    t1.GetEnergies()[pos1] = GetLowestEnergy(t3); // Swap
                    t3.GetEnergies()[pos1] = null; // null
                    GetComponent<AudioSource>().PlayOneShot(sounds[0]);
                    Deselect();
                    movedTo = t1;

                }
            }
            else if (selected == 3 && pole == 2)
            {
                if (GetLowestEnergy(t3) != null)
                { //check 1st tower
                    pos1 = GetLowestEnergy(t3).GetEnergyLevel() - 1; //lowest position
                    GetLowestEnergy(t3).transform.position = new Vector3(t2.transform.position.x, GetLowestEnergy(t3).transform.position.y, 0);
                    //  GetLowestEnergy(t1) get 2nd tower; to check overload
                    overload = Overload(t2, GetLowestEnergy(t3));
                    t2.GetEnergies()[pos1] = GetLowestEnergy(t3); // Swap
                    t3.GetEnergies()[pos1] = null; // null
                    GetComponent<AudioSource>().PlayOneShot(sounds[0]);
                    Deselect();
                    movedTo = t2;

                }
            }
            else if (selected == pole) { // when selected
               Deselect();
                movedTo = null;
            }

            if (overload)
            {

                alive = false;
                zapped.transform.position = new Vector3(movedTo.transform.position.x, zapped.transform.position.y, 0);
                zapped.GetComponent<Renderer>().enabled = true;
                message.text = "You Broke the Energy Machine, You Lose! Press R to Restart.";
                l1.GetComponent<Renderer>().enabled = false;
                l2.GetComponent<Renderer>().enabled = false;
                l3.GetComponent<Renderer>().enabled = false;
                l4.GetComponent<Renderer>().enabled = false;
                movedTo.SetGraphicDead();
                GetComponent<AudioSource>().PlayOneShot(sounds[1]);

            }
        }

    }
    public Energy GetLowestEnergy(Tower t)
    {

        Energy lowest = null;
        int temp = 5;
        for (int i = 0; i < t.GetEnergies().Length; i++)
        {
            if  (t.GetEnergies()[i] != null && temp > t.GetEnergies()[i].GetEnergyLevel()) { 
                lowest = t.GetEnergies()[i];
                temp = t.GetEnergies()[i].GetEnergyLevel();
            }
        }
        return lowest;
    }
    public void Deselect()
    {
        selected = -1;
        t1.SetGraphicOff();
        t2.SetGraphicOff();
        t3.SetGraphicOff();
    }
    public bool Overload(Tower t, Energy moved)
    {
        Debug.Log("moved: " + moved.GetEnergyLevel());
        if (GetLowestEnergy(t) != null && moved.GetEnergyLevel() > GetLowestEnergy(t).GetEnergyLevel())
        { 
            t.SetGraphicDead();
        return true;
    }
        else
        return false;
    }
    public bool Alive()
    {
        return alive;
    }
    public void Reset()
    {
        movedTo = null;
        zapped.GetComponent<Renderer>().enabled = false;

        l1.GetComponent<Renderer>().enabled = true;
        l2.GetComponent<Renderer>().enabled = true;
        l3.GetComponent<Renderer>().enabled = true;
        l4.GetComponent<Renderer>().enabled = true;
        message.text = "";
        t1.GetEnergies()[0] = l1;
        t1.GetEnergies()[1] = l2;
        t1.GetEnergies()[2] = l3;
        t1.GetEnergies()[3] = l4;

        l1.transform.position = new Vector3(t1.transform.position.x, l1.transform.position.y,0);
        l2.transform.position = new Vector3(t1.transform.position.x, l2.transform.position.y, 0);
        l3.transform.position = new Vector3(t1.transform.position.x, l3.transform.position.y, 0);
        l4.transform.position = new Vector3(t1.transform.position.x, l4.transform.position.y, 0);

        alive = true;
        Deselect();
        for (int i = 0; i < t2.GetEnergies().Length; i++)
        {
            t2.GetEnergies()[i] = null;
        }
       
 for(int i = 0; i < t3.GetEnergies().Length; i++)
        {
            t3.GetEnergies()[i] = null;
        }    
    
 overload = false;
    }
    public bool Win()
    {
        if (t3.GetEnergies()[0] == l1 && t3.GetEnergies()[1] == l2 && t3.GetEnergies()[2] == l3 && t3.GetEnergies()[3] == l4) {
            message.text = "You Win! Press R to Restart.";
            alive = false;

            return true; }
        else
        return false;
    }


    
}



