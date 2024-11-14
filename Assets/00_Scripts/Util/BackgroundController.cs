using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float limitX;
    [SerializeField] private Transform leftImage;
    [SerializeField] private Transform rightImage;

    private Transform currentLeftImage;
    private Transform currentRightImage;

    private void Awake()
    {
        currentLeftImage = leftImage;
        currentRightImage = rightImage;
    }

    private void Update()
    {
        leftImage.position += Vector3.right * speed * Time.deltaTime;
        rightImage.position += Vector3.right * speed * Time.deltaTime;
        if(currentLeftImage.transform.position.x >= limitX) // 수정 필요
        {
            currentRightImage.position -= Vector3.right * 15f;
        }
    }
}
