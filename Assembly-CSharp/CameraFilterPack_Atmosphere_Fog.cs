using System;
using UnityEngine;

// Token: 0x02000121 RID: 289
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Fog")]
public class CameraFilterPack_Atmosphere_Fog : MonoBehaviour
{
	// Token: 0x17000225 RID: 549
	// (get) Token: 0x06000B44 RID: 2884 RVA: 0x0006BEED File Offset: 0x0006A0ED
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

	// Token: 0x06000B45 RID: 2885 RVA: 0x0006BF21 File Offset: 0x0006A121
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

	// Token: 0x06000B46 RID: 2886 RVA: 0x0006BF58 File Offset: 0x0006A158
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

	// Token: 0x06000B47 RID: 2887 RVA: 0x0006C072 File Offset: 0x0006A272
	private void Update()
	{
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x0006C074 File Offset: 0x0006A274
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F52 RID: 3922
	public Shader SCShader;

	// Token: 0x04000F53 RID: 3923
	private float TimeX = 1f;

	// Token: 0x04000F54 RID: 3924
	private Material SCMaterial;

	// Token: 0x04000F55 RID: 3925
	[Range(0f, 1f)]
	public float _Near;

	// Token: 0x04000F56 RID: 3926
	[Range(0f, 1f)]
	public float _Far = 0.05f;

	// Token: 0x04000F57 RID: 3927
	public Color FogColor = new Color(0.4f, 0.4f, 0.4f, 1f);

	// Token: 0x04000F58 RID: 3928
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F59 RID: 3929
	public static Color ChangeColorRGB;

	// Token: 0x04000F5A RID: 3930
	private Texture2D Texture2;
}
