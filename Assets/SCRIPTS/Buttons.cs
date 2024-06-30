using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button buttonCastle, buttonWoman, buttonSoap,buttonBattle;
    public Sprite spriteCastleGreen, spriteWomanGreen, spriteSoapGreen,
        spriteCastleRed, spriteWomanRed, spriteSoapRed;
    public Image imageCastle, imageWoman, imageSoap;
    public static bool flag_castle, flag_woman, flag_soap,flag_battle;

    void Update()
    {
        buttonCastle.onClick.AddListener(ButtonCastle);
        buttonSoap.onClick.AddListener(ButtonSoap);
        buttonWoman.onClick.AddListener(ButtonWoman);
        buttonBattle.onClick.AddListener(Battle);
    }

    void ButtonCastle()
    {
        imageCastle.sprite = spriteCastleGreen;
        imageWoman.sprite = spriteWomanRed;
        imageSoap.sprite = spriteSoapRed;
        flag_castle = true;
        flag_soap = false;
        flag_woman = false;
    }

    void ButtonSoap()
    {
        imageCastle.sprite = spriteCastleRed;
        imageWoman.sprite = spriteWomanRed;
        imageSoap.sprite = spriteSoapGreen;
        flag_castle = false;
        flag_soap = true;
        flag_woman = false;
    }

    void ButtonWoman()
    {
        imageCastle.sprite = spriteCastleRed;
        imageWoman.sprite = spriteWomanGreen;
        imageSoap.sprite = spriteSoapRed;
        flag_castle = false;
        flag_soap = false;
        flag_woman = true;
    }

    void Battle()
    {
        flag_battle = true;
    }
}
