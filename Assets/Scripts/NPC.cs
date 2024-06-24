using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour, Interactuable
{
    [SerializeField] private GameManagerSO gameManager;
    [SerializeField, TextArea(1,5)] private string[] phrases;
    [SerializeField] private float timeBetweenCharacters;
    [SerializeField] private GameObject dialogSquare;
    [SerializeField] private TextMeshProUGUI dialogText;
    private bool talking=false;
    private int index = -1;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    public void Interact() {
        gameManager.ChangePlayerState(false);
        dialogSquare.SetActive(true);
        if (!talking)
        {
            NextPhrase();
        }
        else
        {
            CompletePhrase();
        }
    }

    private void CompletePhrase() {
        StopAllCoroutines();
        dialogText.text = phrases[index];
        talking = false;
    }

    private void NextPhrase() {
        index++;
        if (index >= phrases.Length)
        {
            FinishDialog();
        }
        else
        {
            StartCoroutine(writePhrase());  
        }
    }

    private void FinishDialog() {
        talking = false;
        dialogText.text = "";
        index = -1;
        dialogSquare.SetActive(false);
        gameManager.ChangePlayerState(true);
    }

    IEnumerator writePhrase() {
        talking = true;
        dialogText.text = "";
        char[] charactersPhrase = phrases[index].ToCharArray();
        foreach (char c in charactersPhrase) {
            dialogText.text += c;
            yield return new WaitForSeconds(timeBetweenCharacters);
        } 
        talking=false;
    }
}
