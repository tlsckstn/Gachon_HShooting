using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private static int k_yParameters = Animator.StringToHash("Y");

    public void SetMoveParameters(float y)
    {
        //anim.SetFloat(k_yParameters, y);
    }
}
