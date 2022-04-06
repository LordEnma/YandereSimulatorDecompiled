using System;
using UnityEngine;

// Token: 0x02000146 RID: 326
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Blizzard")]
public class CameraFilterPack_Blizzard : MonoBehaviour
{
	// Token: 0x1700024A RID: 586
	// (get) Token: 0x06000C63 RID: 3171 RVA: 0x00071EF3 File Offset: 0x000700F3
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

	// Token: 0x06000C64 RID: 3172 RVA: 0x00071F27 File Offset: 0x00070127
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

	// Token: 0x06000C65 RID: 3173 RVA: 0x00071F60 File Offset: 0x00070160
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

	// Token: 0x06000C66 RID: 3174 RVA: 0x0007202B File Offset: 0x0007022B
	private void Update()
	{
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x0007202D File Offset: 0x0007022D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010B8 RID: 4280
	public Shader SCShader;

	// Token: 0x040010B9 RID: 4281
	private float TimeX = 1f;

	// Token: 0x040010BA RID: 4282
	[Range(0f, 2f)]
	public float _Speed = 1f;

	// Token: 0x040010BB RID: 4283
	[Range(0.2f, 2f)]
	public float _Size = 1f;

	// Token: 0x040010BC RID: 4284
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x040010BD RID: 4285
	private Material SCMaterial;

	// Token: 0x040010BE RID: 4286
	private Texture2D Texture2;
}
