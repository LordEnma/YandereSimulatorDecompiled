using System;
using UnityEngine;

// Token: 0x02000146 RID: 326
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Blizzard")]
public class CameraFilterPack_Blizzard : MonoBehaviour
{
	// Token: 0x1700024A RID: 586
	// (get) Token: 0x06000C61 RID: 3169 RVA: 0x0007181B File Offset: 0x0006FA1B
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

	// Token: 0x06000C62 RID: 3170 RVA: 0x0007184F File Offset: 0x0006FA4F
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

	// Token: 0x06000C63 RID: 3171 RVA: 0x00071888 File Offset: 0x0006FA88
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

	// Token: 0x06000C64 RID: 3172 RVA: 0x00071953 File Offset: 0x0006FB53
	private void Update()
	{
	}

	// Token: 0x06000C65 RID: 3173 RVA: 0x00071955 File Offset: 0x0006FB55
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010A8 RID: 4264
	public Shader SCShader;

	// Token: 0x040010A9 RID: 4265
	private float TimeX = 1f;

	// Token: 0x040010AA RID: 4266
	[Range(0f, 2f)]
	public float _Speed = 1f;

	// Token: 0x040010AB RID: 4267
	[Range(0.2f, 2f)]
	public float _Size = 1f;

	// Token: 0x040010AC RID: 4268
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x040010AD RID: 4269
	private Material SCMaterial;

	// Token: 0x040010AE RID: 4270
	private Texture2D Texture2;
}
