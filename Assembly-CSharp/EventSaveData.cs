using System;

// Token: 0x020003FB RID: 1019
[Serializable]
public class EventSaveData
{
	// Token: 0x06001C07 RID: 7175 RVA: 0x00146D0B File Offset: 0x00144F0B
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

	// Token: 0x06001C08 RID: 7176 RVA: 0x00146D49 File Offset: 0x00144F49
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x04003125 RID: 12581
	public bool befriendConversation;

	// Token: 0x04003126 RID: 12582
	public bool event1;

	// Token: 0x04003127 RID: 12583
	public bool event2;

	// Token: 0x04003128 RID: 12584
	public bool kidnapConversation;

	// Token: 0x04003129 RID: 12585
	public bool livingRoom;
}
