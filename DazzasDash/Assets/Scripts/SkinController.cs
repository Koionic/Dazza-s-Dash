using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    [System.Serializable]
    public struct DazzaAnimationStruct
    {
        public DazzaAnimationState animation;
        public string animationBool;
    }

    
    private DazzaAnimationState currentDazzaAnimation = DazzaAnimationState.DefaultSkin;
    private DazzaAnimationState previousDazzaAnimation = DazzaAnimationState.DefaultSkin;

    private DazzaAnimationState currentDazzaSkinAnimation = DazzaAnimationState.DefaultSkin;

    [SerializeField]
    private DazzaSkin dazzasSkin = DazzaSkin.Default;

    [SerializeField]
    private DazzaAnimationStruct[] dazzaAnimationStruct;

    private Dictionary<DazzaAnimationState, string> dazzaAnimationDictionary = new Dictionary<DazzaAnimationState, string>();

    private Animator dazzaAnimator;

    private DazzaController dazzaController;
    private PowerUpController powerUpController;

    private bool skinApplied = false;


    // Use this for initialization
    void Start ()
    {
        dazzaAnimator = GetComponent<Animator>();
        powerUpController = GetComponent<PowerUpController>();
        dazzaController = GetComponent<DazzaController>();

        ChooseSkin();

        for (int i=0; i < dazzaAnimationStruct.Length; i++)
        {
            dazzaAnimationDictionary.Add(dazzaAnimationStruct[i].animation, dazzaAnimationStruct[i].animationBool);
        }

        ApplyCorrectAnimation();

    }

    // Update is called once per frame
    void Update()
    {
        if (dazzaController.IsDazzaDead() == false)
        {
            if (powerUpController.GetSpeedBoostActive())
            {
                currentDazzaAnimation = DazzaAnimationState.SpeedBoost;

                if (previousDazzaAnimation != currentDazzaAnimation) ApplyCorrectAnimation();

                previousDazzaAnimation = currentDazzaAnimation;


            }
            else
            {
                if (dazzaController.IsGrounded() == false)
                {
                    if (dazzaController.GetJumping())
                    {
                        currentDazzaAnimation = DazzaAnimationState.Jumping;
                    }
                    else
                    {
                        currentDazzaAnimation = DazzaAnimationState.Falling;
                    }
                }
                else
                {
                    currentDazzaAnimation = currentDazzaSkinAnimation;
                }


                if (previousDazzaAnimation != currentDazzaAnimation) ApplyCorrectAnimation();
                previousDazzaAnimation = currentDazzaAnimation;
            }
        }
        else
        {
            currentDazzaAnimation = DazzaAnimationState.Death;

            if (previousDazzaAnimation != currentDazzaAnimation) ApplyCorrectAnimation();

            previousDazzaAnimation = currentDazzaAnimation;
        }
        
    }


    private void ApplyCorrectAnimation()
    {

        string animationParameter;

        dazzaAnimationDictionary.TryGetValue(currentDazzaAnimation, out animationParameter);

        Debug.Log(dazzaAnimator.parameterCount);

        for(int i=0; i < dazzaAnimator.parameterCount; i++)
        {
            if (animationParameter.Equals(dazzaAnimator.parameters[i].name))
            {
                
                dazzaAnimator.SetBool(animationParameter, true);
            }
            else
            {
                dazzaAnimator.SetBool(dazzaAnimator.parameters[i].name, false);
            }
        }

    }

    private void ChooseSkin()
    {
        switch(dazzasSkin)
        {
            case DazzaSkin.Default:
                currentDazzaSkinAnimation = DazzaAnimationState.DefaultSkin;
                break;

            case DazzaSkin.Police:
                currentDazzaSkinAnimation = DazzaAnimationState.PoliceSkin;
                break;

            case DazzaSkin.Shirtless:
                currentDazzaSkinAnimation = DazzaAnimationState.ShirtlessSkin;
                break;
        }

        currentDazzaAnimation = currentDazzaSkinAnimation;
    }
}
