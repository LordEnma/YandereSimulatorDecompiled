using System;
using UnityEngine;

// Token: 0x02000218 RID: 536
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VHS")]
public class CameraFilterPack_TV_VHS : MonoBehaviour
{
	// Token: 0x1700031D RID: 797
	// (get) Token: 0x06001175 RID: 4469 RVA: 0x00087D11 File Offset: 0x00085F11
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

	// Token: 0x06001176 RID: 4470 RVA: 0x00087D45 File Offset: 0x00085F45
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_VHS");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x00087D68 File Offset: 0x00085F68
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

	// Token: 0x06001178 RID: 4472 RVA: 0x00087E60 File Offset: 0x00086060
	private void Update()
	{
	}

	// Token: 0x06001179 RID: 4473 RVA: 0x00087E62 File Offset: 0x00086062
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001602 RID: 5634
	public Shader SCShader;

	// Token: 0x04001603 RID: 5635
	private float TimeX = 1f;

	// Token: 0x04001604 RID: 5636
	private Material SCMaterial;

	// Token: 0x04001605 RID: 5637
	[Range(1f, 256f)]
	public float Cryptage = 64f;

	// Token: 0x04001606 RID: 5638
	[Range(1f, 100f)]
	public float Parasite = 32f;

	// Token: 0x04001607 RID: 5639
	[Range(0f, 3f)]
	public float Calibrage;

	// Token: 0x04001608 RID: 5640
	[Range(0f, 1f)]
	public float WhiteParasite = 1f;
}
