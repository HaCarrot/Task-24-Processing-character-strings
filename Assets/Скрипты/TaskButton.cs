using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskButton : MonoBehaviour
{
    public int num;
	public TaskOne scr;
	public SpriteRenderer block;
	public SpriteRenderer img;
	public Color button;
	public Color active;
	public Color passive;
	
    void OnMouseDown()
    {
		block.color = active;
		img.color = passive;
		scr.len = num;
    }
	void OnMouseEnter()
    {
        block.color = active;
		img.color = passive;
    }
	void OnMouseExit()
	{
		block.color = button;
		img.color = active;
	}
}
