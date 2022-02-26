using System;
using UnityEngine;

// Token: 0x02000121 RID: 289
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Fog")]
public class CameraFilterPack_Atmosphere_Fog : MonoBehaviour
{
	// Token: 0x17000225 RID: 549
	// (get) Token: 0x06000B44 RID: 2884 RVA: 0x0006BDA5 File Offset: 0x00069FA5
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06000B45 RID: 2885 RVA: 0x0006BDD9 File Offset: 0x00069FD9
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Atmosphere_Rain_FX") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Atmosphere_Fog");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B46 RID: 2886 RVA: 0x0006BE10 File Offset: 0x0006A010
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_DepthLevel", this.Fade);
			this.material.SetFloat("_Near", this._Near);
			this.material.SetFloat("_Far", this._Far);
			this.material.SetColor("_ColorRGB", this.FogColor);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x0006BF2A File Offset: 0x0006A12A
	private void Update()
	{
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x0006BF2C File Offset: 0x0006A12C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F49 RID: 3913
	public Shader SCShader;

	// Token: 0x04000F4A RID: 3914
	private float TimeX = 1f;

	// Token: 0x04000F4B RID: 3915
	private Material SCMaterial;

	// Token: 0x04000F4C RID: 3916
	[Range(0f, 1f)]
	public float _Near;

	// Token: 0x04000F4D RID: 3917
	[Range(0f, 1f)]
	public float _Far = 0.05f;

	// Token: 0x04000F4E RID: 3918
	public Color FogColor = new Color(0.4f, 0.4f, 0.4f, 1f);

	// Token: 0x04000F4F RID: 3919
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F50 RID: 3920
	public static Color ChangeColorRGB;

	// Token: 0x04000F51 RID: 3921
	private Texture2D Texture2;
}
