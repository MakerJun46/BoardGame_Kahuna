using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer card;
    [SerializeField] Sprite cardBack;

    public CardInfo item;
    bool isFront;

    public void Setup(CardInfo item, bool isFront)
    {
        this.item = item;
        this.isFront = isFront;

        if(this.isFront)
        {
            card.sprite = item.islandImg;
        }
        else
        {
            card.sprite = cardBack;
        }
    }

}
