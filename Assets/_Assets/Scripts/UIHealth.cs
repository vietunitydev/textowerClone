using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIHealth : MonoBehaviour
{
    public int currenHealth;
    public int MaxHealth;

    public Image[] fullHearts;
    public Image[] emptyHearts;

    private void Start()
    {
        MaxHealth = 6;
        currenHealth = 3;
    }
    public void UpdateHealth()
    {
        for(int i = 0; i < fullHearts.Length; i++)
        {
            if(i<currenHealth)
            {
                fullHearts[i].enabled = true;
                emptyHearts[i].enabled = false;
            }
            else
            {
                fullHearts[i].enabled = false;
                emptyHearts[i].enabled = true;
            }
            
        }
    }

    // tru di mot trai tim khi match sai
    public void SetHealth(int damage)
    {
        if(currenHealth < 6)
        {
            currenHealth += damage;
        }

    }

}
