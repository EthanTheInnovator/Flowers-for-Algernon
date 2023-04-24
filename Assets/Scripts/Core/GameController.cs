using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class exposes the the game model in the inspector, and ticks the
/// simulation.
/// </summary> 
public class GameController : MonoBehaviour
{
    [SerializeField] SightMask sightMaskPrefab;
    [SerializeField] PlayerController player;
    [SerializeField] Level level;
    [SerializeField] MazeGenerator mazeGenerator;
    [SerializeField] GameObject blindnessOverlay;
    [SerializeField] int levelNumber;
    public static GameController Instance { get; private set; }
    
    //This model field is public and can be therefore be modified in the 
    //inspector.
    //The reference actually comes from the InstanceRegister, and is shared
    //through the simulation and events. Unity will deserialize over this
    //shared reference when the scene loads, allowing the model to be
    //conveniently configured inside the inspector.
    // public PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    
    void OnEnable()
    {
        Instance = this;
    }
    
    void OnDisable()
    {
        if (Instance == this) Instance = null;
    }

    void Start() {
        if (levelNumber >= 0) {
            level = LevelStore.loadLevel(levelNumber);
        }
        blindnessOverlay.SetActive(level.viewRadius > 0);
        player.maxSpeed = level.playerSpeed;
        mazeGenerator.GenerateMaze(level.mazeSize, level.randomSeed);

        if (level.memoryLength <= 0) {
            SightMask sightMask = Instantiate(sightMaskPrefab, player.transform.position, Quaternion.identity, player.transform);
            sightMask.transform.localScale = new Vector3(level.viewRadius / player.transform.localScale.x, level.viewRadius / player.transform.localScale.y);
        }
    }
    
    void Update()
    {
        if (level.viewRadius > 0) {
            SightMask sightMask = Instantiate(sightMaskPrefab, player.transform.position, Quaternion.identity);
            sightMask.transform.localScale = new Vector3(level.viewRadius, level.viewRadius);
            sightMask.setLiveSeconds(level.memoryLength);
            sightMask.beginDestructionCountdown();
        }
    }
}
