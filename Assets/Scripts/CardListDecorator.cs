using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardListDecorator : MonoBehaviour
{
    [Header("References")]
    public GameObject cardsBasePrefab;
    public Transform cardParent;
    //public JSONCardReader cardReader;
    
    [Header("Options")]
    [SerializeField] private float cardScale;
    [SerializeField] private int maxCardsPerPage;
    public CardFilterOptions filterOptions = new CardFilterOptions();
    public bool useMasterList = false;

    [Header("UI")]
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject nextButton;
    
    private List<CardDecorator> decorators = new List<CardDecorator>();
    private int currentPage = 0;
    
    public void Start()
    {
        RefreshCardList();
    }

    private List<CardInfo> currentList = new List<CardInfo>();
    private List<CardInfo> customList = new List<CardInfo>();

    [Button]
    private void RefreshCardList()
    {
        currentList = useMasterList ? JSONCardReader.MasterList : customList;
        currentList = CardListUtilities.FilterList(currentList, filterOptions);
        LoadCardList(currentList, 0);
    }

    public void ApplyCustomList(List<CardInfo> cardInfos)
    {
        customList.Clear();
        customList.AddRange(cardInfos);
        RefreshCardList();
    }

    public void LoadCardList(List<CardInfo> viewList, int page = 0)
    {
        currentList = viewList;
        currentPage = page;
        int count = 0;
        int startIndex = page * maxCardsPerPage;
        for (int i = startIndex; i < startIndex + maxCardsPerPage; i++)
        {
            CardInfo cardInfo = null;
            if (i < viewList.Count)
            {
                cardInfo = viewList[i];
            }
            
            if (cardInfo == null)
            {
                if (count < decorators.Count)
                {
                    decorators[count].gameObject.SetActive(false);
                }
            }
            else
            {
                if (count >= decorators.Count)
                {
                    CardDecorator decorator = Instantiate(cardsBasePrefab, cardParent).GetComponent<CardDecorator>();
                    decorator.LoadCardInfo(cardInfo);
                    decorator.transform.localScale = Vector3.one * cardScale;
                    decorators.Add(decorator);
                }
                else
                {
                    decorators[count].gameObject.SetActive(true);
                    decorators[count].LoadCardInfo(cardInfo);
                }
            }

            count++;
        }
        RefreshButtons();
    }

    private void RefreshButtons()
    {
        print("Current Page - " + currentPage + "\n" + "Page Count - " + PageCount);
        nextButton.SetActive(!AtLastPage);
        backButton.SetActive(currentPage > 0);
    }

    private int PageCount => currentList.Count / maxCardsPerPage;
    private bool AtLastPage => currentPage >= PageCount;
    public void NextPage()
    {
        if (currentPage >= PageCount) return;
        LoadCardList(currentList,currentPage + 1);
    }

    public void BackPage()
    {
        if (currentPage <= 0) return;
        LoadCardList(currentList,currentPage - 1);
    }

    public void AddRemoveOrderFilter(int order)
    {
        filterOptions.AddRemoveOrder((Orders)order);
        RefreshCardList();
    }
    
    public void AddRemoveTypeFilter(int type)
    {
        filterOptions.AddRemoveType((CardType)type);
        RefreshCardList();
    }
}
