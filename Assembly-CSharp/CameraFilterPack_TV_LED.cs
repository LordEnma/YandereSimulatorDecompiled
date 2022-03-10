using System;
using UnityEngine;

// Token: 0x0200020F RID: 527
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/LED")]
public class CameraFilterPack_TV_LED : MonoBehaviour
{
	// Token: 0x17000313 RID: 787
	// (get) Token: 0x0600113D RID: 4413 RVA: 0x000874FB File Offset: 0x000856FB
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

	// Token: 0x0600113E RID: 4414 RVA: 0x0008752F File Offset: 0x0008572F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_LED");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600113F RID: 4415 RVA: 0x00087550 File Offset: 0x00085750
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
			this.material.SetFloat("_Size", (float)this.Size);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001140 RID: 4416 RVA: 0x00087633 File Offset: 0x00085833
	private void Update()
	{
	}

	// Token: 0x06001141 RID: 4417 RVA: 0x00087635 File Offset: 0x00085835
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015DF RID: 5599
	public Shader SCShader;

	// Token: 0x040015E0 RID: 5600
	private float TimeX = 1f;

	// Token: 0x040015E1 RID: 5601
	[Range(0f, 1f)]
	public float Fade;

	// Token: 0x040015E2 RID: 5602
	[Range(1f, 10f)]
	private float Distortion = 1f;

	// Token: 0x040015E3 RID: 5603
	[Range(1f, 15f)]
	public int Size = 5;

	// Token: 0x040015E4 RID: 5604
	private Material SCMaterial;
}
