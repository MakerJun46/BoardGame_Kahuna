using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
   public static CardManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] CardSO cardSO;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] List<Card> myCards;
    [SerializeField] List<Card> opponentCards;

    List<CardInfo> itemBuffer;

    private void Start()
    {
        SetupItemBuffer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            AddCard(true);

        if (Input.GetKeyDown(KeyCode.S))
            AddCard(false);
    }

    void AddCard(bool isMine)
    {
        var cardObject = Instantiate(cardPrefab, new Vector3(0, 10, 0), Quaternion.Euler(90, 0, 0));
        var cardInfo = cardObject.GetComponent<Card>();
        cardInfo.Setup(DrawCard(), isMine);
        (isMine ? myCards : opponentCards).Add(cardInfo);
    }

    public CardInfo DrawCard()
    {
        if (itemBuffer.Count == 0)
        {
            Debug.Log("NO Card");
            return null;
        }

        CardInfo item = itemBuffer[0];
        itemBuffer.RemoveAt(0);
        Debug.Log(item);
        return item;
    }

    void SetupItemBuffer()
    {
        itemBuffer = new List<CardInfo>();

        for(int i = 0; i < cardSO.cards.Length; i++)
        {
            CardInfo item = cardSO.cards[i];

            item.islandObject = GameObject.Find(item.islandName).GetComponent<Island>();

            for(int j = 0; j < item.Count; j++)
            {
                itemBuffer.Add(item);
            }
        }

        for(int i = 0; i < itemBuffer.Count; i++) // shuffle items
        {
            int rand = Random.Range(i, itemBuffer.Count);
            CardInfo temp = itemBuffer[i];
            itemBuffer[i] = itemBuffer[rand];
            itemBuffer[rand] = temp;
        }
    }

}
