using System;
using UnityEngine;

// Token: 0x02000225 RID: 549
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Aura")]
public class CameraFilterPack_Vision_Aura : MonoBehaviour
{
	// Token: 0x17000329 RID: 809
	// (get) Token: 0x060011C3 RID: 4547 RVA: 0x00089830 File Offset: 0x00087A30
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

	// Token: 0x060011C4 RID: 4548 RVA: 0x00089864 File Offset: 0x00087A64
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Aura");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011C5 RID: 4549 RVA: 0x00089888 File Offset: 0x00087A88
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

	// Token: 0x060011C6 RID: 4550 RVA: 0x00089996 File Offset: 0x00087B96
	private void Update()
	{
	}

	// Token: 0x060011C7 RID: 4551 RVA: 0x00089998 File Offset: 0x00087B98
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400165D RID: 5725
	public Shader SCShader;

	// Token: 0x0400165E RID: 5726
	private float TimeX = 1f;

	// Token: 0x0400165F RID: 5727
	private Material SCMaterial;

	// Token: 0x04001660 RID: 5728
	[Range(0f, 2f)]
	public float Twist = 1f;

	// Token: 0x04001661 RID: 5729
	[Range(-4f, 4f)]
	public float Speed = 1f;

	// Token: 0x04001662 RID: 5730
	public Color Color = new Color(0.16f, 0.57f, 0.19f);

	// Token: 0x04001663 RID: 5731
	[Range(-1f, 2f)]
	public float PosX = 0.5f;

	// Token: 0x04001664 RID: 5732
	[Range(-1f, 2f)]
	public float PosY = 0.5f;
}
