using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactuable
{
    [SerializeField] private int nextSceneIndex;
    [SerializeField] private Vector3 nextScenePosition;
    [SerializeField] private Vector2 nextSceneOrientation;
    [SerializeField] private GameManagerSO gameManager;

    public void Interact()
    {
        Debug.Log("puerrtaa");
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            gameManager.LoadNewScene(nextScenePosition, nextSceneOrientation, nextSceneIndex);
        }
    }
}
