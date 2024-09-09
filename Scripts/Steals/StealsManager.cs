using Assets.NewScripts.Steals;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.NewScripts.FSM.Player.Helpers
{
    public class StealsManager : MonoBehaviour
    {
        private bool _inHide;
        private bool _isHide;
        private Renderer _renderer;

        public static Action<bool> _inHideAction;

        private void Start()
        {
            StealsZone._inHideAction += HideChange;
            ControlKeys._hideAction += Hide;
            _renderer = GetComponent<Renderer>();
            StealsZone._outHideAction += HideOut;
        }

        private void HideChange(bool hide)
        {
            _inHide = hide;
        }

        private void Hide()
        {
            if (_inHide && !_isHide)
            {
                _isHide = true;
                gameObject.layer = 11;
                _renderer.sortingOrder = 12;
                _inHideAction(true);
            }else if (_inHide && _isHide)
            {
                _isHide = false;
                gameObject.layer = 7;
                _renderer.sortingOrder = 22;
                _inHideAction(false);
            }


        }

        private void HideOut()
        {
            _isHide = false;
            gameObject.layer = 7;
            _renderer.sortingOrder = 22;
            _inHideAction(false);
        }

        private void OnDestroy()
        {
            StealsZone._outHideAction -= HideOut;
            StealsZone._inHideAction -= HideChange;
            ControlKeys._hideAction -= Hide;
        }

    }
}