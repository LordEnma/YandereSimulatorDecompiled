using System;
using UnityEngine;

// Token: 0x02000226 RID: 550
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/AuraDistortion")]
public class CameraFilterPack_Vision_AuraDistortion : MonoBehaviour
{
	// Token: 0x1700032A RID: 810
	// (get) Token: 0x060011C7 RID: 4551 RVA: 0x0008959C File Offset: 0x0008779C
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

	// Token: 0x060011C8 RID: 4552 RVA: 0x000895D0 File Offset: 0x000877D0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_AuraDistortion");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011C9 RID: 4553 RVA: 0x000895F4 File Offset: 0x000877F4
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
			this.material.SetFloat("_Value", this.Twist);
			this.material.SetColor("_Value2", this.Color);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetFloat("_Value5", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011CA RID: 4554 RVA: 0x00089702 File Offset: 0x00087902
	private void Update()
	{
	}

	// Token: 0x060011CB RID: 4555 RVA: 0x00089704 File Offset: 0x00087904
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400165E RID: 5726
	public Shader SCShader;

	// Token: 0x0400165F RID: 5727
	private float TimeX = 1f;

	// Token: 0x04001660 RID: 5728
	private Material SCMaterial;

	// Token: 0x04001661 RID: 5729
	[Range(0f, 2f)]
	public float Twist = 1f;

	// Token: 0x04001662 RID: 5730
	[Range(-4f, 4f)]
	public float Speed = 1f;

	// Token: 0x04001663 RID: 5731
	public Color Color = new Color(0.16f, 0.57f, 0.19f);

	// Token: 0x04001664 RID: 5732
	[Range(-1f, 2f)]
	public float PosX = 0.5f;

	// Token: 0x04001665 RID: 5733
	[Range(-1f, 2f)]
	public float PosY = 0.5f;
}
