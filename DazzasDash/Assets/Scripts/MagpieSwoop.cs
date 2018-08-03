using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagpieSwoop : MonoBehaviour
{

	Transform dazzaTransform;

    LevelGeneration levelGeneration;

    Vector3 verticalVelocity = Vector3.zero;

    bool hasSwooped = false;


	void Start ()
	{
        levelGeneration = transform.parent.GetComponent<LevelGeneration>();
		dazzaTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();

		Destroy(gameObject,10);
	}
	
	
	void FixedUpdate ()
	{
        CheckSwoop();
		Swoop();
	}

	void Swoop()
	{
        if (hasSwooped == false)
        {
            if(transform.position.y <= dazzaTransform.position.y + 3f)
            {
                verticalVelocity = new Vector3(0f, Mathf.Lerp(verticalVelocity.y, 0f, 0.05f), 0f);
            }
            else
            {
                verticalVelocity = new Vector3(0f, Mathf.Lerp(verticalVelocity.y, -levelGeneration.GetScrollSpeed(), 0.01f), 0f);
            }
        }
        else
        {
            verticalVelocity = new Vector3(0f, Mathf.Lerp(verticalVelocity.y, levelGeneration.GetScrollSpeed(), 0.05f), 0f);
        }

        transform.position += verticalVelocity * Time.deltaTime;
    }


    void CheckSwoop()
    {
        if (transform.position.y > dazzaTransform.position.y)
        {
            if(transform.position.x >= dazzaTransform.position.x)
            {
                hasSwooped = false;
            }
        }
        else
        {
            if(transform.position.x <= dazzaTransform.position.x)
            {
                hasSwooped = true;
            }
        }

        Debug.Log(hasSwooped);
    }
}
