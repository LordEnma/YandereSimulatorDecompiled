using System;
using UnityEngine;

// Token: 0x02000219 RID: 537
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VHS")]
public class CameraFilterPack_TV_VHS : MonoBehaviour
{
	// Token: 0x1700031D RID: 797
	// (get) Token: 0x0600117B RID: 4475 RVA: 0x00088731 File Offset: 0x00086931
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

	// Token: 0x0600117C RID: 4476 RVA: 0x00088765 File Offset: 0x00086965
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_VHS");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600117D RID: 4477 RVA: 0x00088788 File Offset: 0x00086988
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

	// Token: 0x0600117E RID: 4478 RVA: 0x00088880 File Offset: 0x00086A80
	private void Update()
	{
	}

	// Token: 0x0600117F RID: 4479 RVA: 0x00088882 File Offset: 0x00086A82
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400161A RID: 5658
	public Shader SCShader;

	// Token: 0x0400161B RID: 5659
	private float TimeX = 1f;

	// Token: 0x0400161C RID: 5660
	private Material SCMaterial;

	// Token: 0x0400161D RID: 5661
	[Range(1f, 256f)]
	public float Cryptage = 64f;

	// Token: 0x0400161E RID: 5662
	[Range(1f, 100f)]
	public float Parasite = 32f;

	// Token: 0x0400161F RID: 5663
	[Range(0f, 3f)]
	public float Calibrage;

	// Token: 0x04001620 RID: 5664
	[Range(0f, 1f)]
	public float WhiteParasite = 1f;
}
