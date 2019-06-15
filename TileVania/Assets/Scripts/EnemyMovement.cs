using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] float moveSpeed = 1f;

    /// <summary>
    /// 
    /// </summary>
    Rigidbody2D myRigidBody;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (IsFacingRight())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)),1f);
    }
}
