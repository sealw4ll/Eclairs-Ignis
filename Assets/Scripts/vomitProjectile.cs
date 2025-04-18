using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class vomitProjectile : MonoBehaviour
{
    public List<GameObject> bullets;
    public GameObject bullet;
    public Transform bulletPos;
    public Transform centerPos;
    public Transform rotation;
    public Animator anim;

    public bool started = false;

    private float timer;
    public float cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = cooldown;
    }

    public void StartGun()
    {
        if (!started)
        {
            started = true;
        }
    }

    public void removeBullets()
    {
        foreach (GameObject bullet in bullets)
        {
            if (bullet != null)
            {
                Destroy(bullet);
            }
        }
        bullets.Clear();
    }

    public void StopGun()
    {
        if (started)
        {
            started = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!started) return;

        if (timer > cooldown)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        SceneController.instance.AudioManager.PlaySFX(SceneController.instance.AudioManager.enemy_shot);
        anim.Play("slime_attack");
        GameObject bulletChild = Instantiate(bullet, bulletPos.position, rotation.rotation);
        bullets.Add(bulletChild);
        bulletBehavior bulletBehavior = bulletChild.GetComponent<bulletBehavior>();
        bulletBehavior.setDirection(bulletPos.position - centerPos.position);

        StartCoroutine(PlayIdleAfterDelay(0.3f));
    }

    private IEnumerator PlayIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.Play("slime_idle");
    }
}