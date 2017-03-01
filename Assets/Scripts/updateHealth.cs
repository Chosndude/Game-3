using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class updateHealth : MonoBehaviour {

    float ratio = 0f;
    float hitPoint = 100;
    float maxHitPoint = 100;
    public Image healthBar;
    public Text healthText = null;
    float timer;
    bool hit;

    void Start()
    {
        healthText.color = Color.white;
    }
	void Update () {
        timer += Time.deltaTime;
        if (hit)
        {
            if(timer > 5f)
            {
                timer = 0f;
                hit = false;
            }
        }
        if(timer>2 && hitPoint < maxHitPoint && !hit)
        {
            hitPoint += 10;
            timer = 0f;
            if (hitPoint > maxHitPoint)
                hitPoint = maxHitPoint;
        }
        updateHealthBar();
        if(hitPoint <= 0)
        {
            SceneManager.LoadScene(3);
        }
            
	}

    public void takeDamage(int damage)
    {
        hitPoint -= damage;
        hit = true;
        timer = 0f;
    }

    void updateHealthBar()
    {
        ratio = hitPoint / maxHitPoint;
        healthBar.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
        healthText.text = "" + hitPoint;
    }
}
