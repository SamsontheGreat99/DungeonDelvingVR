using Normal.Realtime;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;


//https://jeffrafter.com/unity-multiplayer-vr-with-normcore/?msclkid=94dd144ac41f11ec84ca4bbd39a282d0
public class GMAttributesSync : RealtimeComponent<AvatarAttributesModel>
{
    public TextMeshProUGUI playerNameText;

    public string playerName;

    //make a name list
    private List<string> nameList = new List<string>();

    private bool _isSelf;

    public string Nickname => model.nickname;

    private void Start()
    {
        if (GetComponent<RealtimeAvatar>().isOwnedLocallyInHierarchy)
        {
            _isSelf = true;

            
            //get the text component
            //nameText = GetComponent<TextMeshProUGUI>();
            //set the text to the name
            playerName = "GM";
            // Assign the nickname to the model which will automatically be sent to the server and broadcast to other clients
            model.nickname = playerName;

        }
    }

    protected override void OnRealtimeModelReplaced(AvatarAttributesModel previousModel, AvatarAttributesModel currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.nicknameDidChange -= NicknameDidChange;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.nickname = "";
            }

            UpdatePlayerName();

            currentModel.nicknameDidChange += NicknameDidChange;
        }
    }

    private void NicknameDidChange(AvatarAttributesModel model, string nickname)
    {
        UpdatePlayerName();
    }

    private void UpdatePlayerName()
    {
        // Update the UI
        playerNameText.text = model.nickname;
    }
}