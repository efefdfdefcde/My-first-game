using UnityEngine;

namespace Assets.NewScripts.Data.ArcherData
{
    public class ArcherData : EnemyData
    {
        [SerializeField] private GameObject _arrowPrefab;
      

        public GameObject GetArrovPrefab()
        {
            return _arrowPrefab;
        }
    }
}