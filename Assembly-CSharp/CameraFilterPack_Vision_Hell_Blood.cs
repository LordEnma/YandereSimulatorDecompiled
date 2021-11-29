using System;
using UnityEngine;

// Token: 0x0200022A RID: 554
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Hell_Blood")]
public class CameraFilterPack_Vision_Hell_Blood : MonoBehaviour
{
	// Token: 0x1700032F RID: 815
	// (get) Token: 0x060011E1 RID: 4577 RVA: 0x00089883 File Offset: 0x00087A83
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

	// Token: 0x060011E2 RID: 4578 RVA: 0x000898B7 File Offset: 0x00087AB7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Hell_Blood");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011E3 RID: 4579 RVA: 0x000898D8 File Offset: 0x00087AD8
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
			this.material.SetFloat("_Value", this.Hole_Size);
			this.material.SetFloat("_Value2", this.Hole_Smooth);
			this.material.SetFloat("_Value3", this.Hole_Speed * 15f);
			this.material.SetColor("ColorBlood", this.ColorBlood);
			this.material.SetFloat("_Value4", this.Intensity);
			this.material.SetFloat("BloodAlternative1", this.BloodAlternative1);
			this.material.SetFloat("BloodAlternative2", this.BloodAlternative2);
			this.material.SetFloat("BloodAlternative3", this.BloodAlternative3);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011E4 RID: 4580 RVA: 0x00089A2E File Offset: 0x00087C2E
	private void Update()
	{
	}

	// Token: 0x060011E5 RID: 4581 RVA: 0x00089A30 File Offset: 0x00087C30
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001671 RID: 5745
	public Shader SCShader;

	// Token: 0x04001672 RID: 5746
	private float TimeX = 1f;

	// Token: 0x04001673 RID: 5747
	private Material SCMaterial;

	// Token: 0x04001674 RID: 5748
	[Range(0f, 1f)]
	public float Hole_Size = 0.57f;

	// Token: 0x04001675 RID: 5749
	[Range(0f, 0.5f)]
	public float Hole_Smooth = 0.362f;

	// Token: 0x04001676 RID: 5750
	[Range(-2f, 2f)]
	public float Hole_Speed = 0.85f;

	// Token: 0x04001677 RID: 5751
	[Range(-10f, 10f)]
	public float Intensity = 0.24f;

	// Token: 0x04001678 RID: 5752
	public Color ColorBlood = new Color(1f, 0f, 0f, 1f);

	// Token: 0x04001679 RID: 5753
	[Range(-1f, 1f)]
	public float BloodAlternative1;

	// Token: 0x0400167A RID: 5754
	[Range(-1f, 1f)]
	public float BloodAlternative2;

	// Token: 0x0400167B RID: 5755
	[Range(-1f, 1f)]
	public float BloodAlternative3 = -1f;
}
