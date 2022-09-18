using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheoryButton : MonoBehaviour
{
	public GameObject cam;
	public float speed;
	public int num,i;
	public TheoryButton[] neighbours;
    public Color active;
	public Color passive;
	public Color white;
	public SpriteRenderer block;
	public TextMesh txt;
	public bool used;
	
	void FixedUpdate(){
		int l = neighbours.Length;
		if(used){
			if(cam.transform.position.y < -10*num){
				cam.transform.position = new Vector3(0,cam.transform.position.y + speed*Time.fixedDeltaTime,-10);
			}
			if(cam.transform.position.y > -10*num){
				cam.transform.position = new Vector3(0,cam.transform.position.y - speed*Time.fixedDeltaTime,-10);
			}
		}
		if(i < l && i != -1 && i != num){
			neighbours[i].used = false;
			neighbours[i].block.color = passive;
			neighbours[i].txt.color = white;
			i += 1;
		} 
		else if(i == num){
			i += 1;
		}
		else { i = -1; }
	}
    void OnMouseEnter()
    {
		if(!used){
			block.color = white;
			txt.color = passive;
		}   
    }
	void OnMouseExit()
	{
		if(!used){
		block.color = passive;
		txt.color = white;
		}
	}
	void OnMouseDown(){
		if(!used){
			block.color = active;
			txt.color = white;
			i = 0;
			used = true;
		}
	}
}
