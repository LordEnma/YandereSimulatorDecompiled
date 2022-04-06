using System;
using UnityEngine;

// Token: 0x0200010C RID: 268
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Computer")]
public class CameraFilterPack_3D_Computer : MonoBehaviour
{
	// Token: 0x17000210 RID: 528
	// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x00069095 File Offset: 0x00067295
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

	// Token: 0x06000AC9 RID: 2761 RVA: 0x000690C9 File Offset: 0x000672C9
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_3D_Computer1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/3D_Computer");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ACA RID: 2762 RVA: 0x00069100 File Offset: 0x00067300
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
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_MatrixSize", this.MatrixSize);
			this.material.SetColor("_MatrixColor", this._MatrixColor);
			this.material.SetFloat("_MatrixSpeed", this.MatrixSpeed * 2f);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			this.material.SetFloat("_LightIntensity", this.LightIntensity);
			this.material.SetTexture("_MainTex2", this.Texture2);
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000ACB RID: 2763 RVA: 0x0006928C File Offset: 0x0006748C
	private void Update()
	{
	}

	// Token: 0x06000ACC RID: 2764 RVA: 0x0006928E File Offset: 0x0006748E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E64 RID: 3684
	public Shader SCShader;

	// Token: 0x04000E65 RID: 3685
	private float TimeX = 1f;

	// Token: 0x04000E66 RID: 3686
	public bool _Visualize;

	// Token: 0x04000E67 RID: 3687
	private Material SCMaterial;

	// Token: 0x04000E68 RID: 3688
	[Range(0f, 100f)]
	public float _FixDistance = 2f;

	// Token: 0x04000E69 RID: 3689
	[Range(-5f, 5f)]
	public float LightIntensity = 1f;

	// Token: 0x04000E6A RID: 3690
	[Range(0f, 8f)]
	public float MatrixSize = 2f;

	// Token: 0x04000E6B RID: 3691
	[Range(-4f, 4f)]
	public float MatrixSpeed = 0.1f;

	// Token: 0x04000E6C RID: 3692
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000E6D RID: 3693
	public Color _MatrixColor = new Color(0f, 0.5f, 1f, 1f);

	// Token: 0x04000E6E RID: 3694
	public static Color ChangeColorRGB;

	// Token: 0x04000E6F RID: 3695
	private Texture2D Texture2;
}
