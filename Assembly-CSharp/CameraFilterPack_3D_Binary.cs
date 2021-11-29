using System;
using UnityEngine;

// Token: 0x02000109 RID: 265
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Binary")]
public class CameraFilterPack_3D_Binary : MonoBehaviour
{
	// Token: 0x1700020E RID: 526
	// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x00068156 File Offset: 0x00066356
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

	// Token: 0x06000AB7 RID: 2743 RVA: 0x0006818A File Offset: 0x0006638A
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_3D_Binary1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/3D_Binary");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x000681C0 File Offset: 0x000663C0
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
			this.material.SetFloat("_FadeFromBinary", this.FadeFromBinary);
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

	// Token: 0x06000AB9 RID: 2745 RVA: 0x00068362 File Offset: 0x00066562
	private void Update()
	{
	}

	// Token: 0x06000ABA RID: 2746 RVA: 0x00068364 File Offset: 0x00066564
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E33 RID: 3635
	public Shader SCShader;

	// Token: 0x04000E34 RID: 3636
	private float TimeX = 1f;

	// Token: 0x04000E35 RID: 3637
	public bool _Visualize;

	// Token: 0x04000E36 RID: 3638
	private Material SCMaterial;

	// Token: 0x04000E37 RID: 3639
	[Range(0f, 100f)]
	public float _FixDistance = 2f;

	// Token: 0x04000E38 RID: 3640
	[Range(-5f, 5f)]
	public float LightIntensity;

	// Token: 0x04000E39 RID: 3641
	[Range(0f, 8f)]
	public float MatrixSize = 2f;

	// Token: 0x04000E3A RID: 3642
	[Range(-4f, 4f)]
	public float MatrixSpeed = 1f;

	// Token: 0x04000E3B RID: 3643
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000E3C RID: 3644
	[Range(0f, 1f)]
	public float FadeFromBinary;

	// Token: 0x04000E3D RID: 3645
	public Color _MatrixColor = new Color(1f, 0.3f, 0.3f, 1f);

	// Token: 0x04000E3E RID: 3646
	public static Color ChangeColorRGB;

	// Token: 0x04000E3F RID: 3647
	private Texture2D Texture2;
}
