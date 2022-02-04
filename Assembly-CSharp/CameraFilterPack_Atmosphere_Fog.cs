using System;
using UnityEngine;

// Token: 0x02000121 RID: 289
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Fog")]
public class CameraFilterPack_Atmosphere_Fog : MonoBehaviour
{
	// Token: 0x17000225 RID: 549
	// (get) Token: 0x06000B43 RID: 2883 RVA: 0x0006BB41 File Offset: 0x00069D41
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

	// Token: 0x06000B44 RID: 2884 RVA: 0x0006BB75 File Offset: 0x00069D75
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

	// Token: 0x06000B45 RID: 2885 RVA: 0x0006BBAC File Offset: 0x00069DAC
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

	// Token: 0x06000B46 RID: 2886 RVA: 0x0006BCC6 File Offset: 0x00069EC6
	private void Update()
	{
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x0006BCC8 File Offset: 0x00069EC8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F46 RID: 3910
	public Shader SCShader;

	// Token: 0x04000F47 RID: 3911
	private float TimeX = 1f;

	// Token: 0x04000F48 RID: 3912
	private Material SCMaterial;

	// Token: 0x04000F49 RID: 3913
	[Range(0f, 1f)]
	public float _Near;

	// Token: 0x04000F4A RID: 3914
	[Range(0f, 1f)]
	public float _Far = 0.05f;

	// Token: 0x04000F4B RID: 3915
	public Color FogColor = new Color(0.4f, 0.4f, 0.4f, 1f);

	// Token: 0x04000F4C RID: 3916
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000F4D RID: 3917
	public static Color ChangeColorRGB;

	// Token: 0x04000F4E RID: 3918
	private Texture2D Texture2;
}
