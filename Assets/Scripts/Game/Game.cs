using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("General")]
	[SerializeField] public GameMode[] gameModes;
	public PlayerController player;
	
	[Header("Variables")]
	public float maxPlayerHeight;
	
	
	private GameMode mode;
	private GameState state;
	
	private List<Transform> platformPositions = new List<Transform>();
	
	private void Awake()
	{
		SetUpGameModes();
		UpdateGameState();
	}
	
	private void Update()
	{
		PlayerHeightUpdate();
		
		#if UNITY_EDITOR || DYNAMIC_RESOLUTION
		
		#endif
	}
	
	private void SetUpGameModes()
	{
		for(int i = 0; i < gameModes.Length; i++)
			gameModes[i].state = state;
		
		// Add functions manually
		
		// Classic
		gameModes[0].GetNextPlatform = () => ClassicGameMode.GetNextPlatform(mode);
	}
	
	private void PlayerHeightUpdate()
	{
		float diff = player.transform.position.y - maxPlayerHeight;
		if(diff < 0)
			return;
		
		player.SetPlayersYPosition(maxPlayerHeight);
		
		//for(int i = 0; i < platformPositions.Length; i++)
	}

	private void UpdateGameState()
	{
		state.topRightWorldBorder = new Vector2();
	}

	public void SetGameMode()
	{
		platformPositions.Clear();
		
		//for(int i = 0; i < )
	}
}
