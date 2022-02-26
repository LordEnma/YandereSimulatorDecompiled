using System;
using UnityEngine;

// Token: 0x02000219 RID: 537
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VHS")]
public class CameraFilterPack_TV_VHS : MonoBehaviour
{
	// Token: 0x1700031D RID: 797
	// (get) Token: 0x06001179 RID: 4473 RVA: 0x0008816D File Offset: 0x0008636D
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

	// Token: 0x0600117A RID: 4474 RVA: 0x000881A1 File Offset: 0x000863A1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_VHS");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600117B RID: 4475 RVA: 0x000881C4 File Offset: 0x000863C4
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

	// Token: 0x0600117C RID: 4476 RVA: 0x000882BC File Offset: 0x000864BC
	private void Update()
	{
	}

	// Token: 0x0600117D RID: 4477 RVA: 0x000882BE File Offset: 0x000864BE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400160A RID: 5642
	public Shader SCShader;

	// Token: 0x0400160B RID: 5643
	private float TimeX = 1f;

	// Token: 0x0400160C RID: 5644
	private Material SCMaterial;

	// Token: 0x0400160D RID: 5645
	[Range(1f, 256f)]
	public float Cryptage = 64f;

	// Token: 0x0400160E RID: 5646
	[Range(1f, 100f)]
	public float Parasite = 32f;

	// Token: 0x0400160F RID: 5647
	[Range(0f, 3f)]
	public float Calibrage;

	// Token: 0x04001610 RID: 5648
	[Range(0f, 1f)]
	public float WhiteParasite = 1f;
}
