using System;
using UnityEngine;

// Token: 0x02000231 RID: 561
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Warp")]
public class CameraFilterPack_Vision_Warp : MonoBehaviour
{
	// Token: 0x17000335 RID: 821
	// (get) Token: 0x06001209 RID: 4617 RVA: 0x0008AA0F File Offset: 0x00088C0F
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

	// Token: 0x0600120A RID: 4618 RVA: 0x0008AA43 File Offset: 0x00088C43
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Warp");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600120B RID: 4619 RVA: 0x0008AA64 File Offset: 0x00088C64
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600120C RID: 4620 RVA: 0x0008AB5C File Offset: 0x00088D5C
	private void Update()
	{
	}

	// Token: 0x0600120D RID: 4621 RVA: 0x0008AB5E File Offset: 0x00088D5E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040016B9 RID: 5817
	public Shader SCShader;

	// Token: 0x040016BA RID: 5818
	private float TimeX = 1f;

	// Token: 0x040016BB RID: 5819
	private Material SCMaterial;

	// Token: 0x040016BC RID: 5820
	[Range(0f, 1f)]
	public float Value = 0.6f;

	// Token: 0x040016BD RID: 5821
	[Range(0f, 1f)]
	public float Value2 = 0.6f;

	// Token: 0x040016BE RID: 5822
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040016BF RID: 5823
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
