using UnityEngine;

public class VelocityMovement : Movement
{
    [SerializeField] private Rigidbody2D rigid;

    public override void Move(Vector3 vec)
    {
        rigid.linearVelocity = vec * speed;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
