using System;
using UnityEngine;

// Token: 0x02000120 RID: 288
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Fog")]
public class CameraFilterPack_Atmosphere_Fog : MonoBehaviour
{
	// Token: 0x17000225 RID: 549
	// (get) Token: 0x06000B40 RID: 2880 RVA: 0x0006B949 File Offset: 0x00069B49
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

	// Token: 0x06000B41 RID: 2881 RVA: 0x0006B97D File Offset: 0x00069B7D
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

	// Token: 0x06000B42 RID: 2882 RVA: 0x0006B9B4 File Offset: 0x00069BB4
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

	// Token: 0x06000B43 RID: 2883 RVA: 0x0006BACE File Offset: 0x00069CCE
	private void Update()
	{
	}

	// Token: 0x06000B44 RID: 2884 RVA: 0x0006BAD0 File Offset: 0x00069CD0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F41 RID: 3905
	public Shader SCShader;

	// Token: 0x04000F42 RID: 3906
	private float TimeX = 1f;

	// Token: 0x04000F43 RID: 3907
	private Material SCMaterial;

	// Token: 0x04000F44 RID: 3908
	[Range(0f, 1f)]
	public float _Near;

	// Token: 0x04000F45 RID: 3909
	[Range(0f, 1f)]
	public float _Far = 0.05f;

	// Token: 0x04000F46 RID: 3910
	public Color FogColor = new Color(0.4f, 0.4f, 0.4f, 1f);

	// Token: 0x04000F47 RID: 3911
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F48 RID: 3912
	public static Color ChangeColorRGB;

	// Token: 0x04000F49 RID: 3913
	private Texture2D Texture2;
}
