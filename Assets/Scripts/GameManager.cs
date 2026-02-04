using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Item_SO> AllItems;

    public List<Item_SO> MakeRecipe(int recipeSize)
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
            // if(potion.Contains(goodItems[r]))
            // {
            //     //dont add a duplicate item
            //     i--;
            // }
            // else
            // {
                potion.Add(goodItems[r]);
            // }
        }
        return potion;

    }
}
