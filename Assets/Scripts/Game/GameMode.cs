using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Platform
{
	public Platform(GameObject newPrefab) => prefab = newPrefab;
	public Platform(GameObject newPrefab, Vector3 newPosition) => (prefab, position) = (newPrefab, newPosition);
	public Platform(GameObject newPrefab, Vector3 newPosition, Quaternion newRotation) => (prefab, position, rotation) = (newPrefab, newPosition, newRotation);
	
	public GameObject prefab = null;
	public Vector3 position = Vector3.zero;
	public Quaternion rotation = Quaternion.identity;
}

public class GameState
{
	// left and bottom we can find by negating this
	public Vector2 topRightWorldBorder = Vector2.zero;
}

[Serializable]
public class GameMode
{
	public string name; // It's more like a help for developing rather then realy needed function
	public float platformsDensity;
	public GameObject[] paltforms;
	// This could be virtual function but we are initializing game modes in Inspector so we need to use function pointer
	public Func<Platform> GetNextPlatform;
	public GameState state;
}

// We use classes because in c# aperrently static variables in methods are not allowed and they meight be needed
public static class ClassicGameMode
{
	// I could've made it through ScriptableObjects, but it's not worth the effort
	// If they'll need to be dynamic I'll change them through some script directly
	
	// Constants
	private static readonly int[] platformChances =
	{
		100
	};
	
	public static Platform GetNextPlatform(GameMode mode)
	{
		int platform = 0;
		return new Platform(mode.paltforms[platform]);
	}
}