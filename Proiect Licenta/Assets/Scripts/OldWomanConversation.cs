using UnityEngine;
using DialogueEditor;

public class OldWomanConversation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public NPCConversation Conversation;
    public GameObject talkPrompt;

    void Start()
    {
        
    }

    // Update is called once per frame
    private bool isPlayerInRange = false;

    void Update()
    {
       
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            talkPrompt.SetActive(false);
            ConversationManager.Instance.StartConversation(Conversation);
        }

        if (ConversationManager.Instance.IsConversationActive && isPlayerInRange)
        {
            talkPrompt.SetActive(false);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                ConversationManager.Instance.SelectPreviousOption();
            
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                ConversationManager.Instance.SelectNextOption();

            else if (Input.GetKeyDown(KeyCode.Return))
                ConversationManager.Instance.PressSelectedOption();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Optional: check it's the player
        {
            isPlayerInRange = true;
            talkPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            talkPrompt.SetActive(false);
        }
    }
}
