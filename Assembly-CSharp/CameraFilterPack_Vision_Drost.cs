using System;
using UnityEngine;

// Token: 0x0200022A RID: 554
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Drost")]
public class CameraFilterPack_Vision_Drost : MonoBehaviour
{
	// Token: 0x1700032E RID: 814
	// (get) Token: 0x060011E1 RID: 4577 RVA: 0x0008A0FB File Offset: 0x000882FB
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

	// Token: 0x060011E2 RID: 4578 RVA: 0x0008A12F File Offset: 0x0008832F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Drost");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011E3 RID: 4579 RVA: 0x0008A150 File Offset: 0x00088350
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
			this.material.SetFloat("_Value", this.Intensity);
			this.material.SetFloat("_Value2", this.Speed);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011E4 RID: 4580 RVA: 0x0008A248 File Offset: 0x00088448
	private void Update()
	{
	}

	// Token: 0x060011E5 RID: 4581 RVA: 0x0008A24A File Offset: 0x0008844A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001682 RID: 5762
	public Shader SCShader;

	// Token: 0x04001683 RID: 5763
	private float TimeX = 1f;

	// Token: 0x04001684 RID: 5764
	private Material SCMaterial;

	// Token: 0x04001685 RID: 5765
	[Range(0f, 0.4f)]
	public float Intensity = 0.4f;

	// Token: 0x04001686 RID: 5766
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001687 RID: 5767
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001688 RID: 5768
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
