using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Broken_Screen")]
public class CameraFilterPack_Broken_Screen : MonoBehaviour
{
	// Token: 0x1700025B RID: 603
	// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x00073BD9 File Offset: 0x00071DD9
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

	// Token: 0x06000CCA RID: 3274 RVA: 0x00073C0D File Offset: 0x00071E0D
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Broken_Screen1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Broken_Screen");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x00073C44 File Offset: 0x00071E44
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
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetFloat("_Shadow", this.Shadow);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CCC RID: 3276 RVA: 0x00073CF9 File Offset: 0x00071EF9
	private void Update()
	{
	}

	// Token: 0x06000CCD RID: 3277 RVA: 0x00073CFB File Offset: 0x00071EFB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001124 RID: 4388
	public Shader SCShader;

	// Token: 0x04001125 RID: 4389
	private float TimeX = 1f;

	// Token: 0x04001126 RID: 4390
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001127 RID: 4391
	[Range(-1f, 1f)]
	public float Shadow = 1f;

	// Token: 0x04001128 RID: 4392
	private Material SCMaterial;

	// Token: 0x04001129 RID: 4393
	private Texture2D Texture2;
}
