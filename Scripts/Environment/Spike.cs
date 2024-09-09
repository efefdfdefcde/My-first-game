using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spike : Trap
    {


        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            Kill(collision.collider);
        }
    }
}