using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10;
    public sceneChange playerDeath;
    public TextMeshProUGUI healthNum;
    public GameObject cam;
    private Vector3 camRot = new Vector3(0, 0, 1.5f);
    private Vector3 camRot2 = new Vector3(0, 0, -1.5f);

    // Start is called before the first frame update, not anymore

    void Update(){

        if(health <= 0){
            playerDeath.SwitchScene();
        }
        healthNum.text = "Health: " + health.ToString();

    }
    public IEnumerator camRotDel()
    {
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        //rotate back
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot2);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);
        cam.transform.Rotate(camRot);
        yield return new WaitForSeconds(0.025f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       AiHealthAndDamage enemy = collision.GetComponent<AiHealthAndDamage>();
       if(enemy != null){
            health -= 1;
            StartCoroutine(camRotDel());
            Destroy(enemy.gameObject);
       }
        bossHealth boss = collision.GetComponent<bossHealth>();
        if (boss != null)
        {
            health -= 1;
        }
        ShieldHpAndDamage shield = collision.GetComponent<ShieldHpAndDamage>();
        if (shield != null)
        {
            health -= 1;
        }

    }
    public float getHealth()
    {
           return health;
    }
    public void takeHit(int damage)
    {
        health -= damage;
    }
}
