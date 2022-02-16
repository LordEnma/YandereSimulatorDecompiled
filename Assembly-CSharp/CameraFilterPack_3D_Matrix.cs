using System;
using UnityEngine;

// Token: 0x02000111 RID: 273
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Matrix")]
public class CameraFilterPack_3D_Matrix : MonoBehaviour
{
	// Token: 0x17000215 RID: 533
	// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x00069701 File Offset: 0x00067901
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

	// Token: 0x06000AE5 RID: 2789 RVA: 0x00069735 File Offset: 0x00067935
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_3D_Matrix1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/3D_Matrix");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AE6 RID: 2790 RVA: 0x0006976C File Offset: 0x0006796C
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

	// Token: 0x06000AE7 RID: 2791 RVA: 0x000698F8 File Offset: 0x00067AF8
	private void Update()
	{
	}

	// Token: 0x06000AE8 RID: 2792 RVA: 0x000698FA File Offset: 0x00067AFA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E94 RID: 3732
	public Shader SCShader;

	// Token: 0x04000E95 RID: 3733
	private float TimeX = 1f;

	// Token: 0x04000E96 RID: 3734
	private Material SCMaterial;

	// Token: 0x04000E97 RID: 3735
	public bool _Visualize;

	// Token: 0x04000E98 RID: 3736
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04000E99 RID: 3737
	[Range(-5f, 5f)]
	public float LightIntensity = 1f;

	// Token: 0x04000E9A RID: 3738
	[Range(0f, 6f)]
	public float MatrixSize = 1f;

	// Token: 0x04000E9B RID: 3739
	[Range(-4f, 4f)]
	public float MatrixSpeed = 1f;

	// Token: 0x04000E9C RID: 3740
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000E9D RID: 3741
	public Color _MatrixColor = new Color(0f, 1f, 0f, 1f);

	// Token: 0x04000E9E RID: 3742
	public static Color ChangeColorRGB;

	// Token: 0x04000E9F RID: 3743
	private Texture2D Texture2;
}
