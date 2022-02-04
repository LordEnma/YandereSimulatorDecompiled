using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class EventSaveData
{
	// Token: 0x06001BF5 RID: 7157 RVA: 0x00145DFB File Offset: 0x00143FFB
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

	// Token: 0x06001BF6 RID: 7158 RVA: 0x00145E39 File Offset: 0x00144039
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x0400310C RID: 12556
	public bool befriendConversation;

	// Token: 0x0400310D RID: 12557
	public bool event1;

	// Token: 0x0400310E RID: 12558
	public bool event2;

	// Token: 0x0400310F RID: 12559
	public bool kidnapConversation;

	// Token: 0x04003110 RID: 12560
	public bool livingRoom;
}
