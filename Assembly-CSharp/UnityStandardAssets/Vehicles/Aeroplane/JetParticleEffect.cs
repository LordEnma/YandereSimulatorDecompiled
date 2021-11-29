using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052D RID: 1325
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021BF RID: 8639 RVA: 0x001E88F8 File Offset: 0x001E6AF8
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021C0 RID: 8640 RVA: 0x001E8980 File Offset: 0x001E6B80
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021C1 RID: 8641 RVA: 0x001E8A18 File Offset: 0x001E6C18
		private AeroplaneController FindAeroplaneParent()
		{
			Transform transform = base.transform;
			while (transform != null)
			{
				AeroplaneController component = transform.GetComponent<AeroplaneController>();
				if (!(component == null))
				{
					return component;
				}
				transform = transform.parent;
			}
			throw new Exception(" AeroplaneContoller not found in object hierarchy");
		}

		// Token: 0x04004992 RID: 18834
		public Color minColour;

		// Token: 0x04004993 RID: 18835
		private AeroplaneController m_Jet;

		// Token: 0x04004994 RID: 18836
		private ParticleSystem m_System;

		// Token: 0x04004995 RID: 18837
		private float m_OriginalStartSize;

		// Token: 0x04004996 RID: 18838
		private float m_OriginalLifetime;

		// Token: 0x04004997 RID: 18839
		private Color m_OriginalStartColor;
	}
}
