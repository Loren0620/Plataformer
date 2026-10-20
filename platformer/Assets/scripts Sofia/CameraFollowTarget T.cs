using UnityEngine;

   public class CameraFollowTargetT : MonoBehaviour
   {
       [SerializeField] private Transform _target;
   
       private void Update()
       {
           transform.position = new Vector3(
              _target.position.x,
              transform.position.y,
              transform.position.z
          );
      }
  }
