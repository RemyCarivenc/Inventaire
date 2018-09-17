using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterAnim : MonoBehaviour {

    public GameObject pageGauche;
    public GameObject interR;
    public GameObject pageDroite;
    public GameObject interL;

    public void InitPageL()
    {
        
        for (int j = 0; j < 6; j++)
        {
            SpriteRenderer spriteL;
            spriteL = pageGauche.transform.GetChild(0).GetChild(j).GetComponent<SpriteRenderer>();
            spriteL.sprite = interR.transform.GetChild(1).GetChild(j).GetComponent<SpriteRenderer>().sprite;

            spriteL = pageGauche.transform.GetChild(1).GetChild(j).GetComponent<SpriteRenderer>();
            spriteL.sprite = interR.transform.GetChild(0).GetChild(j).GetComponent<SpriteRenderer>().sprite;

        }
       // transform.GetChild(0).gameObject.SetActive(false);
        
    }
    public void InitPageR()
    {
        
        for (int j = 0; j < 6; j++)
        {
            SpriteRenderer spriteR;
            spriteR = pageDroite.transform.GetChild(0).GetChild(j).GetComponent<SpriteRenderer>();
            spriteR.sprite = interL.transform.GetChild(1).GetChild(j).GetComponent<SpriteRenderer>().sprite;
            

        }
       // transform.GetChild(1).gameObject.SetActive(false);
    }

    public void Desactive(int index)
    {

        GameManager.Instance.OnClickedTabs = false;
        transform.GetChild(index).gameObject.SetActive(false);
        GameManager.Instance.WaitEndAnim = false;
    }
}
