using System;
using UnityEngine;

// Token: 0x02000165 RID: 357
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Color_YUV")]
public class CameraFilterPack_Color_YUV : MonoBehaviour
{
	// Token: 0x1700026A RID: 618
	// (get) Token: 0x06000D1D RID: 3357 RVA: 0x0007478D File Offset: 0x0007298D
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

	// Token: 0x06000D1E RID: 3358 RVA: 0x000747C1 File Offset: 0x000729C1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_YUV");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x000747E4 File Offset: 0x000729E4
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

	// Token: 0x06000D20 RID: 3360 RVA: 0x000748C6 File Offset: 0x00072AC6
	private void Update()
	{
	}

	// Token: 0x06000D21 RID: 3361 RVA: 0x000748C8 File Offset: 0x00072AC8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400115E RID: 4446
	public Shader SCShader;

	// Token: 0x0400115F RID: 4447
	private float TimeX = 1f;

	// Token: 0x04001160 RID: 4448
	private Material SCMaterial;

	// Token: 0x04001161 RID: 4449
	[Range(-1f, 1f)]
	public float _Y;

	// Token: 0x04001162 RID: 4450
	[Range(-1f, 1f)]
	public float _U;

	// Token: 0x04001163 RID: 4451
	[Range(-1f, 1f)]
	public float _V;
}
