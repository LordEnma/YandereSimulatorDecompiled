using System;
using UnityEngine;

// Token: 0x02000209 RID: 521
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Broken Glass2")]
public class CameraFilterPack_TV_BrokenGlass2 : MonoBehaviour
{
	// Token: 0x1700030D RID: 781
	// (get) Token: 0x0600111B RID: 4379 RVA: 0x00086DC0 File Offset: 0x00084FC0
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

	// Token: 0x0600111C RID: 4380 RVA: 0x00086DF4 File Offset: 0x00084FF4
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_TV_BrokenGlass_2") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/TV_BrokenGlass2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600111D RID: 4381 RVA: 0x00086E2C File Offset: 0x0008502C
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
			if (this.Bullet_1 < 0f)
			{
				this.Bullet_1 = 0f;
			}
			if (this.Bullet_2 < 0f)
			{
				this.Bullet_2 = 0f;
			}
			if (this.Bullet_3 < 0f)
			{
				this.Bullet_3 = 0f;
			}
			if (this.Bullet_4 < 0f)
			{
				this.Bullet_4 = 0f;
			}
			if (this.Bullet_5 < 0f)
			{
				this.Bullet_5 = 0f;
			}
			if (this.Bullet_6 < 0f)
			{
				this.Bullet_6 = 0f;
			}
			if (this.Bullet_7 < 0f)
			{
				this.Bullet_7 = 0f;
			}
			if (this.Bullet_8 < 0f)
			{
				this.Bullet_8 = 0f;
			}
			if (this.Bullet_9 < 0f)
			{
				this.Bullet_9 = 0f;
			}
			if (this.Bullet_10 < 0f)
			{
				this.Bullet_10 = 0f;
			}
			if (this.Bullet_11 < 0f)
			{
				this.Bullet_11 = 0f;
			}
			if (this.Bullet_12 < 0f)
			{
				this.Bullet_12 = 0f;
			}
			if (this.Bullet_1 > 1f)
			{
				this.Bullet_1 = 1f;
			}
			if (this.Bullet_2 > 1f)
			{
				this.Bullet_2 = 1f;
			}
			if (this.Bullet_3 > 1f)
			{
				this.Bullet_3 = 1f;
			}
			if (this.Bullet_4 > 1f)
			{
				this.Bullet_4 = 1f;
			}
			if (this.Bullet_5 > 1f)
			{
				this.Bullet_5 = 1f;
			}
			if (this.Bullet_6 > 1f)
			{
				this.Bullet_6 = 1f;
			}
			if (this.Bullet_7 > 1f)
			{
				this.Bullet_7 = 1f;
			}
			if (this.Bullet_8 > 1f)
			{
				this.Bullet_8 = 1f;
			}
			if (this.Bullet_9 > 1f)
			{
				this.Bullet_9 = 1f;
			}
			if (this.Bullet_10 > 1f)
			{
				this.Bullet_10 = 1f;
			}
			if (this.Bullet_11 > 1f)
			{
				this.Bullet_11 = 1f;
			}
			if (this.Bullet_12 > 1f)
			{
				this.Bullet_12 = 1f;
			}
			this.material.SetFloat("_Bullet_1", this.Bullet_1);
			this.material.SetFloat("_Bullet_2", this.Bullet_2);
			this.material.SetFloat("_Bullet_3", this.Bullet_3);
			this.material.SetFloat("_Bullet_4", this.Bullet_4);
			this.material.SetFloat("_Bullet_5", this.Bullet_5);
			this.material.SetFloat("_Bullet_6", this.Bullet_6);
			this.material.SetFloat("_Bullet_7", this.Bullet_7);
			this.material.SetFloat("_Bullet_8", this.Bullet_8);
			this.material.SetFloat("_Bullet_9", this.Bullet_9);
			this.material.SetFloat("_Bullet_10", this.Bullet_10);
			this.material.SetFloat("_Bullet_11", this.Bullet_11);
			this.material.SetFloat("_Bullet_12", this.Bullet_12);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600111E RID: 4382 RVA: 0x000871FD File Offset: 0x000853FD
	private void Update()
	{
	}

	// Token: 0x0600111F RID: 4383 RVA: 0x000871FF File Offset: 0x000853FF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015BA RID: 5562
	public Shader SCShader;

	// Token: 0x040015BB RID: 5563
	private float TimeX = 1f;

	// Token: 0x040015BC RID: 5564
	[Range(0f, 1f)]
	public float Bullet_1;

	// Token: 0x040015BD RID: 5565
	[Range(0f, 1f)]
	public float Bullet_2;

	// Token: 0x040015BE RID: 5566
	[Range(0f, 1f)]
	public float Bullet_3;

	// Token: 0x040015BF RID: 5567
	[Range(0f, 1f)]
	public float Bullet_4 = 1f;

	// Token: 0x040015C0 RID: 5568
	[Range(0f, 1f)]
	public float Bullet_5;

	// Token: 0x040015C1 RID: 5569
	[Range(0f, 1f)]
	public float Bullet_6;

	// Token: 0x040015C2 RID: 5570
	[Range(0f, 1f)]
	public float Bullet_7;

	// Token: 0x040015C3 RID: 5571
	[Range(0f, 1f)]
	public float Bullet_8;

	// Token: 0x040015C4 RID: 5572
	[Range(0f, 1f)]
	public float Bullet_9;

	// Token: 0x040015C5 RID: 5573
	[Range(0f, 1f)]
	public float Bullet_10;

	// Token: 0x040015C6 RID: 5574
	[Range(0f, 1f)]
	public float Bullet_11;

	// Token: 0x040015C7 RID: 5575
	[Range(0f, 1f)]
	public float Bullet_12;

	// Token: 0x040015C8 RID: 5576
	private Material SCMaterial;

	// Token: 0x040015C9 RID: 5577
	private Texture2D Texture2;
}
