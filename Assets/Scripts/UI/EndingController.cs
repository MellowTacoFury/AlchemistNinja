using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    public List<Item_SO> oPotion;
    public Sprite good;
    public Sprite bad;
    public Image potionImage;
    Collector collector;
    [Header("Stuff to turn off")]
    public List<GameObject> permenentTurnOffs;
    public List<GameObject> goodTurnOns;
    public List<GameObject> badTurnOns;
    public Image endBackground;
    public GameObject hider;
    private Animation anim;



    void Start()
    {
        anim = GetComponent<Animation>();
        collector = GameObject.Find("Pot").GetComponent<Collector>();
        oPotion = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().MakeRecipe(collector.potionSize, true);
    }

    public void CheckPotion(Item_SO item)
    {
        if(oPotion.Contains(item))
        {
            oPotion.Remove(item);
        }
    }
    public void DoEnd()
    {
        GameObject.Find("Spawner").GetComponent<Spawner>().OnDisable();
        endBackground.enabled = true;
        potionImage.gameObject.SetActive(true);
        hider.SetActive(true);
        Time.timeScale = 1;
        foreach (var item in permenentTurnOffs)
        {
            item.SetActive(false);
        }

        if(oPotion.Count == 0)
        {
            //do win
            potionImage.sprite = good;
            PlayAndDoSomethingAfter(goodTurnOns);
        }
        else
        {
            //do loose
            potionImage.sprite = bad;
            PlayAndDoSomethingAfter(badTurnOns);
        }
    }
    public void PlayAndDoSomethingAfter(List<GameObject> l)
    {
        StartCoroutine(PlayAnimationAndContinue(l));
    }
    IEnumerator PlayAnimationAndContinue(List<GameObject> l)
    {
        anim.Play();

        // Wait until the animation is finished
        while (anim.isPlaying)
        {
            yield return null; // Yield control back to Unity for one frame
        }

        foreach (var item in l)
        {
            item.SetActive(true);
        }
    }
}
