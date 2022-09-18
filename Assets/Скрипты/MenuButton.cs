using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	public bool t,i;
    public TextMesh txt;
	public SpriteRenderer block;
	public SpriteRenderer img;
	public Color button;
	public Color active;
	public Color passive;
	public string scenename;
	
    void OnMouseEnter()
    {
        block.color = active;
		if(t){txt.color = passive;}
		if(i){img.color = passive;}
    }
	void OnMouseExit()
	{
		block.color = button;
		if(t){txt.color = active;}
		if(i){img.color = active;}
	}
	void OnMouseDown(){
		block.color = active;
		if(t){txt.color = active;}
		if(i){img.color = active;}
		SceneManager.LoadScene(scenename);
	}
}
