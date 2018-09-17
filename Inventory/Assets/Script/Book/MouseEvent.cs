using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour {

    private string nameOb;
    private Animator anim;
    private GameManager gm;
    public void Start()
    {
        gm = GameManager.Instance;
        nameOb = transform.name;
        anim = transform.GetComponent<Animator>();
    }

    public void OnMouseExit()
    {
        anim.SetBool("OnGameObject", false);
    }
    public void OnMouseOver()
    {
        anim.SetBool("OnGameObject", true);
    }

    public void OnMouseDown()
    {

        if (!gm.OnClickedTabs)
        {
            gm.OnClickedTabs = true;
            gm.ChangePageTabs = true;
            for (int i = 0; i < gm.Selected.Length; i++)
            {
                if (gm.Selected[i])
                {
                    gm.Selected[i] = false;
                }
            }
            if (!anim.GetBool("OnClick"))
            {

                anim.SetBool("OnClick", true);
                switch (nameOb)
                {
                    case "MPArmor":
                        gm.Selected[0] = true;
                        gm.TypeCard = GameManager.CARD.Armor;
                        break;
                    case "MPWeapon":
                        gm.Selected[1] = true;
                        gm.TypeCard = GameManager.CARD.Weapon;
                        break;
                    case "MPUtil":
                        gm.Selected[2] = true;
                        gm.TypeCard = GameManager.CARD.Utility;
                        break;
                    case "MPSpells":
                        gm.Selected[3] = true;
                        gm.TypeCard = GameManager.CARD.Spell;
                        break;
                    case "MPQuest":
                        gm.Selected[4] = true;
                        gm.TypeCard = GameManager.CARD.Quest;
                        break;
                    case "MPUnique":
                        gm.Selected[5] = true;
                        gm.TypeCard = GameManager.CARD.Unique;
                        break;
                }
            }
            else
            {
                anim.SetBool("OnClick", false);
                gm.TypeCard = GameManager.CARD.All;
            }
        }
    }

    public void Update()
    {
        switch (nameOb)
        {
            case "MPArmor":
                if(!gm.Selected[0])
                    anim.SetBool("OnClick", false);
                break;
            case "MPWeapon":
                if (!gm.Selected[1])
                    anim.SetBool("OnClick", false);
                break;
            case "MPUtil":
                if (!gm.Selected[2])
                    anim.SetBool("OnClick", false);
                break;
            case "MPSpells":
                if (!gm.Selected[3])
                    anim.SetBool("OnClick", false);
                break;
            case "MPQuest":
                if (!gm.Selected[4])
                    anim.SetBool("OnClick", false);
                break;
            case "MPUnique":
                if (!gm.Selected[5])
                    anim.SetBool("OnClick", false);
                break;
        }

    }
}
