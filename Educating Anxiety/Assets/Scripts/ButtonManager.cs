using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Animations;


public class ButtonManager : MonoBehaviour
{
    //game objects for button objects
    public GameObject spaceBar;
    public GameObject fKey;
    public GameObject jKey;
    public GameObject eKey;
    public GameObject iKey;
    public GameObject qKey;
    public GameObject pKey;

    //gif variables
    public GameObject squareBreathingGif;
    private Animator squareAnim;
    private float animationSpeed;
    private int coroutineCount;

    //bools for pressing logic
    bool isSpacePressed = false;
    bool isJPressed = false;
    bool isFPressed = false;
    bool isEPressed = false;
    bool isIPressed = false;
    bool isQPressed = false;
    bool isPPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        squareAnim = squareBreathingGif.GetComponent<Animator>();
        animationSpeed = squareAnim.speed;
        squareAnim.speed = 0;
        coroutineCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(coroutineCount);

        //to deselect buttons incase user clicks with mouse
        if (Input.GetMouseButtonUp(0))
        {
            spaceBar.GetComponent<Button>().OnDeselect(null);
        }

        SpaceIsPressed();
        FandJkeys();
        EandIkeys();
        QandPkeys();
        RequirementsForGrounding();

    }

   
    private void SpaceIsPressed()
    {
        //interaction logic for if space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed = true;
            spaceBar.GetComponent<Button>().interactable = false;
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpacePressed = false;
            spaceBar.GetComponent<Button>().interactable = true;
        }

        //keep next keys disabled
        if (isSpacePressed == false)
        {
            fKey.SetActive(false);
            jKey.SetActive(false);
        }

    }

    private void FandJkeys()
    {

        //interaction logic for if F is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFPressed = true;
            fKey.GetComponent<Button>().interactable = false;
        }

        else if (Input.GetKeyUp(KeyCode.F))
        {
            isFPressed = false;
            fKey.GetComponent<Button>().interactable = true;
        }

        //interaction logic for if J is pressed
        if (Input.GetKeyDown(KeyCode.J))
        {
            isJPressed = true;
            jKey.GetComponent<Button>().interactable = false;
        }

        else if (Input.GetKeyUp(KeyCode.J))
        {
            isJPressed = false;
            jKey.GetComponent<Button>().interactable = true;
        }

        //keep next keys disabled
        if ((isSpacePressed == false) && (isFPressed == false) && (isJPressed == false))
        {
            eKey.SetActive(false);
            iKey.SetActive(false);
        }

    }

    private void EandIkeys ()
    {
        //interaction logic for if E is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
            eKey.GetComponent<Button>().interactable = false;
        }

        else if (Input.GetKeyUp(KeyCode.E))
        {
            isEPressed = false;
            eKey.GetComponent<Button>().interactable = true;
        }

        //interaction logic for if I is pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            isIPressed = true;
            iKey.GetComponent<Button>().interactable = false;
        }

        else if (Input.GetKeyUp(KeyCode.I))
        {
            isIPressed = false;
            iKey.GetComponent<Button>().interactable = true;
        }

        //keep next keys disabled
        if ((isSpacePressed == false) && (isFPressed == false) && (isJPressed == false) && (isEPressed == false) && (isIPressed == false))
        {
            qKey.SetActive(false);
            pKey.SetActive(false);
        }

    }

    private void QandPkeys()
    {
        //interaction logic for if Q is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isQPressed = true;
            qKey.GetComponent<Button>().interactable = false;
        }

        else if (Input.GetKeyUp(KeyCode.Q))
        {
            isQPressed = false;
            qKey.GetComponent<Button>().interactable = true;
        }


        //interaction logic for if P is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPPressed = true;
            pKey.GetComponent<Button>().interactable = false;
        }

        else if (Input.GetKeyUp(KeyCode.P))
        {
            isPPressed = false;
            pKey.GetComponent<Button>().interactable = true;
        }
       
    }

    private void RequirementsForGrounding()
    {
       
        //first phase
        if ((isSpacePressed == true) && (isFPressed == false) && (isJPressed == false) && (isEPressed == false) && (isIPressed == false) && (isQPressed == false) && (isPPressed == false) && (coroutineCount == 0))
        {
            StartCoroutine(ContinueGrounding());
        }

        if ((isSpacePressed == true) && (isFPressed == true) && (isJPressed == true) && (isEPressed == false) && (isIPressed == false) && (isQPressed == false) && (isPPressed == false) && (coroutineCount == 1))
        {
            StartCoroutine(ContinueGrounding());
        }

        if ((isSpacePressed == true) && (isFPressed == true) && (isJPressed == true) && (isEPressed == true) && (isIPressed == true) && (isQPressed == false) && (isPPressed == false) && (coroutineCount == 2))
        {
            StartCoroutine(ContinueGrounding());
        }

        //middle phase
        if ((isSpacePressed == true) && (isFPressed == true) && (isJPressed == true) && (isEPressed == true) && (isIPressed == true) && (isQPressed == true) && (isPPressed == true) && (coroutineCount == 3))
        {
            StartCoroutine(MiddleOfGrounding());
        }

        //release phase
        if ((isSpacePressed == true) && (isFPressed == true) && (isJPressed == true) && (isEPressed == true) && (isIPressed == true) && (isQPressed == false) && (isPPressed == false) && (coroutineCount == 4))
        {
            StartCoroutine(ContinueGrounding());
        }

        if ((isSpacePressed == true) && (isFPressed == true) && (isJPressed == true) && (isEPressed == false) && (isIPressed == false) && (isQPressed == false) && (isPPressed == false) && (coroutineCount == 5))
        {
            StartCoroutine(ContinueGrounding());
        }

        if ((isSpacePressed == true) && (isFPressed == false) && (isJPressed == false) && (isEPressed == false) && (isIPressed == false) && (isQPressed == false) && (isPPressed == false) && (coroutineCount == 6))
        {
            StartCoroutine(ContinueGrounding());
        }

        if ((isSpacePressed == false) && (isFPressed == false) && (isJPressed == false) && (isEPressed == false) && (isIPressed == false) && (isQPressed == false) && (isPPressed == false) && (coroutineCount == 7))
        {
            StartCoroutine(MiddleOfGrounding());
        }

        //resets breathing to base state if player does not follow inputs
        if ((isSpacePressed == false) && (isFPressed == false) && (isJPressed == false) && (isEPressed == false) && (isIPressed == false) && (isQPressed == false) && (isPPressed == false) && (coroutineCount != 8))
        {
            squareAnim.Rebind();
            squareAnim.Update(0f);
            coroutineCount = 0;
        }

    }



    IEnumerator ContinueGrounding()
    {

        //increase coroutine count for progression requirements
        coroutineCount++;
        //progress animation by 1 seconds
        squareAnim.speed = 1;
        yield return new WaitForSeconds(1);
        //halt animation
        squareAnim.speed = 0;


        //enable next keys f and j
        if ((isSpacePressed == true) && (coroutineCount < 4))
        {
            fKey.SetActive(true);
            jKey.SetActive(true);

        }
        //re-disable keys f and j
        else if ((isSpacePressed == true) && (isFPressed == false) && (isJPressed == false) && (isEPressed == false) && (isIPressed == true) && (isQPressed == false) && (isPPressed == false) && (coroutineCount > 4))
        {
            fKey.SetActive(false);
            jKey.SetActive(false);
        }


        //enable next keys e and i
        if ((isSpacePressed == true) && (isFPressed == true) && (isJPressed == true) && (coroutineCount < 4))
        {

            eKey.SetActive(true);
            iKey.SetActive(true);

        }
        //re-disable keys e and i
        else if ((isSpacePressed == true) && (isFPressed == true) && (isJPressed == true) && (isEPressed == false) && (isIPressed == false) && (isQPressed == false) && (isPPressed == false) && (coroutineCount > 4))
        {
            eKey.SetActive(false);
            iKey.SetActive(false);
        }


        //enable next keys q and p
        if ((isSpacePressed == true) && (isFPressed == true) && (isJPressed == true) && (isEPressed == true) && (isIPressed == true) && (coroutineCount < 4))
        {

            qKey.SetActive(true);
            pKey.SetActive(true);

        }
        //re-disable keys q and p
        else if ((isSpacePressed == true) && (isFPressed == true) && (isJPressed == true) && (isEPressed == true) && (isIPressed == true) && (isQPressed == false) && (isPPressed == false) && (coroutineCount > 4))
        {
            qKey.SetActive(false);
            pKey.SetActive(false);
        }
    }

    IEnumerator MiddleOfGrounding()
    {
        //increase coroutine count for progression requirements
        coroutineCount++;
        //progress animation by 5 seconds
        squareAnim.speed = 1;
        yield return new WaitForSeconds(5.2f);
        //halt animation
        squareAnim.speed = 0;
       
    }


}
