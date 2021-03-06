﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class updateHealth : MonoBehaviour {

    float ratio = 0f;
    float hitPoint = 100;
    float maxHitPoint = 100;
    public Image healthBar = null;
    public Image outline = null;
    public Text healthText = null;
    public Text healthTextOptional = null;
    bool hit;

    void Start()
    {
        healthText.color = Color.white;
    }
	void Update () {
        updateHealthBar();
        if(hitPoint <= 0)
        {
            //nextRound
        }
            
	}

    public void takeDamage(int damage)
    {
        if (hitPoint > 0)
        {
            hitPoint -= damage;
            hit = true;
        }
        print(hitPoint);
    }

    void updateHealthBar()
    {
        ratio = hitPoint / maxHitPoint;
        healthBar.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
        outline.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
        healthText.text = "" + hitPoint;
        healthTextOptional.text = "" + hitPoint;
    }
}
