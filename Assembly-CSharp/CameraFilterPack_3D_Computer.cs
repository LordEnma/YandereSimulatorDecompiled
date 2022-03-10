using System;
using UnityEngine;

// Token: 0x0200010C RID: 268
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Computer")]
public class CameraFilterPack_3D_Computer : MonoBehaviour
{
	// Token: 0x17000210 RID: 528
	// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x00068C19 File Offset: 0x00066E19
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

	// Token: 0x06000AC7 RID: 2759 RVA: 0x00068C4D File Offset: 0x00066E4D
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

	// Token: 0x06000AC8 RID: 2760 RVA: 0x00068C84 File Offset: 0x00066E84
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

	// Token: 0x06000AC9 RID: 2761 RVA: 0x00068E10 File Offset: 0x00067010
	private void Update()
	{
	}

	// Token: 0x06000ACA RID: 2762 RVA: 0x00068E12 File Offset: 0x00067012
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E5D RID: 3677
	public Shader SCShader;

	// Token: 0x04000E5E RID: 3678
	private float TimeX = 1f;

	// Token: 0x04000E5F RID: 3679
	public bool _Visualize;

	// Token: 0x04000E60 RID: 3680
	private Material SCMaterial;

	// Token: 0x04000E61 RID: 3681
	[Range(0f, 100f)]
	public float _FixDistance = 2f;

	// Token: 0x04000E62 RID: 3682
	[Range(-5f, 5f)]
	public float LightIntensity = 1f;

	// Token: 0x04000E63 RID: 3683
	[Range(0f, 8f)]
	public float MatrixSize = 2f;

	// Token: 0x04000E64 RID: 3684
	[Range(-4f, 4f)]
	public float MatrixSpeed = 0.1f;

	// Token: 0x04000E65 RID: 3685
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000E66 RID: 3686
	public Color _MatrixColor = new Color(0f, 0.5f, 1f, 1f);

	// Token: 0x04000E67 RID: 3687
	public static Color ChangeColorRGB;

	// Token: 0x04000E68 RID: 3688
	private Texture2D Texture2;
}
