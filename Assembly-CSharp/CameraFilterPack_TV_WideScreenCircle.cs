using System;
using UnityEngine;

// Token: 0x0200021F RID: 543
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenCircle")]
public class CameraFilterPack_TV_WideScreenCircle : MonoBehaviour
{
	// Token: 0x17000324 RID: 804
	// (get) Token: 0x0600119F RID: 4511 RVA: 0x00088628 File Offset: 0x00086828
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

	// Token: 0x060011A0 RID: 4512 RVA: 0x0008865C File Offset: 0x0008685C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenCircle");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011A1 RID: 4513 RVA: 0x00088680 File Offset: 0x00086880
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

	// Token: 0x060011A2 RID: 4514 RVA: 0x00088778 File Offset: 0x00086978
	private void Update()
	{
	}

	// Token: 0x060011A3 RID: 4515 RVA: 0x0008877A File Offset: 0x0008697A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001625 RID: 5669
	public Shader SCShader;

	// Token: 0x04001626 RID: 5670
	private float TimeX = 1f;

	// Token: 0x04001627 RID: 5671
	private Material SCMaterial;

	// Token: 0x04001628 RID: 5672
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x04001629 RID: 5673
	[Range(0.01f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x0400162A RID: 5674
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x0400162B RID: 5675
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
