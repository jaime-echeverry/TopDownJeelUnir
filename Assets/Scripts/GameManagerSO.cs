using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scriptable Objects/GameManager")]
public class GameManagerSO : ScriptableObject
{
    private Player player;
    private InventorySystem inventorySystem;
    private Vector3 initPlayerPosition;
    private Vector2 initPlayerRotation;

    public InventorySystem InventorySystem { get => inventorySystem; set => inventorySystem = value; }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        player = FindObjectOfType<Player>();
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    public void ChangePlayerState(bool state) {
        player.Interacting = !state;
    }

    public void LoadNewScene(Vector3 newPosition, Vector2 newRotation, int newSceneIndex) {
        initPlayerPosition = newPosition;
        initPlayerRotation = newRotation;   
        SceneManager.LoadScene(newSceneIndex);
    }
}
