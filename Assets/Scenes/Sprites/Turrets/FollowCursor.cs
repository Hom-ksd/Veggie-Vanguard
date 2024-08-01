using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    [SerializeField]
    private CheckCanBePlaced checkCanBePlaced;

    private ChangeToRed changeToRed;

    private StatusManager status;

    private MoneyManager moneyManager;

    private GameStateManager gameStateManager;

    private void Start()
    {
        checkCanBePlaced = gameObject.GetComponent<CheckCanBePlaced>();

        changeToRed = gameObject.GetComponent<ChangeToRed>();
    
        status = gameObject.GetComponent<StatusManager>();

        moneyManager = FindAnyObjectByType<MoneyManager>();

        gameStateManager = FindAnyObjectByType<GameStateManager>();
    }

    private void Update()
    {
        MoveWithMouse();
        CheckMouseClick();

        if (!changeToRed.getStatus())
        {
            if (!checkCanBePlaced.getCanBePlaced() || status.getOutOfRange())
            {
                changeToRed.ChangeColor();
            }
        }
        else
        {
            if (checkCanBePlaced.getCanBePlaced() && !status.getOutOfRange())
            {
                changeToRed.ChangeOriginal();
            }
        }
    }

    private void MoveWithMouse()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the z coordinate to the object's z coordinate
        mousePosition.z = transform.position.z;

        // Set the object's position to the mouse position
        transform.position = new Vector3(mousePosition.x, mousePosition.y + 0.5f, mousePosition.z);
    }

    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && checkCanBePlaced.getCanBePlaced() && !status.getOutOfRange()) // Left mouse button
        {
            // Remove this script
            status.setPlacedStatus(true);
            status.setIsAttackAble(true);

            Destroy(checkCanBePlaced);
            Destroy(changeToRed);
            Destroy(this);

            gameStateManager.SetBuying(false);
            moneyManager.spendMoney(gameObject.GetComponent<Turret_Display>().GetCost());
        }
        else if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            gameStateManager.SetBuying(false);
            Destroy(gameObject);
        }
    }
}
