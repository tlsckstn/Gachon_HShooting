using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField, Range(-1f, 1f)] private float moveSpeed = 0.1f;
    [SerializeField] private Renderer[] renderers;
    private Material[] materials;

    private void Awake()
    {
        materials = new Material[renderers.Length];
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = renderers[i].material;
        }
    }

    private void Update()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetTextureOffset("_MainTex", Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}
