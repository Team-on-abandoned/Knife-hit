using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameMangerDataSO", menuName = "SO/GameMangerData", order = 2)]
public class GameMangerDataSO : ScriptableObject {
	public enum KnifeType : byte { Default, RareBoss, LegendaryBoss, Donate, END}
	public KnifesSetDataSO[] Knifes;

	public Sprite UsedPlayerKnifeSprite;
}
