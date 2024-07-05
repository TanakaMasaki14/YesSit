using UnityEngine;

[ExecuteInEditMode]
public class GrabScreenTexture : MonoBehaviour {
    public Material mat;
    public GameObject portal;

    void Start(){ this.gameObject.SetActive(false); }
    
    public void OnPostRender()
    {
        if (portal == true)
        {
            this.gameObject.SetActive(true);
            var screenRT = RenderTexture.GetTemporary(Screen.width, Screen.height, 0);
            Graphics.Blit(null, screenRT);
            mat.SetTexture("_ScreenTex", screenRT);

            RenderTexture.ReleaseTemporary(screenRT);
        }
    }
}
