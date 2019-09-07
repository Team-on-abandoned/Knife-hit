using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager {
	public static event EventController.MethodContainer OnGameStart;
	public void CallOnGameStart(EventData ob = null) => OnGameStart?.Invoke(ob);

	public static event EventController.MethodContainer OnKnifeShoot;
	public void CallOnKnifeShoot(EventData ob = null) => OnKnifeShoot?.Invoke(ob);

	public static event EventController.MethodContainer OnTargetHit;
	public void CallOnTargetHit(EventData ob = null) => OnTargetHit?.Invoke(ob);

	public static event EventController.MethodContainer OnKnifeHit;
	public void CallOnKnifeHit(EventData ob = null) => OnKnifeHit?.Invoke(ob);

	public static event EventController.MethodContainer OnAllKnifesShoot;
	public void CallOnAllKnifesShoot(EventData ob = null) => OnAllKnifesShoot?.Invoke(ob);
}
