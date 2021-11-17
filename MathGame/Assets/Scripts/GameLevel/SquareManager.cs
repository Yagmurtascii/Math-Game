using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SquareManager : MonoBehaviour
{
    [SerializeField]
    private GameObject squareprefab;

    [SerializeField]
    private Transform squarepanel;

    [SerializeField]
    private Transform questionpanel;

    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Button refresh;

    [SerializeField]
    private GameObject finishPanel;

    [SerializeField]
    AudioSource audioSource;

    public AudioClip correctanswerbutton,wronganswerbutton;
    PointManager pointManager;

    GameObject[] squares = new GameObject[25]; //25 elemanlý dize
    List<int> valuelist = new List<int>();
    int number1, number2,operation,valuebutton,correctResult=0,whichquestion;
    bool buttonclick;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        finishPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        pointManager = Object.FindObjectOfType<PointManager>();
    }
    void Start()
    {
        buttonclick = false;
        questionpanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        CreateSquare();
    }
    public void CreateSquare()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject square = Instantiate(squareprefab, squarepanel); // Çoðaltma nesnesidir. Çoðaltýlacak nesne ve çoðaltýcaðý yerleri parametre olarak atadýk (transform--> çoðaltýlan prefablarýn taþýndýðý yer)
            square.transform.GetComponent<Button>().onClick.AddListener(() => clickButton());
            squares[i] = square;
    
        }
        ValueWriteText();
        //StartCoroutine(DoFadeRoutine());
        OpenQuestionPanel();
    }
    void clickButton()
    {
        if (buttonclick)
        {
            valuebutton = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            CheckResult();
        }
    }
    void CheckResult()
    {
        if (valuebutton == correctResult)
        {
            audioSource.PlayOneShot(correctanswerbutton);
            pointManager.TotalIncrease();
            RefreshAll();
        }
        else
        {
            audioSource.PlayOneShot(wronganswerbutton);
            pointManager.DecreaseTotal();
            RefreshAll();
        }
    }
    void ValueWriteText()
    {
        foreach (var square in squares)
        {
            int randomnumber = Random.Range(1, 35);
            valuelist.Add(randomnumber);
            square.transform.GetChild(0).GetComponent<Text>().text = randomnumber.ToString();
        }
    }
    void OpenQuestionPanel()
    {
        AskaQuestion();
        buttonclick = true;
        questionpanel.GetComponent<RectTransform>().DOScale(1, 0f);
    }
    void AskaQuestion()
    {
        number1 = Random.Range(1, 7);
        number2 = Random.Range(1, 5);
        operation = Random.Range(1, 5);
        whichquestion = Random.Range(1, valuelist.Count);
        if (operation == 1)
        {
            correctResult = number1 + number2;
            questionText.text = number1.ToString() + '+' + number2.ToString();
        }
        else if (operation == 2)
        {
            if(number1-number2!=0)
            {
                if (number2 > number1)
                {
                    correctResult = number2 - number1;
                    questionText.text = number2.ToString() + '-' + number1.ToString();
                }
                else
                {
                    correctResult = number1 - number2;
                    questionText.text = number1.ToString() + '-' + number2.ToString();
                }
            }
            else
            {
                number1 = Random.Range(1, 7);
                number2 = Random.Range(1, 5);
            }
        }
        else if (operation == 3)
        {
            correctResult = number2 * number1;
            questionText.text = number1.ToString() + 'x' + number2.ToString();
        }
        else if (operation == 4)
        {
            
            if (number2 > number1)
            {
                if (number2 % number1 == 0)
                {
                    correctResult = number2 / number1;
                    questionText.text = number2.ToString() + ':' + number1.ToString();
                }
                else
                {
                    number1 = Random.Range(1, 5);
                    number2 = Random.Range(1, 7);
                }

            }
            else
            {
                if (number1 % number2 == 0)
                {
                    correctResult = number1 / number2;
                    questionText.text = number1.ToString() + ':' + number2.ToString();
                }
                else
                {
                    number1 = Random.Range(1, 7);
                    number2 = Random.Range(1, 5);
                }            
            }
        }
    }
    public void RefreshBox()
    {
        ValueWriteText();
    }
    public void RefreshAll()
    {
        ValueWriteText();
        AskaQuestion();
    }
}