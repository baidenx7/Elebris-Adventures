﻿using Assets.Scripts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Actions.Attacks
{
    [Serializable]
    public class ActiveAction : MonoBehaviour
    {
        private Rigidbody2D actionRB;
        private CircleCollider2D actionCollider;
        private Unit parentPlayer;
        private Vector2 directionUsed; //if the skill travels at all
        private float durationDone;//til it needs to destroy itself
        private float travelSpeed;

        //private Element elementType;
        //private float elementDamage;
        private float actionDamage;

        public ActiveAction()
        {

        }

        public void Initialize(Unit owner, float travelSpeed, Vector2 directionUsed, float duration, int chargeLevel)
        {
            actionRB = GetComponent<Rigidbody2D>();
            actionCollider = transform.GetComponent<CircleCollider2D>();
            parentPlayer = owner;
            durationDone = duration;
            this.directionUsed = directionUsed;

            for (int i = 0; i < chargeLevel; i++)
            {
                //this is a hack job, radius is only one of many possible effects available to you.
                //should pass in a "chargeTrigger" that can take a list of modifiers from the player/skill as parameters.
                IncreaseRadius();
            }
            durationDone = Time.time + .3f;
        }

        private void FixedUpdate()
        {
            transform.Translate(directionUsed * Time.fixedDeltaTime * travelSpeed);
            if (Time.time >= durationDone)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log($"You hit {col.name}");
            //if (col.tag == "Enemy")
            //{
            //    Character c = col.GetComponentInParent<Character>();
            //    c.TakeDamage(physDamage, source);
            //}
        }

        public void IncreaseRadius()
        {
            actionCollider.transform.localScale *= 1.3f;// Was .radius, wouldn't have affected visual, amy revert if I set up different animations
        }


    }
}