using System;
using System.Xml.Serialization;

// Token: 0x02000406 RID: 1030
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x04003175 RID: 12661
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x04003176 RID: 12662
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x04003177 RID: 12663
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x04003178 RID: 12664
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x04003179 RID: 12665
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x0400317A RID: 12666
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x0400317B RID: 12667
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x0400317C RID: 12668
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x0400317D RID: 12669
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x0400317E RID: 12670
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x0400317F RID: 12671
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x04003180 RID: 12672
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x04003181 RID: 12673
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x04003182 RID: 12674
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x04003183 RID: 12675
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x04003184 RID: 12676
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x04003185 RID: 12677
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x04003186 RID: 12678
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x04003187 RID: 12679
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x04003188 RID: 12680
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x04003189 RID: 12681
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
