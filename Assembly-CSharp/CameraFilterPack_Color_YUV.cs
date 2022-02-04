using System;
using UnityEngine;

// Token: 0x02000166 RID: 358
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Color_YUV")]
public class CameraFilterPack_Color_YUV : MonoBehaviour
{
	// Token: 0x1700026A RID: 618
	// (get) Token: 0x06000D20 RID: 3360 RVA: 0x00074985 File Offset: 0x00072B85
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

	// Token: 0x06000D21 RID: 3361 RVA: 0x000749B9 File Offset: 0x00072BB9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_YUV");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D22 RID: 3362 RVA: 0x000749DC File Offset: 0x00072BDC
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

	// Token: 0x06000D23 RID: 3363 RVA: 0x00074ABE File Offset: 0x00072CBE
	private void Update()
	{
	}

	// Token: 0x06000D24 RID: 3364 RVA: 0x00074AC0 File Offset: 0x00072CC0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001163 RID: 4451
	public Shader SCShader;

	// Token: 0x04001164 RID: 4452
	private float TimeX = 1f;

	// Token: 0x04001165 RID: 4453
	private Material SCMaterial;

	// Token: 0x04001166 RID: 4454
	[Range(-1f, 1f)]
	public float _Y;

	// Token: 0x04001167 RID: 4455
	[Range(-1f, 1f)]
	public float _U;

	// Token: 0x04001168 RID: 4456
	[Range(-1f, 1f)]
	public float _V;
}
