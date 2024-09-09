using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class LoadAnimation : MonoBehaviour
    {
        public delegate void LoadAnimationDelegate();
        public event LoadAnimationDelegate _loadEvent;
        public event LoadAnimationDelegate _loadFromShop;
      


        [SerializeField] private Animator animator;

        private void OnEnable()
        {
           
            Start_Menu_Buttons.load_event += LoadAnimate;
            Finish_Level.finish_level_event += LoadAnimate;
            ShopNextSceneButton._buttonClickedIvent += LoadFromShop;

        }

        private void LoadAnimate()
        {
            animator.Play("Load");
        }

        private void LoadSignalise()
        {
            _loadEvent.Invoke();
        }

        private void LoadFromShop()
        {
            animator.Play("Load_From_Shop");
        }

        private void LoadFromShopSignalise()
        {
            _loadFromShop.Invoke();
        }

      
        

        private void AnimationClear()
        {
            animator.Play("Empty");
        }

        private void OnDestroy()
        {
           
            Start_Menu_Buttons.load_event -= LoadAnimate;
            Finish_Level.finish_level_event -= LoadAnimate;
            ShopNextSceneButton._buttonClickedIvent -= LoadFromShop;
        }

    }
}