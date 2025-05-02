using UnityEngine;
using DialogueEditor;

public class LittleBoyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public NPCConversation FirstConversation, NotDoneQuestConversation, FinishedConversation;
    public bool FirstConversationPlayed = true; 
    public bool NotDoneQuestConversationPlayed = true;
    public bool FinishedConversationPlayed = true;
    public GameObject teddybear;
    public GameObject talkPrompt;
    private bool isPlayerInRange = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            talkPrompt.SetActive(false);
            if(FirstConversationPlayed) {
                ConversationManager.Instance.StartConversation(FirstConversation);
                FirstConversationPlayed = false;
            } else if (NotDoneQuestConversationPlayed && teddybear.activeInHierarchy) {
                NotDoneQuestConversationPlayed = false;
                ConversationManager.Instance.StartConversation(NotDoneQuestConversation);
            }
            else if (FinishedConversationPlayed && !teddybear.activeInHierarchy) {
                FinishedConversationPlayed = false;
                ConversationManager.Instance.StartConversation(FinishedConversation);
            }
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
