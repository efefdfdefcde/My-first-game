using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShopNextSceneButton : MonoBehaviour
    {
        private AudioSource _source => GetComponent<AudioSource>();

        public static Action _buttonClickedIvent;

        public void NextSceneSignalise()
        {
            _source.Play();
            _buttonClickedIvent.Invoke();
        }

       
    }
}