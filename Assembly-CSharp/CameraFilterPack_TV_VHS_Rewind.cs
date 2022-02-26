using System;
using UnityEngine;

// Token: 0x0200021A RID: 538
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VHS_Rewind")]
public class CameraFilterPack_TV_VHS_Rewind : MonoBehaviour
{
	// Token: 0x1700031E RID: 798
	// (get) Token: 0x0600117F RID: 4479 RVA: 0x0008830C File Offset: 0x0008650C
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

	// Token: 0x06001180 RID: 4480 RVA: 0x00088340 File Offset: 0x00086540
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_VHS_Rewind");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001181 RID: 4481 RVA: 0x00088364 File Offset: 0x00086564
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

	// Token: 0x06001182 RID: 4482 RVA: 0x0008845C File Offset: 0x0008665C
	private void Update()
	{
	}

	// Token: 0x06001183 RID: 4483 RVA: 0x0008845E File Offset: 0x0008665E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001611 RID: 5649
	public Shader SCShader;

	// Token: 0x04001612 RID: 5650
	private float TimeX = 1f;

	// Token: 0x04001613 RID: 5651
	private Material SCMaterial;

	// Token: 0x04001614 RID: 5652
	[Range(0f, 1f)]
	public float Cryptage = 1f;

	// Token: 0x04001615 RID: 5653
	[Range(-20f, 20f)]
	public float Parasite = 9f;

	// Token: 0x04001616 RID: 5654
	[Range(-20f, 20f)]
	public float Parasite2 = 12f;

	// Token: 0x04001617 RID: 5655
	[Range(0f, 1f)]
	private float WhiteParasite = 1f;
}
