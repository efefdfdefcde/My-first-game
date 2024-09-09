using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Parallax_Effect : MonoBehaviour
    {
        private Transform camera_transform;
        [SerializeField,Range(0,1f)] float parallax_strenght;
        private Vector3 previous_position;
        void Start()
        {
            camera_transform = Camera.main.transform;
            previous_position = camera_transform.position;
        }

        void FixedUpdate()
        {
            var paralax_distanse = camera_transform.position - previous_position;
            previous_position = camera_transform.position;
            transform.position += paralax_distanse * parallax_strenght ;  
        }
    }
}