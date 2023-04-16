using Unity.VisualScripting;
using UnityEngine;

namespace Pota
{
    public class JointFinisher : MonoBehaviour
    {
        public GameObject[] joints;
        // Start is called before the first frame update

        private void Awake()
        {
            for (int i = 0; i < joints.Length; i++)
            {
                FixedJoint joint = transform.AddComponent<FixedJoint>();
                joint.connectedBody = joints[i].GetComponent<Rigidbody>();
            }
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
