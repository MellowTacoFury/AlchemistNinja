using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Item_SO> AllItems;
    public List<GameObject> AllPrefabItems;
    public GameObject ingredientPanelPrefab;
    public GameObject ingredientList;
    private List<GameObject> panels = new();
    public GameUI gameUI;
    public bool GameDone = false;

    public List<Item_SO> MakeRecipe(int recipeSize, bool forOmni=false)
    {
        //take the good items and return a list of x amount
        List<Item_SO> goodItems = new();

        foreach (var item in AllItems)
        {
            if(item.ItemType == 1)
            {
                goodItems.Add(item);
            }
        }

        List<Item_SO> potion= new();
        for (int i = 0; i < recipeSize; i++)
        {
            int r;
            r = Random.Range(0, goodItems.Count);
            potion.Add(goodItems[r]);
            if(forOmni == false)
                AddIngredientToUI(goodItems[r]);
        }
        return potion;

    }

    public void AddIngredientToUI(Item_SO item)
    {
        GameObject panel = Instantiate(ingredientPanelPrefab);
        panel.transform.SetParent(ingredientList.gameObject.transform);
        panel.name = item.ItemName;
        panel.GetComponent<Image>().sprite = item.image;
        panel.GetComponent<Item>().item = item;
        panels.Add(panel);
    }

    public void CrossOutPanel(Item_SO item)
    {
        foreach (var obj in panels)
        {
            if(obj.GetComponent<Item>().item == item)
            {
                if(obj.transform.GetChild(0).GetComponent<Image>().enabled == true)
                {
                    //if its already true, so keep looking
                }
                else
                {
                    obj.transform.GetChild(0).GetComponent<Image>().enabled = true;
                    return;
                }
            }
        }
    }


    /// <summary>
    /// 1 for win, 2 for overfill, 3 for bad objects
    /// </summary>
    public void GameOver(int ending, int wrongIngredients=-1)
    {
        gameUI.GO(ending, wrongIngredients);
        GameDone = true;

    }


}
