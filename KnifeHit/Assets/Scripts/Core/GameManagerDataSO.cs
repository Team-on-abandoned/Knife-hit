using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameManagerDataSO", menuName = "SO/GameManagerDataSO", order = 2)]
public class GameManagerDataSO : ScriptableObject {
	public enum KnifeType : byte { Default, RareBoss, LegendaryBoss, Donate, END}
	public KnifesSetDataSO[] Knifes;

	public Sprite UsedPlayerKnifeSprite;
}
