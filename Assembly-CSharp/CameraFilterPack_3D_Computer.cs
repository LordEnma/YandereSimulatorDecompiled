using System;
using UnityEngine;

// Token: 0x0200010C RID: 268
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Computer")]
public class CameraFilterPack_3D_Computer : MonoBehaviour
{
	// Token: 0x17000210 RID: 528
	// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x0006886D File Offset: 0x00066A6D
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

	// Token: 0x06000AC6 RID: 2758 RVA: 0x000688A1 File Offset: 0x00066AA1
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

	// Token: 0x06000AC7 RID: 2759 RVA: 0x000688D8 File Offset: 0x00066AD8
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

	// Token: 0x06000AC8 RID: 2760 RVA: 0x00068A64 File Offset: 0x00066C64
	private void Update()
	{
	}

	// Token: 0x06000AC9 RID: 2761 RVA: 0x00068A66 File Offset: 0x00066C66
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E51 RID: 3665
	public Shader SCShader;

	// Token: 0x04000E52 RID: 3666
	private float TimeX = 1f;

	// Token: 0x04000E53 RID: 3667
	public bool _Visualize;

	// Token: 0x04000E54 RID: 3668
	private Material SCMaterial;

	// Token: 0x04000E55 RID: 3669
	[Range(0f, 100f)]
	public float _FixDistance = 2f;

	// Token: 0x04000E56 RID: 3670
	[Range(-5f, 5f)]
	public float LightIntensity = 1f;

	// Token: 0x04000E57 RID: 3671
	[Range(0f, 8f)]
	public float MatrixSize = 2f;

	// Token: 0x04000E58 RID: 3672
	[Range(-4f, 4f)]
	public float MatrixSpeed = 0.1f;

	// Token: 0x04000E59 RID: 3673
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000E5A RID: 3674
	public Color _MatrixColor = new Color(0f, 0.5f, 1f, 1f);

	// Token: 0x04000E5B RID: 3675
	public static Color ChangeColorRGB;

	// Token: 0x04000E5C RID: 3676
	private Texture2D Texture2;
}
