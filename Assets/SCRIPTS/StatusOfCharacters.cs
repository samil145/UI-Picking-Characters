using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusOfCharacters : MonoBehaviour
{
    public TMP_Text text_health, text_attack, text_speed;
    public Slider slider_health,slider_attack,slider_speed;
    public Image fill_health , fill_attack,fill_speed;
    public float currentVelocity = 0 , currentVelocityy = 0 , currentVelocity_ = 0;

    private int health_castle = 100, health_woman = 70, health_soap = 85;
    private int attack_castle = 100, attack_woman = 80, attack_soap = 92;
    private int speed_castle = 63, speed_woman = 100, speed_soap = 70;

    private void Start()
    {
        slider_health.maxValue = 100;
        slider_health.value = 100;

        slider_attack.maxValue = 100;
        slider_attack.value = 100;

        slider_speed.maxValue = 100;
        slider_speed.value = 100;
    }

    void Update()
    {
        if (Buttons.flag_soap)
        {
            SetHealth(health_soap);
            SetAttack(attack_soap);
            SetSpeed(speed_soap);
        } else if (Buttons.flag_castle)
        {
            SetHealth(health_castle);
            SetAttack(attack_castle);
            SetSpeed(speed_castle);
        } else if (Buttons.flag_woman)
        {
            SetHealth(health_woman);
            SetAttack(attack_woman);
            SetSpeed(speed_woman);
        }
    }

    public void SetHealth(int health)
    {
        text_health.text = "" + health;
        slider_health.value = Mathf.SmoothDamp(slider_health.value, health, ref currentVelocity, 0.5f);
        if(Mathf.Abs(slider_health.value - health) < 0.5f)
        {
            slider_health.value = health;
        }
    }

    public void SetAttack(int attack)
    {
        text_attack.text = "" + attack;
        slider_attack.value = Mathf.SmoothDamp(slider_attack.value, attack, ref currentVelocityy, 0.5f);
        if (Mathf.Abs(slider_attack.value - attack) < 0.5f)
        {
            slider_attack.value = attack;
        }
    }

    public void SetSpeed(int speed)
    {
        text_speed.text = "" + speed;
        slider_speed.value = Mathf.SmoothDamp(slider_speed.value, speed, ref currentVelocity_, 0.5f);
        if (Mathf.Abs(slider_speed.value - speed) < 0.5f)
        {
            slider_speed.value = speed;
        }
    }
}
