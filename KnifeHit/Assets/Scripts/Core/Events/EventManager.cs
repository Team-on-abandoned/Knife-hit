using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager {
	public static event EventController.MethodContainer OnTargetHit;
	public void CallOnTargetHit(EventData ob = null) => OnTargetHit?.Invoke(ob);

	public static event EventController.MethodContainer OnKnifeHit;
	public void CallOnKnifeHit(EventData ob = null) => OnKnifeHit?.Invoke(ob);
}
