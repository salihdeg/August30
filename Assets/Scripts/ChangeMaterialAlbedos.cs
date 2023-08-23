using UnityEngine;

public class ChangeMaterialAlbedos : MonoBehaviour
{
    public Material[] materials;
    public Texture[] sprites;

    private void Start()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetTexture("_MainTex", sprites[i]);
        }
    }
}