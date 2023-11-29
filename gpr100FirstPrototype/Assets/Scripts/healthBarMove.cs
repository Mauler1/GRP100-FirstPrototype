using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarMove : MonoBehaviour
{
    public Image healthBar;
    public float healthAdjust = 10f;
    public PlayerHealth takeHealth;
    private float tempHealth;
    public float startHealth = 10f;
    // Start is called before the first frame update
    void Start()
    {
        tempHealth = takeHealth.getHealth();
    }

    // Update is called once per frame
    void Update()
    {
        tempHealth = takeHealth.getHealth();
        if(tempHealth < startHealth)
        {
            tempHealth = tempHealth / healthAdjust;
            healthBar.fillAmount = tempHealth;
        }

    }
}
