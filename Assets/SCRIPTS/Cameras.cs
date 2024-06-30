using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cameras : MonoBehaviour
{
    public GameObject character,character_castle,character_woman,character_soap;
    public CanvasGroup canvasGroup,canvasGroupBattle,canvasGroupButtons;
    public CinemachineVirtualCamera virtualSoap, virtualWoman, virtualHuge, virtualSwitch,virtualBattle;
    public Canvas canvas;
    public GameObject healthBar, attackBar, speedBar, buttonStart, buttonCastle, buttonSoap, buttonWoman;
    private bool flag_canvas, flag_soap, flag_woman, flag_huge,flag_canvas_battle = false,flag_canvasgroup = false;

    private void Start()
    {
        canvasGroupBattle.alpha = 0;
        canvasGroup.alpha = 0;

        virtualBattle.Priority = 0;
        virtualSwitch.Priority = 10;
        virtualSoap.Priority = 5;
        virtualWoman.Priority = 5;
        virtualHuge.Priority = 5;
    }

    void Update()
    {

        if ((flag_soap || flag_woman || flag_huge) && !flag_canvas)
        {
            virtualSwitch.Priority = 4;
            canvasGroup.alpha += Time.deltaTime;
            if (canvasGroup.alpha == 1)
            {
                flag_canvas = true;
            }
        }

        if (Buttons.flag_battle && !flag_canvas_battle)
        {
            if (canvasGroupBattle.alpha < 1 && !flag_canvasgroup)
            {
                canvasGroupBattle.alpha += Time.deltaTime;
                canvasGroup.alpha -= Time.deltaTime*10;
                canvasGroupButtons.alpha -= Time.deltaTime*10;
                //canvasGroup.alpha = 0;
                //canvasGroupButtons.alpha = 0;

            } else if (canvasGroupBattle.alpha == 1 || flag_canvasgroup)
            {
                flag_canvasgroup = true;
                if (canvasGroupBattle.alpha == 1)
                {
                    Invoke("Black", 1.4f);
                } else
                {
                    Black();
                }
                healthBar.SetActive(false);
                attackBar.SetActive(false);
                speedBar.SetActive(false);
                buttonStart.SetActive(false);
                buttonCastle.SetActive(false);
                buttonSoap.SetActive(false);
                buttonWoman.SetActive(false);
                if (canvasGroupBattle.alpha == 0)
                {
                    flag_canvas_battle = true;
                }
                
            }
        }

        if (flag_canvasgroup)
        {
            virtualBattle.Priority = 10;
            virtualHuge.Priority = 5;
            virtualSoap.Priority = 5;
            virtualSwitch.Priority = 5;
            virtualWoman.Priority = 5;
            if (Buttons.flag_soap)
            {
                ChooseCharacter(character_soap);
            } else if (Buttons.flag_castle)
            {
                ChooseCharacter(character_castle);
            } else if (Buttons.flag_woman)
            {
                ChooseCharacter(character_woman);
            }

        }

        if (Buttons.flag_soap)
        {
            virtualSoap.Priority = 10;
            virtualWoman.Priority = 5;
            virtualHuge.Priority = 5;
            flag_soap = true;

        }
        else if (Buttons.flag_castle)
        {
            virtualSoap.Priority = 5;
            virtualWoman.Priority = 5;
            virtualHuge.Priority = 10;
            flag_huge = true;
        }
        else if (Buttons.flag_woman)
        {
            virtualSoap.Priority = 5;
            virtualWoman.Priority = 10;
            virtualHuge.Priority = 5;
            flag_woman = true;
        }

    }

    void Black()
    {
        canvasGroupBattle.alpha -= Time.deltaTime / 7;
        if (canvasGroupBattle.alpha == 0)
        {
            flag_canvas_battle = true;
        }
    }

    void ChooseCharacter(GameObject obj)
    {
        obj.transform.position = character.transform.position;
        obj.transform.rotation = character.transform.rotation;
        obj.transform.localScale = new Vector3(44.5f,44.5f,44.5f);
    }
}
