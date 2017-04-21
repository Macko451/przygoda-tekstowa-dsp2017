using UnityEngine;
using System.Collections;

[System.Serializable] // pomimo, że skrypt nie jest nigdzie podpięty, zmienne dziedziczone z tej klasy będą widoczne w inspektorze

// nie dziedziczymy z MonoBehaviour, gdyż nie chcemy, aby ten skrypt był komponentem, nie będzie podpięty pod żaden obiekt
public class TowerBlueprint 
{
	public GameObject prefab;
	public int cost;
}
