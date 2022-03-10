using System;
using UnityEngine;

// Token: 0x02000166 RID: 358
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Color_YUV")]
public class CameraFilterPack_Color_YUV : MonoBehaviour
{
	// Token: 0x1700026A RID: 618
	// (get) Token: 0x06000D21 RID: 3361 RVA: 0x00074D31 File Offset: 0x00072F31
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

	// Token: 0x06000D22 RID: 3362 RVA: 0x00074D65 File Offset: 0x00072F65
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_YUV");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D23 RID: 3363 RVA: 0x00074D88 File Offset: 0x00072F88
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
			this.material.SetFloat("_Y", this._Y);
			this.material.SetFloat("_U", this._U);
			this.material.SetFloat("_V", this._V);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D24 RID: 3364 RVA: 0x00074E6A File Offset: 0x0007306A
	private void Update()
	{
	}

	// Token: 0x06000D25 RID: 3365 RVA: 0x00074E6C File Offset: 0x0007306C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400116F RID: 4463
	public Shader SCShader;

	// Token: 0x04001170 RID: 4464
	private float TimeX = 1f;

	// Token: 0x04001171 RID: 4465
	private Material SCMaterial;

	// Token: 0x04001172 RID: 4466
	[Range(-1f, 1f)]
	public float _Y;

	// Token: 0x04001173 RID: 4467
	[Range(-1f, 1f)]
	public float _U;

	// Token: 0x04001174 RID: 4468
	[Range(-1f, 1f)]
	public float _V;
}
