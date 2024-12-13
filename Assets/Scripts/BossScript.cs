using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class BossScript : MonoBehaviour
{
    public int health;

    [SerializeField] Slider bossSlider;
    [SerializeField] GameObject destroySFX;
    [SerializeField] private AudioSource destroySound;
    [SerializeField] string SceneName;
    public UnityEvent OnBossDead;

    float posx = -0.5f;
    float posy = -0.5f;
    private void Start()
    {
        if(bossSlider)
            bossSlider.maxValue = health;
        if (health == 0)
        {
            StartCoroutine("TriggerExplosion");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball_parried"))
        {
            OnDamaged(1);
            if (health <= 0)
                TriggerDeath();
                
        }
    }

    private void FixedUpdate()
    {
        if(bossSlider)
            bossSlider.value = health;

    }
    private void OnDamaged(int damage)
    {
        health -= damage;
    }

    void TriggerDeath()
    {
        OnBossDead.Invoke();

        Time.timeScale = 0f;
        StartCoroutine(WaitForBossDeath());
    }

    IEnumerator WaitForBossDeath()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneName);
    }

    IEnumerator TriggerExplosion()
    {
        Instantiate(destroySFX, transform.position + new Vector3(posx, posy, transform.position.z + 1), Quaternion.identity);

        GameObject tempAudioObject = new GameObject("TempAudio");
        AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();
        tempAudioSource.clip = destroySound.clip;
        tempAudioSource.volume = destroySound.volume;
        tempAudioSource.pitch = destroySound.pitch;
        tempAudioSource.Play();
        yield return new WaitForSeconds(0.5f);

        if (posx == 0.5f)
            posy *= -1f;
        posx *= -1f;
        yield return TriggerExplosion();
    }

    public void TriggerDestroy()
    {
        Destroy(gameObject);
    }
}