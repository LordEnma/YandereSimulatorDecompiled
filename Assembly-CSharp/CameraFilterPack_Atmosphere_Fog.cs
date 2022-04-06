using System;
using UnityEngine;

// Token: 0x02000121 RID: 289
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Fog")]
public class CameraFilterPack_Atmosphere_Fog : MonoBehaviour
{
	// Token: 0x17000225 RID: 549
	// (get) Token: 0x06000B46 RID: 2886 RVA: 0x0006C369 File Offset: 0x0006A569
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

	// Token: 0x06000B47 RID: 2887 RVA: 0x0006C39D File Offset: 0x0006A59D
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

	// Token: 0x06000B48 RID: 2888 RVA: 0x0006C3D4 File Offset: 0x0006A5D4
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

	// Token: 0x06000B49 RID: 2889 RVA: 0x0006C4EE File Offset: 0x0006A6EE
	private void Update()
	{
	}

	// Token: 0x06000B4A RID: 2890 RVA: 0x0006C4F0 File Offset: 0x0006A6F0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F59 RID: 3929
	public Shader SCShader;

	// Token: 0x04000F5A RID: 3930
	private float TimeX = 1f;

	// Token: 0x04000F5B RID: 3931
	private Material SCMaterial;

	// Token: 0x04000F5C RID: 3932
	[Range(0f, 1f)]
	public float _Near;

	// Token: 0x04000F5D RID: 3933
	[Range(0f, 1f)]
	public float _Far = 0.05f;

	// Token: 0x04000F5E RID: 3934
	public Color FogColor = new Color(0.4f, 0.4f, 0.4f, 1f);

	// Token: 0x04000F5F RID: 3935
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F60 RID: 3936
	public static Color ChangeColorRGB;

	// Token: 0x04000F61 RID: 3937
	private Texture2D Texture2;
}
