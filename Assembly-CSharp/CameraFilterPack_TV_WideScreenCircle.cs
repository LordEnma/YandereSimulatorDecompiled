using System;
using UnityEngine;

// Token: 0x02000220 RID: 544
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenCircle")]
public class CameraFilterPack_TV_WideScreenCircle : MonoBehaviour
{
	// Token: 0x17000324 RID: 804
	// (get) Token: 0x060011A5 RID: 4517 RVA: 0x00089048 File Offset: 0x00087248
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

	// Token: 0x060011A6 RID: 4518 RVA: 0x0008907C File Offset: 0x0008727C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenCircle");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011A7 RID: 4519 RVA: 0x000890A0 File Offset: 0x000872A0
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Smooth);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011A8 RID: 4520 RVA: 0x00089198 File Offset: 0x00087398
	private void Update()
	{
	}

	// Token: 0x060011A9 RID: 4521 RVA: 0x0008919A File Offset: 0x0008739A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400163D RID: 5693
	public Shader SCShader;

	// Token: 0x0400163E RID: 5694
	private float TimeX = 1f;

	// Token: 0x0400163F RID: 5695
	private Material SCMaterial;

	// Token: 0x04001640 RID: 5696
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x04001641 RID: 5697
	[Range(0.01f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x04001642 RID: 5698
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x04001643 RID: 5699
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
