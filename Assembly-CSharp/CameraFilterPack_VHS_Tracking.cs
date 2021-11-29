using System;
using UnityEngine;

// Token: 0x02000223 RID: 547
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/Tracking")]
public class CameraFilterPack_VHS_Tracking : MonoBehaviour
{
	// Token: 0x17000328 RID: 808
	// (get) Token: 0x060011B7 RID: 4535 RVA: 0x00088CCB File Offset: 0x00086ECB
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

	// Token: 0x060011B8 RID: 4536 RVA: 0x00088CFF File Offset: 0x00086EFF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/VHS_Tracking");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011B9 RID: 4537 RVA: 0x00088D20 File Offset: 0x00086F20
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
			this.material.SetFloat("_Value", this.Tracking);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011BA RID: 4538 RVA: 0x00088DD6 File Offset: 0x00086FD6
	private void Update()
	{
	}

	// Token: 0x060011BB RID: 4539 RVA: 0x00088DD8 File Offset: 0x00086FD8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001641 RID: 5697
	public Shader SCShader;

	// Token: 0x04001642 RID: 5698
	private float TimeX = 1f;

	// Token: 0x04001643 RID: 5699
	private Material SCMaterial;

	// Token: 0x04001644 RID: 5700
	[Range(0f, 2f)]
	public float Tracking = 1f;
}
