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
    public float wrongIngredients = 0;
    public float overFilledIngredients = 0;
    public int potionSize = 5;
    private AudioSource audioSource;
    public EndingController EC;
    public List<AudioClip> clips;


    [SerializeField] private List<Item_SO> current = new();//for the backend

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        potion = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().MakeRecipe(potionSize, false);
        current = new List<Item_SO>(potion);
        audioSource = GetComponent<AudioSource>();
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
                other.gameObject.GetComponent<Collider>().enabled = false;
                Destroy(other.gameObject, 1);
            }
            audioSource.Play();
            
        }
        
    }
    private void CheckPotion(Item_SO item)
    {
        //Checking
        EC.CheckPotion(item);
        if(current.Contains(item))
        {
            gm.CrossOutPanel(item);
            current.Remove(item);
        }
        else
        {
            if(item.ItemType == 1 || item.ItemType == 3)
            {
                overFilledIngredients++;
                GameObject.Find("Canvas").GetComponent<GameUI>().UpdateOverfillSlider();
            }
            else
            {
                wrongIngredients++;
                GameObject.Find("Canvas").GetComponent<GameUI>().UpdateBadSlider();
            }
        }


        //End states
        if(wrongIngredients >= maxBadIngredients)
        {
            gm.GameOver(3);
            audioSource.Stop();
            audioSource.volume = .4f;
            audioSource.PlayOneShot(clips[1]);
        }

        if(overFilledIngredients >= maxOverfillIngredients)
        {
            gm.GameOver(2);
            audioSource.Stop();
            audioSource.volume = .4f;
            audioSource.PlayOneShot(clips[1]);
        }

        if(current.Count == 0)
        {
            gm.GameOver(1, (int)(wrongIngredients+overFilledIngredients));
            audioSource.Stop();
            audioSource.volume = .6f;
            audioSource.PlayOneShot(clips[0]);
        }
    }
}
