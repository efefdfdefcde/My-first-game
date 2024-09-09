using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bosses.Boss2
{
    public class Boss2Audio : BossAudio
    {
        [SerializeField] private AudioClip _spiritSpawn, _changePosition;

        public void Spirit()
        {
            _source.PlayOneShot(_spiritSpawn);
        }

        public void ChangePosition()
        {
            _source.PlayOneShot(_changePosition);
        }
      
    }
}