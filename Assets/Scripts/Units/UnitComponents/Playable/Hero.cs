using Assets.DapperEvents.GameEvents;
using UnityEngine;

namespace Assets.Scripts.Units
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Hero : Entity
    {

        [SerializeField] private ActiveHeroEvent activeHeroEvent = null;
        //we have the option of changing player scale to -1 when moving left and  1 when moving right in order to have a "player side" sprite transform.localScale
        //rather than a left and right, that can be reused. I'm not currently going this route because I want left and right assets to be more than just mirror copies of eachother

        //add a "run" function similar to charging where as long as your moving you start to fill a hidden bar, when it fills you boost your movespeed by 1.25

        //Right now ResourceBarValues are overkill.

        protected override void Start()
        {
            base.Start();
            HeroUnitSelected(); //select this unit on start
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        protected override void Update()
        {
            base.Update();
        }

        private void HeroUnitSelected()
        {
            //targetselectedevent on todo list
            activeHeroEvent.Raise(this);
        }
    }

}