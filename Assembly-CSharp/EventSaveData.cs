using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class EventSaveData
{
	// Token: 0x06001BF4 RID: 7156 RVA: 0x001458B3 File Offset: 0x00143AB3
	public static EventSaveData ReadFromGlobals()
	{
		return new EventSaveData
		{
			befriendConversation = EventGlobals.BefriendConversation,
			event1 = EventGlobals.Event1,
			event2 = EventGlobals.Event2,
			kidnapConversation = EventGlobals.KidnapConversation,
			livingRoom = EventGlobals.LivingRoom
		};
	}

	// Token: 0x06001BF5 RID: 7157 RVA: 0x001458F1 File Offset: 0x00143AF1
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x04003105 RID: 12549
	public bool befriendConversation;

	// Token: 0x04003106 RID: 12550
	public bool event1;

	// Token: 0x04003107 RID: 12551
	public bool event2;

	// Token: 0x04003108 RID: 12552
	public bool kidnapConversation;

	// Token: 0x04003109 RID: 12553
	public bool livingRoom;
}
