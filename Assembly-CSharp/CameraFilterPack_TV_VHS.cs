using System;
using UnityEngine;

// Token: 0x02000219 RID: 537
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VHS")]
public class CameraFilterPack_TV_VHS : MonoBehaviour
{
	// Token: 0x1700031D RID: 797
	// (get) Token: 0x06001179 RID: 4473 RVA: 0x000882B5 File Offset: 0x000864B5
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

	// Token: 0x0600117A RID: 4474 RVA: 0x000882E9 File Offset: 0x000864E9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_VHS");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600117B RID: 4475 RVA: 0x0008830C File Offset: 0x0008650C
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
			this.material.SetFloat("_Value3", this.Calibrage);
			this.material.SetFloat("_Value4", this.WhiteParasite);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600117C RID: 4476 RVA: 0x00088404 File Offset: 0x00086604
	private void Update()
	{
	}

	// Token: 0x0600117D RID: 4477 RVA: 0x00088406 File Offset: 0x00086606
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001613 RID: 5651
	public Shader SCShader;

	// Token: 0x04001614 RID: 5652
	private float TimeX = 1f;

	// Token: 0x04001615 RID: 5653
	private Material SCMaterial;

	// Token: 0x04001616 RID: 5654
	[Range(1f, 256f)]
	public float Cryptage = 64f;

	// Token: 0x04001617 RID: 5655
	[Range(1f, 100f)]
	public float Parasite = 32f;

	// Token: 0x04001618 RID: 5656
	[Range(0f, 3f)]
	public float Calibrage;

	// Token: 0x04001619 RID: 5657
	[Range(0f, 1f)]
	public float WhiteParasite = 1f;
}
