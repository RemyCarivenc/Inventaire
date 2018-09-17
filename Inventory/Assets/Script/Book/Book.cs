using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour {
    public Animator animBook;

    public GameObject pageDroite;
    public GameObject pageGauche;

    public GameObject interR;
    public GameObject interL;
    public Animator animInter;

    private bool grip = false;
    private Sprite spriteCard;

    private int nbCard = 0;
    private int nbPage = 0;

    public GameObject Drag;
    
    private GameManager gm;

    private Sprite[] currentAllSprites;
    private void Awake()
    {
        interL.SetActive(false);
        interR.SetActive(false);
    }
    // Use this for initialization
    void Start () {
        gm = GameManager.Instance;
        
        /**_ Recover all Sprite on folder Resources _**/
        gm.Empty = Resources.Load<Sprite>("Sprites/Empty");
        gm.WeaponS = Resources.LoadAll<Sprite>("Sprites/Weapon");
        gm.ArmorS = Resources.LoadAll<Sprite>("Sprites/Armor");
        gm.UtilS = Resources.LoadAll<Sprite>("Sprites/Util");
        gm.SpellsS = Resources.LoadAll<Sprite>("Sprites/Spells");
        gm.QuestS = Resources.LoadAll<Sprite>("Sprites/Quest");
        gm.UniqueS = Resources.LoadAll<Sprite>("Sprites/Unique");

        /**_ Sorting Sprites _**/
        IComparer myComparer = new myReverserClass();
        Array.Sort(gm.WeaponS, myComparer);
        Array.Sort(gm.ArmorS, myComparer);
        Array.Sort(gm.UtilS, myComparer);
        Array.Sort(gm.SpellsS, myComparer);
        Array.Sort(gm.QuestS, myComparer);
        Array.Sort(gm.UniqueS, myComparer);


        /**_ Add all Sprite sorted on gm.AllSprite _**/
        for (int i = 0; i < gm.ArmorS.Length; i++)
            gm.AllSprite.Add(gm.ArmorS[i]);
        for (int i = 0; i < gm.WeaponS.Length; i++)
            gm.AllSprite.Add(gm.WeaponS[i]);
        for (int i = 0; i < gm.UtilS.Length; i++)
            gm.AllSprite.Add(gm.UtilS[i]);
        for (int i = 0; i < gm.SpellsS.Length; i++)
            gm.AllSprite.Add(gm.SpellsS[i]);
        for (int i = 0; i < gm.QuestS.Length; i++)
            gm.AllSprite.Add(gm.QuestS[i]);
        for (int i = 0; i < gm.UniqueS.Length; i++)
            gm.AllSprite.Add(gm.UniqueS[i]);

        currentAllSprites = new Sprite[gm.AllSprite.Count];
        for (int i = 0; i < gm.AllSprite.Count; i++)
            currentAllSprites[i] = gm.AllSprite[i];

        SpriteRenderer sprite;
        for (int i=0; i<6; i++)
        {
            sprite = pageGauche.transform.GetChild(0).GetChild(i).transform.GetComponent<SpriteRenderer>();
            if (nbCard > currentAllSprites.Length - 1)
                sprite.sprite = gm.Empty;
            else
                sprite.sprite = currentAllSprites[nbCard];
            nbCard++;
        }
        for (int i = 0; i < 6; i++)
        {
            sprite = pageDroite.transform.GetChild(0).GetChild(i).transform.GetComponent<SpriteRenderer>();
            if (nbCard > currentAllSprites.Length - 1)
                sprite.sprite = gm.Empty;
            else
                sprite.sprite = currentAllSprites[nbCard];
            nbCard++;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (gm.OpenBook)
        {
            Debug.Log("PAGE" + nbPage);
            Debug.Log("Card " +nbCard);
            ChangePageNP();
            DragMove();
            ChangePageTabs();
        }
	}

    public void EndAnimationOpen()
    {
        StartCoroutine(Wait2Frames());
    }

    /// <summary>
    /// Drag Card on actionbar with Physics Raycast
    /// </summary>
    public void DragMove()
    {
        Image image;
        image = Drag.GetComponent<Image>();
        Drag.transform.position = Input.mousePosition;

        Color c = image.color;
        if (!grip && Input.GetMouseButtonDown(0))
        {
           
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Card")
                {
                    c.a = 255.0f;
                    image.color = c;
                    spriteCard = hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite;
                    image.sprite = spriteCard;
                    grip = true;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) && grip)
        {
            c.a = 0f;
            image.color = c;
            grip = false;
        }
            
    }

    /// <summary>
    /// Change page with left mouse button of Next and Previous object 
    /// </summary>
    public void ChangePageNP()
    {
        if (Input.GetMouseButtonUp(0) && !gm.WaitEndAnim)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Next")
                {
                    switch(gm.TypeCard)
                    {
                        case GameManager.CARD.Armor:
                            ChangeSpriteInterPage(gm.ArmorS, true, false);
                            break;
                        case GameManager.CARD.Quest:
                            ChangeSpriteInterPage(gm.QuestS, true, false);
                            break;
                        case GameManager.CARD.Spell:
                            ChangeSpriteInterPage(gm.SpellsS, true, false);
                            break;
                        case GameManager.CARD.Unique:
                            ChangeSpriteInterPage(gm.UniqueS, true, false);
                            break;
                        case GameManager.CARD.Utility:
                            ChangeSpriteInterPage(gm.UtilS, true, false);
                            break;
                        case GameManager.CARD.Weapon:
                            ChangeSpriteInterPage(gm.WeaponS, true, false);
                            break;
                        case GameManager.CARD.All:
                            ChangeSpriteInterPage(currentAllSprites, true, false);
                            break;
                    }
                }
                else if (hit.collider.gameObject.name == "Previous")
                {
                    switch (gm.TypeCard)
                    {
                        case GameManager.CARD.Armor:
                            ChangeSpriteInterPage(gm.ArmorS, false, false);
                            break;
                        case GameManager.CARD.Quest:
                            ChangeSpriteInterPage(gm.QuestS, false, false);
                            break;
                        case GameManager.CARD.Spell:
                            ChangeSpriteInterPage(gm.SpellsS, false, false);
                            break;
                        case GameManager.CARD.Unique:
                            ChangeSpriteInterPage(gm.UniqueS, false, false);
                            break;
                        case GameManager.CARD.Utility:
                            ChangeSpriteInterPage(gm.UtilS, false, false);
                            break;
                        case GameManager.CARD.Weapon:
                            ChangeSpriteInterPage(gm.WeaponS, false, false);
                            break;
                        case GameManager.CARD.All:
                            ChangeSpriteInterPage(currentAllSprites, false, false);
                            break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Change page according to Typecard Tabs
    /// </summary>
    public void ChangePageTabs()
    {
        if(gm.OnClickedTabs && gm.ChangePageTabs)
        {
            nbCard = 0;
            switch(gm.TypeCard )
            {
                case GameManager.CARD.Armor:
                    ChangeSpriteInterPage(gm.ArmorS, true, true);
                    break;
                case GameManager.CARD.Quest:
                    ChangeSpriteInterPage(gm.QuestS, true, true);
                    break;
                case GameManager.CARD.Spell:
                    ChangeSpriteInterPage(gm.SpellsS, true, true);
                    break;
                case GameManager.CARD.Unique:
                    ChangeSpriteInterPage(gm.UniqueS, true, true);
                    break;
                case GameManager.CARD.Utility:
                    ChangeSpriteInterPage(gm.UtilS, true, true);
                    break;
                case GameManager.CARD.Weapon:
                    ChangeSpriteInterPage(gm.WeaponS, true, true);
                    break;
                case GameManager.CARD.All:
                    ChangeSpriteInterPage(currentAllSprites, true, true);
                    break;
            }
            gm.ChangePageTabs = false;
        }
    }

    IEnumerator Wait2Frames()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        transform.GetComponent<Animator>().enabled = false;
        gm.OpenBook = true;
    }

    /// <summary>
    /// Change sprite on the interPage
    /// </summary>
    /// <param name="_sprite"> Type array Sprite used </param>
    /// <param name ="turnPage"> True = next, False = previous </param>
    /// <param name ="isStartPage"> True : nbPage = 0, False: nbPage++ </param>
    public void ChangeSpriteInterPage(Sprite[] _sprite, bool turnPage, bool isStartPage)
    {
        if (turnPage)
        {
            gm.WaitEndAnim = true;
            interR.SetActive(true);
            SpriteRenderer spriteR;

            for (int i = 0; i < 6; i++)
            {
                spriteR = pageDroite.transform.GetChild(1).GetChild(i).transform.GetComponent<SpriteRenderer>();
                if (nbCard > _sprite.Length - 1)
                    spriteR.sprite = gm.Empty;
                else
                    spriteR.sprite = _sprite[nbCard];
                nbCard++;
            }
            for(int j =0; j<6; j++)
            {
                for(int i =0; i<2; i++)
                {
                    spriteR = interR.transform.GetChild(i).GetChild(j).GetComponent<SpriteRenderer>();
                    spriteR.sprite = pageDroite.transform.GetChild(i).GetChild(j).GetComponent<SpriteRenderer>().sprite;
                   
                }
                spriteR = pageDroite.transform.GetChild(0).GetChild(j).transform.GetComponent<SpriteRenderer>();
                if (nbCard > _sprite.Length - 1)
                    spriteR.sprite = gm.Empty;
                else
                    spriteR.sprite = _sprite[nbCard];
                nbCard++;
            }
            if (!isStartPage)
                nbPage+=2;
            else
                nbPage = 0;
            animInter.SetTrigger("Next");
            
        }
        else
        {
            if (nbPage <= 0)
                Debug.Log("Début");
            else
            {
                gm.WaitEndAnim = true;
                interL.SetActive(true);
                SpriteRenderer spriteL;
                
                if (!isStartPage)
                    nbPage -=2;
                else
                    nbPage = 0;
                int currentNbCard = nbPage*6;
                nbCard = (nbPage+1) * 6;
                for (int i = 0; i < 6; i++)
                {
                    spriteL = pageGauche.transform.GetChild(1).GetChild(i).transform.GetComponent<SpriteRenderer>();
                    if (nbCard > _sprite.Length - 1)
                        spriteL.sprite = gm.Empty;
                    else
                        spriteL.sprite = _sprite[nbCard];
                    nbCard++;

                }
                for (int j = 0; j < 6; j++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        spriteL = interL.transform.GetChild(i).GetChild(j).GetComponent<SpriteRenderer>();
                        spriteL.sprite = pageGauche.transform.GetChild(i).GetChild(j).GetComponent<SpriteRenderer>().sprite;
                    }
                    spriteL = pageGauche.transform.GetChild(0).GetChild(j).transform.GetComponent<SpriteRenderer>();
                    if (currentNbCard > _sprite.Length - 1)
                        spriteL.sprite = gm.Empty;
                    else
                        spriteL.sprite = _sprite[currentNbCard];
                    currentNbCard++;
                }
                animInter.SetTrigger("Previous");
            }
        }
    }
}

public class myReverserClass : IComparer
{

    // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
    int IComparer.Compare(object x, object y)
    {
        return ((new CaseInsensitiveComparer()).Compare(((Sprite)x).name, ((Sprite)y).name));
    }
}
