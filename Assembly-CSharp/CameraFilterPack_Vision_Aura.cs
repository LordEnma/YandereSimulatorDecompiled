using System;
using UnityEngine;

// Token: 0x02000225 RID: 549
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Aura")]
public class CameraFilterPack_Vision_Aura : MonoBehaviour
{
	// Token: 0x17000329 RID: 809
	// (get) Token: 0x060011C1 RID: 4545 RVA: 0x000893B4 File Offset: 0x000875B4
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

	// Token: 0x060011C2 RID: 4546 RVA: 0x000893E8 File Offset: 0x000875E8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Aura");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011C3 RID: 4547 RVA: 0x0008940C File Offset: 0x0008760C
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

	// Token: 0x060011C4 RID: 4548 RVA: 0x0008951A File Offset: 0x0008771A
	private void Update()
	{
	}

	// Token: 0x060011C5 RID: 4549 RVA: 0x0008951C File Offset: 0x0008771C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001656 RID: 5718
	public Shader SCShader;

	// Token: 0x04001657 RID: 5719
	private float TimeX = 1f;

	// Token: 0x04001658 RID: 5720
	private Material SCMaterial;

	// Token: 0x04001659 RID: 5721
	[Range(0f, 2f)]
	public float Twist = 1f;

	// Token: 0x0400165A RID: 5722
	[Range(-4f, 4f)]
	public float Speed = 1f;

	// Token: 0x0400165B RID: 5723
	public Color Color = new Color(0.16f, 0.57f, 0.19f);

	// Token: 0x0400165C RID: 5724
	[Range(-1f, 2f)]
	public float PosX = 0.5f;

	// Token: 0x0400165D RID: 5725
	[Range(-1f, 2f)]
	public float PosY = 0.5f;
}
