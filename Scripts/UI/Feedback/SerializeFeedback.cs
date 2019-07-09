using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SerializeFeedback
{
	string DirectoryPath = "Feedback";
	DateTime dateTime;
	FeedbackList feedbackList;
	string date;

    public SerializeFeedback()
    {
		dateTime = DateTime.Today;
		date = string.Format("{0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
		try
		{
			feedbackList = deserializeFeedback();
		}
		catch
		{
			feedbackList = new FeedbackList();
		}
    }

	public void AddFeedbackEntry(FeedbackEntry feedbackEntry)
	{
		feedbackList.AddEntry(feedbackEntry);
	}

	public void RemoveFeedbackEntry(FeedbackEntry entry)
	{
		feedbackList.RemoveEntry(entry);
	}

	public void Serialize()
	{
		
		Directory.CreateDirectory(DirectoryPath);
		using (StreamWriter writer = new StreamWriter(DirectoryPath + "\\" + date + ".json"))
		{
			string entry = JsonUtility.ToJson(feedbackList,true);
			writer.Write(entry);
		}
	}

	FeedbackList deserializeFeedback()
	{
		string FilePath = DirectoryPath + "\\" + date + ".json";

		using (StreamReader stream = new StreamReader(FilePath))
		{
			string json = stream.ReadToEnd();
			return JsonUtility.FromJson<FeedbackList>(json);
		}
	}
}
