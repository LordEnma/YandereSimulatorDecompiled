using System;
using UnityEngine;

// Token: 0x02000223 RID: 547
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenVertical")]
public class CameraFilterPack_TV_WideScreenVertical : MonoBehaviour
{
	// Token: 0x17000327 RID: 807
	// (get) Token: 0x060011B7 RID: 4535 RVA: 0x00089543 File Offset: 0x00087743
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

	// Token: 0x060011B8 RID: 4536 RVA: 0x00089577 File Offset: 0x00087777
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenVertical");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011B9 RID: 4537 RVA: 0x00089598 File Offset: 0x00087798
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

	// Token: 0x060011BA RID: 4538 RVA: 0x00089690 File Offset: 0x00087890
	private void Update()
	{
	}

	// Token: 0x060011BB RID: 4539 RVA: 0x00089692 File Offset: 0x00087892
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001652 RID: 5714
	public Shader SCShader;

	// Token: 0x04001653 RID: 5715
	private float TimeX = 1f;

	// Token: 0x04001654 RID: 5716
	private Material SCMaterial;

	// Token: 0x04001655 RID: 5717
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x04001656 RID: 5718
	[Range(0.001f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x04001657 RID: 5719
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x04001658 RID: 5720
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
