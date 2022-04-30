using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeSkin : MonoBehaviour
{

    public List<GameObject> AllPlayer = new List<GameObject>();
    public List<GameObject> PlayerInGame = new List<GameObject>();
    public List<Button> Select = new List<Button>();
    public Button OpenPenal;
    public Button ClosedPenal;
    public Button BuyPlayerButton;
    public TextMeshProUGUI m_CurrentCoinText;
    public TextMeshProUGUI m_PlayerPrice;
    public GameObject ChangePlayer;

    public GameObject PlayerRoot;
    public GameObject Ground;
    public Character m_Charactor;

    private void Start()
    {
        OpenPenal.onClick.AddListener(OpenPenalm);
        BuyPlayerButton.onClick.AddListener(BuyPlayer);
        ClosedPenal.onClick.AddListener(ClosadPenal);
        for (int i = 0; i < Select.Count; i++)
        {
            Select[i].gameObject.name = AllPlayer[i].name;
        }
        Select.ForEach(x => x.onClick.AddListener(delegate { ClickChangeButton(x.name); }));
        m_PlayerPrice.text = "Select";
    }
    public void ClosadPenal()
    {
        ChangePlayer.SetActive(false);
        PlayerRoot.SetActive(true);
        Ground.SetActive(true);
    }
    public void OpenPenalm()
    {
        ChangePlayer.SetActive(true);
        PlayerRoot.SetActive(false);
        Ground.SetActive(false);
    }
    public void ClickChangeButton(string Button)
    {
        //Debug.Log("Is Clicked _ " + Button);
        AllPlayer.ForEach(x => x.SetActive(false));

        if (m_Dummylist.Find(x => x.name == Button))
        {
            m_PlayerPrice.text = "Select";
            var Charactor = AllPlayer.Find(x => x.name == Button);
            Charactor.SetActive(true);
            Charactor.transform.localPosition = new Vector3(0, -335f, -200f);

        }
        else
        {
            var Charactor = AllPlayer.Find(x => x.name == Button);
            Charactor.SetActive(true);
            Charactor.transform.localPosition = new Vector3(0, -335f, -200f);
            //PlayerInGame.Find(x => x.name == Button).SetActive(true);
            //m_Charactor.SetAnimator();
            switch (Button)
            {
                case "Man_red":
                    //m_PlayerPrice.text = "100";
                    break;
                case "Amazon":
                    // AllPlayer.Find(x => x.name == "Amazon").SetActive(true);
                    m_PlayerPrice.text = "300";
                    break;
                case "Biohazard":
                    //AllPlayer.Find(x => x.name == "Biohazard").SetActive(true);
                    m_PlayerPrice.text = "500";
                    break;
                case "Clown":
                    //AllPlayer.Find(x => x.name == "Clown").SetActive(true);
                    m_PlayerPrice.text = "600";
                    break;
                case "Flaty_Boss":
                    //AllPlayer.Find(x => x.name == "Flaty_Boss").SetActive(true);
                    m_PlayerPrice.text = "700";
                    break;
                case "Goalkeeper":
                    //AllPlayer.Find(x => x.name == "Goalkeeper").SetActive(true);
                    m_PlayerPrice.text = "800";
                    break;
                case "Hero":
                    ///AllPlayer.Find(x => x.name == "Hero").SetActive(true);
                    m_PlayerPrice.text = "500";
                    break;
                case "Repairer":
                    //AllPlayer.Find(x => x.name == "Repairer").SetActive(true);
                    m_PlayerPrice.text = "900";
                    break;
                case "Man":
                    //AllPlayer.Find(x => x.name == "Man").SetActive(true);
                    m_PlayerPrice.text = "1000";
                    break;
                default:
                    break;
            }
        }
    }
    [SerializeField] public List<GameObject> m_Dummylist = new List<GameObject>();
    public void BuyPlayer()
    {
        //  Debug.Log("Is PlayerValue:" + m_PlayerPrice.text);
        int.TryParse(m_PlayerPrice.text, out int buycost);
        int.TryParse(m_CurrentCoinText.text, out int currentcoins);
        //Debug.Log("Type" + buycost.GetType() + "Value" + buycost);
        if (currentcoins >= buycost)
        {
            var after = currentcoins - buycost;
            m_CurrentCoinText.text = after.ToString();
            m_PlayerPrice.text = "Select";
            //Debug.Log("PlayerName" + AllPlayer.Find(x => x.activeInHierarchy).name);
            m_Dummylist.Add(AllPlayer.Find(x => x.activeInHierarchy));
            SetPlayer(AllPlayer.Find(x => x.activeInHierarchy).name);
            //m_PlayerPrice.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not Enogh Coin");
        }
    }
    public void SetPlayer(string l_Name)
    {
        PlayerInGame.ForEach(x => x.SetActive(false));
        Debug.Log(l_Name);
        PlayerInGame.Find(x => x.name == l_Name).SetActive(true);
        //4Debug.Log("Name Of Charactor: "+PlayerInGame.Find(x => x.name == l_Name).name);
        m_Charactor.SetAnimator();
    }
}
