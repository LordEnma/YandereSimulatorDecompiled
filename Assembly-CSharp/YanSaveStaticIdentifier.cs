using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200050D RID: 1293
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040048C7 RID: 18631
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040048C8 RID: 18632
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040048C9 RID: 18633
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
