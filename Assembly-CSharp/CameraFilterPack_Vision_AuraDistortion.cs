using System;
using UnityEngine;

// Token: 0x02000226 RID: 550
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/AuraDistortion")]
public class CameraFilterPack_Vision_AuraDistortion : MonoBehaviour
{
	// Token: 0x1700032A RID: 810
	// (get) Token: 0x060011C7 RID: 4551 RVA: 0x00089340 File Offset: 0x00087540
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

	// Token: 0x060011C8 RID: 4552 RVA: 0x00089374 File Offset: 0x00087574
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_AuraDistortion");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011C9 RID: 4553 RVA: 0x00089398 File Offset: 0x00087598
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

	// Token: 0x060011CA RID: 4554 RVA: 0x000894A6 File Offset: 0x000876A6
	private void Update()
	{
	}

	// Token: 0x060011CB RID: 4555 RVA: 0x000894A8 File Offset: 0x000876A8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001655 RID: 5717
	public Shader SCShader;

	// Token: 0x04001656 RID: 5718
	private float TimeX = 1f;

	// Token: 0x04001657 RID: 5719
	private Material SCMaterial;

	// Token: 0x04001658 RID: 5720
	[Range(0f, 2f)]
	public float Twist = 1f;

	// Token: 0x04001659 RID: 5721
	[Range(-4f, 4f)]
	public float Speed = 1f;

	// Token: 0x0400165A RID: 5722
	public Color Color = new Color(0.16f, 0.57f, 0.19f);

	// Token: 0x0400165B RID: 5723
	[Range(-1f, 2f)]
	public float PosX = 0.5f;

	// Token: 0x0400165C RID: 5724
	[Range(-1f, 2f)]
	public float PosY = 0.5f;
}
