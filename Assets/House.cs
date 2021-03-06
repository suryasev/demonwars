﻿using UnityEngine;
using System.Collections;

public class House : Obstacle {
	public float sorrow = 1f;
	public float sorrowgen = 0f;
	public float maxSorrowStorage = 10f;
	public float sorrowgenratechange = .000001f;
	public float maxSorrowGen = .1f;
	public SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		ownable = true;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = this.RandomSprite();
		///


	}
	
	// Update is called once per frame
	void Update () {

		sorrowgen += sorrowgenratechange;
		sorrowgen = Mathf.Min (sorrowgen, maxSorrowGen);
		sorrow += sorrowgen;
		sorrow = Mathf.Min (sorrow, maxSorrowStorage);

		if (owner != null){
			owner.sorrow += sorrow;
			sorrow = 0f;
	
		}
	}

	public void TakeOwnership(Player newowner) {
		if (ownable) {
			this.owner = newowner;
			spriteRenderer.color = newowner.PlayerColor;
			print (this.tag);
			
		}
	}

	void OnTriggerEnter2D(Collider2D otherObj) {
		//Debug.Log (otherObj);
		if (otherObj.gameObject.tag == "Minion") {
			Minion minion = otherObj.gameObject.GetComponent<Minion>();
			minion.state = Minion.State.Wander;
			if(this.owner != minion.owner){
				this.TakeOwnership(minion.owner);
				//Debug.Log("Home Owner!");
				//spriteRenderer.color = new Color(1f, 0f, 1f, 1f);
			}
			//float lerp = Mathf.PingPong(Time.time, duration) / duration;
			//spr.color = 
			//this.material.color = Color.Lerp(otherObj.GetComponent<Renderer>().material.color, Color.red, lerp);
			//Debug.Log("owner of house is " + owner);
		}
	}

	Sprite RandomSprite(){
		Sprite[] Houses = Resources.LoadAll<Sprite>("Houses");
		int choice = Random.Range (0, Houses.Length);
		return Houses [choice];
	}

//	void OnCollisionEnter(Collision otherObj) {
//		print ("Collision with a house!");
//		if (otherObj.gameObject.tag == "Minion") {
//			Minion minion = otherObj.gameObject.GetComponent<Minion>();
//			this.TakeOwnership(minion.owner);
//		}
//	}
}
