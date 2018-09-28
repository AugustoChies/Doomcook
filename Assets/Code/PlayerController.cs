using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Serializable]  
    
    public class MoveAxis
    {
        public KeyCode Positive;
        public KeyCode Negative;

        public MoveAxis(KeyCode positive, KeyCode negative)
        {
            Positive = positive;
            Negative = negative;
        }

        public static implicit operator float(MoveAxis axis)
        {
            return (Input.GetKey(axis.Positive)
                ? 1.0f : 0.0f) -
                (Input.GetKey(axis.Negative)
                ? 1.0f : 0.0f);
        }
    }

    public FloatVariable speed;
    public MoveAxis Horizontal = new MoveAxis(KeyCode.D, KeyCode.A);
    public MoveAxis Vertical = new MoveAxis(KeyCode.W, KeyCode.S);

    private void Update()
    {
        Vector3 moveNormal = new Vector3(Horizontal, 0.0f, Vertical).normalized;

        this.transform.LookAt(transform.position + moveNormal);
        gameObject.GetComponent<Rigidbody>().MovePosition(this.transform.position + moveNormal * Time.deltaTime * speed.Value);
    }
}
