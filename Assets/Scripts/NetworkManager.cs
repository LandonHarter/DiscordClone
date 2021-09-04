using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks, IChatClientListener
{

    public static NetworkManager Instance;
    public ChatClient chatClient;
    
    [Header("Auth Values")]
    public string chatAppID;

    [Space] 
    
    [Header("Settings")] 
    
    public string username;

    [Space] 
    
    [Header("Objects")] 
    
    public TMP_InputField messageInput;
    public TMP_Text messages;
    public GameObject applyingPanel;
    public Button joinVCButton;
    public Button createVCButton;
    public GameObject vcNotAvailable;

    private bool hasConnected = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }
    
    void Start()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
        vcNotAvailable.SetActive(true);
        #endif
        
        PhotonNetwork.NickName = string.IsNullOrEmpty(username) ? NameGenerator.GenerateName() : username;
        
        chatClient = new ChatClient(this);
        chatClient.ChatRegion = "US";
        chatClient.Connect(chatAppID, PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.NickName));
    }

    void Update()
    {
        chatClient.Service();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!string.IsNullOrEmpty(messageInput.text))
            {
                chatClient.PublishMessage("General", messageInput.text);
                messageInput.text = "";
            }
        }
    }

    public static void ChangeNickname()
    {
        Instance.chatClient.Disconnect();
        Instance.applyingPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        #if !UNITY_WEBGL
        joinVCButton.interactable = true;
        createVCButton.interactable = true;
        #endif
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        
    }

    public void OnDisconnected()
    {
        chatClient.Connect(chatAppID, PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.NickName));
    }

    public void OnConnected()
    {
        if (hasConnected)
        {
            applyingPanel.SetActive(false);
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        chatClient.Subscribe("General");
        hasConnected = true;
    }

    public void OnChatStateChange(ChatState state)
    {
        
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        string msg = "";
        string sender = "";
        for (int i = 0; i < senders.Length; i++)
        {
            msg = $"{messages[i]}";
            sender = $"{senders[i]}";
        }

        this.messages.text += sender + ": " + msg + "\n";
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        
    }

    public void OnUnsubscribed(string[] channels)
    {
        
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        
    }

    public void OnUserSubscribed(string channel, string user)
    {
        
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        
    }
}