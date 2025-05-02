using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ComputerTerminal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public GameObject minigameCanvas; // Drag your UI Canvas here
     public TMP_InputField passwordInput;
    public TMP_Text hintText;
    public TMP_Text triesText;
    private string correctPassword = "UNITY";
    private int triesLeft = 5;
    private bool isPlayerInRange = false;

    void Start()
    {
        triesText.text = "Tries Left: " + triesLeft;
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenMinigame();
        }
    }

     public void SubmitPassword()
    {
        string guess = passwordInput.text.ToUpper();

        if (guess == correctPassword)
        {
            hintText.text = "Access Granted! The code to the lock is 1234";
            // You could trigger a success event here
        }
        else
        {
            triesLeft--;
            triesText.text = "Tries Left: " + triesLeft;

            // Give a hint
            int correctLetters = CountCorrectLetters(guess, correctPassword);
            hintText.text = "Wrong! " + correctLetters + " letters correct.";

            if (triesLeft <= 0)
            {
                hintText.text = "Access Denied. System Locked.";
                passwordInput.interactable = false;
                // Optionally lock further input
            }
        }

        passwordInput.text = ""; // Clear after each try
    }

    int CountCorrectLetters(string guess, string password)
    {
        int count = 0;
        int length = Mathf.Min(guess.Length, password.Length);

        for (int i = 0; i < length; i++)
        {
            if (guess[i] == password[i])
            {
                count++;
            }
        }

        return count;
    }

    public void ExitMinigame()
    {
        minigameCanvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void OpenMinigame()
    {
        minigameCanvas.SetActive(true);
        // Optionally: Lock player movement here
        Time.timeScale = 0f; // Optional: pause the game if you want
        Cursor.lockState = CursorLockMode.None; // Unlock the mouse
        Cursor.visible = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            // Optional: show "Press E to use computer" text
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}
