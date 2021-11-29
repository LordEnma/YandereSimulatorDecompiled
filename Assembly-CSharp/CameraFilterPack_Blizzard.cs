using System;
using UnityEngine;

// Token: 0x02000145 RID: 325
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Blizzard")]
public class CameraFilterPack_Blizzard : MonoBehaviour
{
	// Token: 0x1700024A RID: 586
	// (get) Token: 0x06000C5D RID: 3165 RVA: 0x000714D3 File Offset: 0x0006F6D3
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

	// Token: 0x06000C5E RID: 3166 RVA: 0x00071507 File Offset: 0x0006F707
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Blizzard1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Blizzard");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x00071540 File Offset: 0x0006F740
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
			this.material.SetFloat("_Value", this._Speed);
			this.material.SetFloat("_Value2", this._Size);
			this.material.SetFloat("_Value3", this._Fade);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C60 RID: 3168 RVA: 0x0007160B File Offset: 0x0006F80B
	private void Update()
	{
	}

	// Token: 0x06000C61 RID: 3169 RVA: 0x0007160D File Offset: 0x0006F80D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010A0 RID: 4256
	public Shader SCShader;

	// Token: 0x040010A1 RID: 4257
	private float TimeX = 1f;

	// Token: 0x040010A2 RID: 4258
	[Range(0f, 2f)]
	public float _Speed = 1f;

	// Token: 0x040010A3 RID: 4259
	[Range(0.2f, 2f)]
	public float _Size = 1f;

	// Token: 0x040010A4 RID: 4260
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x040010A5 RID: 4261
	private Material SCMaterial;

	// Token: 0x040010A6 RID: 4262
	private Texture2D Texture2;
}
