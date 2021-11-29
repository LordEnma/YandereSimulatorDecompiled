using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000068 RID: 104
[ExecuteInEditMode]
[RequireComponent(typeof(UIToggle))]
[AddComponentMenu("NGUI/Interaction/Toggled Components")]
public class UIToggledComponents : MonoBehaviour
{
	// Token: 0x060002DB RID: 731 RVA: 0x0001ECAC File Offset: 0x0001CEAC
	private void Awake()
	{
		if (this.target != null)
		{
			if (this.activate.Count == 0 && this.deactivate.Count == 0)
			{
				if (this.inverse)
				{
					this.deactivate.Add(this.target);
				}
				else
				{
					this.activate.Add(this.target);
				}
			}
			else
			{
				this.target = null;
			}
		}
		EventDelegate.Add(base.GetComponent<UIToggle>().onChange, new EventDelegate.Callback(this.Toggle));
	}

	// Token: 0x060002DC RID: 732 RVA: 0x0001ED34 File Offset: 0x0001CF34
	public void Toggle()
	{
		if (base.enabled)
		{
			for (int i = 0; i < this.activate.Count; i++)
			{
				this.activate[i].enabled = UIToggle.current.value;
			}
			for (int j = 0; j < this.deactivate.Count; j++)
			{
				this.deactivate[j].enabled = !UIToggle.current.value;
			}
		}
	}

	// Token: 0x0400045F RID: 1119
	public List<MonoBehaviour> activate;

	// Token: 0x04000460 RID: 1120
	public List<MonoBehaviour> deactivate;

	// Token: 0x04000461 RID: 1121
	[HideInInspector]
	[SerializeField]
	private MonoBehaviour target;

	// Token: 0x04000462 RID: 1122
	[HideInInspector]
	[SerializeField]
	private bool inverse;
}
