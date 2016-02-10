using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class Lang : Singleton<Lang>
{
	private Dictionary<string, string> _gameTexts;
	
	// Initialisation du gestionnaire de langues
	void Awake()
	{
		string lang = Application.systemLanguage.ToString();
		string jsonString = string.Empty;
		
		if (lang == "French")
			jsonString = Resources.Load<TextAsset>("lang.fr").text;
		else
			jsonString = Resources.Load<TextAsset>("lang.en").text;
		
		JSONNode json = JSON.Parse(jsonString);
		int size = json.Count;
		
		_gameTexts = new Dictionary<string, string>(size);
		
		JSONArray array;
		for (int i = 0; i < size; i++)
		{
			array = json[i].AsArray;
			_gameTexts.Add(array[0].Value, array[1].Value);
		}
	}
	
	// Alias court à Lang.Instance.Get(key)
	public static string Get(string key)
	{
		return Instance.GetText(key);
	}
	
	// Récupère la chaine ayant pour clé key.
	public string GetText(string key)
	{
		if (_gameTexts.ContainsKey(key))
			return _gameTexts[key];
		
		return key;
	}
}