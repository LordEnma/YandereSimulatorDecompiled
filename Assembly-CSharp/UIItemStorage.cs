using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000025 RID: 37
[AddComponentMenu("NGUI/Examples/UI Item Storage")]
public class UIItemStorage : MonoBehaviour
{
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000098 RID: 152 RVA: 0x00011777 File Offset: 0x0000F977
	public List<InvGameItem> items
	{
		get
		{
			while (this.mItems.Count < this.maxItemCount)
			{
				this.mItems.Add(null);
			}
			return this.mItems;
		}
	}

	// Token: 0x06000099 RID: 153 RVA: 0x000117A0 File Offset: 0x0000F9A0
	public InvGameItem GetItem(int slot)
	{
		if (slot >= this.items.Count)
		{
			return null;
		}
		return this.mItems[slot];
	}

	// Token: 0x0600009A RID: 154 RVA: 0x000117BE File Offset: 0x0000F9BE
	public InvGameItem Replace(int slot, InvGameItem item)
	{
		if (slot < this.maxItemCount)
		{
			InvGameItem result = this.items[slot];
			this.mItems[slot] = item;
			return result;
		}
		return item;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x000117E4 File Offset: 0x0000F9E4
	private void Start()
	{
		if (this.template != null)
		{
			int num = 0;
			Bounds bounds = default(Bounds);
			for (int i = 0; i < this.maxRows; i++)
			{
				for (int j = 0; j < this.maxColumns; j++)
				{
					GameObject gameObject = base.gameObject.AddChild(this.template);
					gameObject.transform.localPosition = new Vector3((float)this.padding + ((float)j + 0.5f) * (float)this.spacing, (float)(-(float)this.padding) - ((float)i + 0.5f) * (float)this.spacing, 0f);
					UIStorageSlot component = gameObject.GetComponent<UIStorageSlot>();
					if (component != null)
					{
						component.storage = this;
						component.slot = num;
					}
					bounds.Encapsulate(new Vector3((float)this.padding * 2f + (float)((j + 1) * this.spacing), (float)(-(float)this.padding) * 2f - (float)((i + 1) * this.spacing), 0f));
					if (++num >= this.maxItemCount)
					{
						if (this.background != null)
						{
							this.background.transform.localScale = bounds.size;
						}
						return;
					}
				}
			}
			if (this.background != null)
			{
				this.background.transform.localScale = bounds.size;
			}
		}
	}

	// Token: 0x04000270 RID: 624
	public int maxItemCount = 8;

	// Token: 0x04000271 RID: 625
	public int maxRows = 4;

	// Token: 0x04000272 RID: 626
	public int maxColumns = 4;

	// Token: 0x04000273 RID: 627
	public GameObject template;

	// Token: 0x04000274 RID: 628
	public UIWidget background;

	// Token: 0x04000275 RID: 629
	public int spacing = 128;

	// Token: 0x04000276 RID: 630
	public int padding = 10;

	// Token: 0x04000277 RID: 631
	private List<InvGameItem> mItems = new List<InvGameItem>();
}
