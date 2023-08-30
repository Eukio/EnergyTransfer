using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int energyLevel;
    [SerializeField] float animationSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetEnergyLevel()
    {
        return energyLevel;
    }

}
