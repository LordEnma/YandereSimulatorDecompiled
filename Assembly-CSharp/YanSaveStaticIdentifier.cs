using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040048F6 RID: 18678
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040048F7 RID: 18679
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040048F8 RID: 18680
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
