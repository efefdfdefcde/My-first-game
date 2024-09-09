using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class Wind : Arrow
    {
      
        
        
        protected override void Start()
        {
            
        }

        protected override void Fly()
        {
            Vector3 direction = new Vector3(-transform.localScale.x, 0);
            transform.position += direction * _speed * Time.deltaTime;
        }
    }
}