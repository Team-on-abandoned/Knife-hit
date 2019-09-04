using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New KnifesSetDataSO", menuName = "SO/KnifesSetData", order = 3)]
public class KnifesSetDataSO : ScriptableObject {
	//TODO: IsOpened load/save to playerPrefs
	//TODO: price for donate read from firebase on shop screen
	public Sprite[] Sprites;
	public bool[] IsOpened;
}
