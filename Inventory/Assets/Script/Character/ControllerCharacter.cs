using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharacter : MonoBehaviour {

    public GameObject book;

    private void Awake()
    {
        Cursor.visible = false;
        book.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I) && !GameManager.Instance.OpenBook)
        {
            book.SetActive(true);
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && GameManager.Instance.OpenBook)
        {
            book.SetActive(false);
            book.transform.GetComponent<Animator>().enabled = true;
            GameManager.Instance.OpenBook = false;
            Cursor.visible = false;
        }
       


    }

    
}
