using System;
using UnityEngine;

// Token: 0x02000111 RID: 273
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Matrix")]
public class CameraFilterPack_3D_Matrix : MonoBehaviour
{
	// Token: 0x17000215 RID: 533
	// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x00069DD9 File Offset: 0x00067FD9
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

	// Token: 0x06000AE7 RID: 2791 RVA: 0x00069E0D File Offset: 0x0006800D
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

	// Token: 0x06000AE8 RID: 2792 RVA: 0x00069E44 File Offset: 0x00068044
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

	// Token: 0x06000AE9 RID: 2793 RVA: 0x00069FD0 File Offset: 0x000681D0
	private void Update()
	{
	}

	// Token: 0x06000AEA RID: 2794 RVA: 0x00069FD2 File Offset: 0x000681D2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EA4 RID: 3748
	public Shader SCShader;

	// Token: 0x04000EA5 RID: 3749
	private float TimeX = 1f;

	// Token: 0x04000EA6 RID: 3750
	private Material SCMaterial;

	// Token: 0x04000EA7 RID: 3751
	public bool _Visualize;

	// Token: 0x04000EA8 RID: 3752
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04000EA9 RID: 3753
	[Range(-5f, 5f)]
	public float LightIntensity = 1f;

	// Token: 0x04000EAA RID: 3754
	[Range(0f, 6f)]
	public float MatrixSize = 1f;

	// Token: 0x04000EAB RID: 3755
	[Range(-4f, 4f)]
	public float MatrixSpeed = 1f;

	// Token: 0x04000EAC RID: 3756
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000EAD RID: 3757
	public Color _MatrixColor = new Color(0f, 1f, 0f, 1f);

	// Token: 0x04000EAE RID: 3758
	public static Color ChangeColorRGB;

	// Token: 0x04000EAF RID: 3759
	private Texture2D Texture2;
}
