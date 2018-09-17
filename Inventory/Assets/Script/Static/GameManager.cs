using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance = null;
    public enum CARD {All, Armor, Weapon, Utility, Spell, Unique, Quest }
    private CARD typeCard = CARD.All;

    private bool openBook = false;
    private bool waitEndAnim = false;
    private List<Sprite> allSprite = new List<Sprite>();
    private Sprite[] weaponS;
    private Sprite[] utilS;
    private Sprite[] spellsS;
    private Sprite[] questS;
    private Sprite[] uniqueS;
    private Sprite[] armorS;
    private Sprite empty;

    private bool[] selected = new bool[6]{false, false, false, false, false, false};
    private bool onClickedTabs = false;
    private bool changePageTabs = false;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }
    public CARD TypeCard
    {
        get
        {
            return typeCard;
        }
        set
        {
            typeCard = value;
        }
    }

    public bool OpenBook
    {
        get
        {
            return openBook;
        }

        set
        {
            openBook = value;
        }
    }

    public bool WaitEndAnim
    {
        get
        {
            return waitEndAnim;
        }

        set
        {
            waitEndAnim = value;
        }
    }

    public bool[] Selected
    {
        get
        {
            return selected;
        }

        set
        {
            selected = value;
        }
    }

    public bool OnClickedTabs
    {
        get
        {
            return onClickedTabs;
        }

        set
        {
            onClickedTabs = value;
        }
    }

   
    public List<Sprite> AllSprite
    {
        get
        {
            return allSprite;
        }

        set
        {
            allSprite = value;
        }
    }

    public Sprite[] WeaponS
    {
        get
        {
            return weaponS;
        }

        set
        {
            weaponS = value;
        }
    }

    public Sprite[] UtilS
    {
        get
        {
            return utilS;
        }

        set
        {
            utilS = value;
        }
    }

    public Sprite[] SpellsS
    {
        get
        {
            return spellsS;
        }

        set
        {
            spellsS = value;
        }
    }

    public Sprite[] QuestS
    {
        get
        {
            return questS;
        }

        set
        {
            questS = value;
        }
    }

    public Sprite[] UniqueS
    {
        get
        {
            return uniqueS;
        }

        set
        {
            uniqueS = value;
        }
    }

    public Sprite[] ArmorS
    {
        get
        {
            return armorS;
        }

        set
        {
            armorS = value;
        }
    }

    public Sprite Empty
    {
        get
        {
            return empty;
        }

        set
        {
            empty = value;
        }
    }

    public bool ChangePageTabs
    {
        get
        {
            return changePageTabs;
        }

        set
        {
            changePageTabs = value;
        }
    }
}
