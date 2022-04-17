using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004B1 RID: 1201
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001FA3 RID: 8099 RVA: 0x001BE8F4 File Offset: 0x001BCAF4
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001FA4 RID: 8100 RVA: 0x001BE908 File Offset: 0x001BCB08
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001FA5 RID: 8101 RVA: 0x001BE968 File Offset: 0x001BCB68
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001FA6 RID: 8102 RVA: 0x001BE9A4 File Offset: 0x001BCBA4
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001FA7 RID: 8103 RVA: 0x001BE9A8 File Offset: 0x001BCBA8
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001FA8 RID: 8104 RVA: 0x001BEA0C File Offset: 0x001BCC0C
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004233 RID: 16947
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004234 RID: 16948
	private const string XML_Element = "Element";
}
