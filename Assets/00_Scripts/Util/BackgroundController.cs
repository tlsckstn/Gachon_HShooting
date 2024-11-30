using UnityEngine;

/// <summary>
/// 왼쪽으로 움직이면서 왼쪽에 존재하는 배경이 일정 값을 넘어서면 왼쪽에 존재하는 배경을 오른쪽으로 이동
/// </summary>
public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float limitX;
    [SerializeField] private float moveAmount;
    [SerializeField] private Transform leftImage;
    [SerializeField] private Transform rightImage;

    private Vector3 addPos = new();

    private Transform GetLeftTransform()
    {
        return leftImage.position.x > rightImage.position.x ? rightImage : leftImage;
    }

    private void Update()
    {
        addPos = Vector3.left * speed * Time.deltaTime;
        leftImage.position += addPos;
        rightImage.position += addPos;
        if(GetLeftTransform().position.x <= limitX)
        {
            GetLeftTransform().position += Vector3.right * moveAmount;
        }
    }
}
