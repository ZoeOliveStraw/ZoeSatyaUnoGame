using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<string> cards = new List<string>();
    private string[] suits = {"R", "G", "B", "Y"};
    private string[] ranks = {"1","2","3","4","5","6","7","8","9","S","R","T"};
    private Controls _controls;

    private void Awake()
    {
        _controls = new Controls();
        _controls.Debug.DeckNewCard.performed += ctx => ShowRandomCard();
    }

    private void Start()
    {
        Initialize();
        Debug.Log(ToString());
    }
    public void Initialize()
    {
        foreach (string s in suits)
        {
            cards.Add($"{s}0");
            foreach (string r in ranks)
            {
                cards.Add(s + r);
            }
        }
        for (int i = 0; i < 4; i++)
        {
            cards.Add("CC");
            cards.Add("A4");
        }
    }
    public void Shuffle()
    {
        
    }
    
    //This function is largely for debugging purposes, making sure that
    //selecting a random card works
    private void ShowRandomCard()
    {
        string randomCard = cards[UnityEngine.Random.Range(0,cards.Count)];
        GetComponent<SpriteRenderer>().sprite = GetCardSprite(randomCard);
    }
    
    public override string ToString()
    {
        string output = "";
        foreach (string card in cards)
        {
            output += $"{card},";
        }
        return output;
    }

    public static Sprite GetCardSprite(string cardName)
    {
        string cardPath =$"Cards/{cardName}";
        return Resources.Load<Sprite>(cardPath);
    }
    private void OnEnable()
    {
        _controls.Enable();
    }
    private void OnDisable()
    {
        _controls.Disable();
    }
}
