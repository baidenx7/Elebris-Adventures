﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour {

	private SpriteRenderer parentRenderer;

	private List<Obstacle> obstacles = new List<Obstacle> ();

	void Start ()
	{
		parentRenderer = transform.parent.GetComponent <SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.tag == "Obstacle")
		{
			Obstacle o = col.GetComponent<Obstacle> ();
			o.FadeOut ();

			if (obstacles.Count == 0 || o.MySpriteRenderer.sortingOrder -1 < parentRenderer.sortingOrder)
			{
				parentRenderer.sortingOrder = o.MySpriteRenderer.sortingOrder - 1;
		
			}
			obstacles.Add (o);

		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Obstacle")
		{
			Obstacle o = col.GetComponent<Obstacle> ();
			o.FadeIn ();
			obstacles.Remove (o);

			if (obstacles.Count == 0)
			{
				parentRenderer.sortingOrder = 200;
			}
			else
			{
				obstacles.Sort ();
				parentRenderer.sortingOrder = obstacles [0].MySpriteRenderer.sortingOrder - 1;
			}

		}


	}
}
