using System;
using UnityEngine;

// Token: 0x02000219 RID: 537
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VHS_Rewind")]
public class CameraFilterPack_TV_VHS_Rewind : MonoBehaviour
{
	// Token: 0x1700031E RID: 798
	// (get) Token: 0x0600117B RID: 4475 RVA: 0x00087EB0 File Offset: 0x000860B0
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

	// Token: 0x0600117C RID: 4476 RVA: 0x00087EE4 File Offset: 0x000860E4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_VHS_Rewind");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600117D RID: 4477 RVA: 0x00087F08 File Offset: 0x00086108
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
			this.material.SetFloat("_Value", this.Cryptage);
			this.material.SetFloat("_Value2", this.Parasite);
			this.material.SetFloat("_Value3", this.Parasite2);
			this.material.SetFloat("_Value4", this.WhiteParasite);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600117E RID: 4478 RVA: 0x00088000 File Offset: 0x00086200
	private void Update()
	{
	}

	// Token: 0x0600117F RID: 4479 RVA: 0x00088002 File Offset: 0x00086202
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001609 RID: 5641
	public Shader SCShader;

	// Token: 0x0400160A RID: 5642
	private float TimeX = 1f;

	// Token: 0x0400160B RID: 5643
	private Material SCMaterial;

	// Token: 0x0400160C RID: 5644
	[Range(0f, 1f)]
	public float Cryptage = 1f;

	// Token: 0x0400160D RID: 5645
	[Range(-20f, 20f)]
	public float Parasite = 9f;

	// Token: 0x0400160E RID: 5646
	[Range(-20f, 20f)]
	public float Parasite2 = 12f;

	// Token: 0x0400160F RID: 5647
	[Range(0f, 1f)]
	private float WhiteParasite = 1f;
}
