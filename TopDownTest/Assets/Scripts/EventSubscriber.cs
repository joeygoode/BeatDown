using UnityEngine;

using SonicBloom.Koreo;

public class EventSubscriber: MonoBehaviour {

	public bool onBeat = false;


	//Usethisforinitialization
	
	void Start()
		
	{
		
		Koreographer.Instance.RegisterForEvents("BeatDownEvents",FireEventDebugLog);
	
	}
	
	void FireEventDebugLog(KoreographyEvent koreoEvent)
		
	{
		
		Debug.Log("KoreographyEventFired.");
		if (onBeat == true) {
			onBeat = false;
		}
		else {
			onBeat = true;
		}
		
	}
	
}