using System;
using UnityEngine;

// Token: 0x02000225 RID: 549
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Aura")]
public class CameraFilterPack_Vision_Aura : MonoBehaviour
{
	// Token: 0x17000329 RID: 809
	// (get) Token: 0x060011C0 RID: 4544 RVA: 0x00089008 File Offset: 0x00087208
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

	// Token: 0x060011C1 RID: 4545 RVA: 0x0008903C File Offset: 0x0008723C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Aura");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011C2 RID: 4546 RVA: 0x00089060 File Offset: 0x00087260
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

	// Token: 0x060011C3 RID: 4547 RVA: 0x0008916E File Offset: 0x0008736E
	private void Update()
	{
	}

	// Token: 0x060011C4 RID: 4548 RVA: 0x00089170 File Offset: 0x00087370
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400164A RID: 5706
	public Shader SCShader;

	// Token: 0x0400164B RID: 5707
	private float TimeX = 1f;

	// Token: 0x0400164C RID: 5708
	private Material SCMaterial;

	// Token: 0x0400164D RID: 5709
	[Range(0f, 2f)]
	public float Twist = 1f;

	// Token: 0x0400164E RID: 5710
	[Range(-4f, 4f)]
	public float Speed = 1f;

	// Token: 0x0400164F RID: 5711
	public Color Color = new Color(0.16f, 0.57f, 0.19f);

	// Token: 0x04001650 RID: 5712
	[Range(-1f, 2f)]
	public float PosX = 0.5f;

	// Token: 0x04001651 RID: 5713
	[Range(-1f, 2f)]
	public float PosY = 0.5f;
}
