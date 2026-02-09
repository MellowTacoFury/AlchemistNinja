using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<Item_SO> potion = new();//for displaying 
    public GameManager gm;
    public int maxBadIngredients = 5;
    public int maxOverfillIngredients = 15;
    private float wrongIngredients = 0;
    private float overFilledIngredients = 0;
    public int potionSize = 5;


    [SerializeField] private List<Item_SO> current = new();//for the backend

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        potion = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().MakeRecipe(potionSize);
        current = new List<Item_SO>(potion);
    }
    void OnTriggerEnter(Collider other)
    {
        Item_SO item = other.gameObject.GetComponent<Item>().item;
        if(item != null)//first check if its a valid item
        {
            if(item.ItemType == 3)
            {
                //do powerup
            }
            else
            {
                CheckPotion(item);
            }
            
        }
        
    }
    private void CheckPotion(Item_SO item)
    {
        //Checking
        if(current.Contains(item))
        {
            gm.CrossOutPanel(item);
            current.Remove(item);
        }
        else
        {
            if(item.ItemType == 1)
            {
                overFilledIngredients++;
            }
            else
            {
                wrongIngredients++;
            }
        }


        //End states
        if(wrongIngredients >= maxBadIngredients)
        {
            gm.GameOver(3);
        }

        if(overFilledIngredients >= maxOverfillIngredients)
        {
            gm.GameOver(2);
        }

        if(current.Count == 0)
        {
            gm.GameOver(1, (int)(wrongIngredients+overFilledIngredients));
        }
    }
}
