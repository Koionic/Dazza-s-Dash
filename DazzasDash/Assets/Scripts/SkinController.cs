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
    private DazzaAnimationState currentDazzaSkinJump = DazzaAnimationState.Jumping;
    private DazzaAnimationState currentDazzaSkinFall = DazzaAnimationState.Falling;
    private DazzaAnimationState currentDazzaSkinDeath = DazzaAnimationState.Death;
    private DazzaAnimationState currentDazzaSkinSpeedBoost = DazzaAnimationState.SpeedBoost;
    private DazzaAnimationState currentDazzaSkinRevive = DazzaAnimationState.Revive;

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
                currentDazzaAnimation = currentDazzaSkinSpeedBoost;

                if (previousDazzaAnimation != currentDazzaAnimation) ApplyCorrectAnimation();

                previousDazzaAnimation = currentDazzaAnimation;


            }
            else
            {
                if (dazzaController.IsGrounded() == false)
                {
                    if (dazzaController.GetJumping())
                    {
                        currentDazzaAnimation = currentDazzaSkinJump;
                    }
                    else
                    {
                        currentDazzaAnimation = currentDazzaSkinFall;
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
            if (dazzaController.IsDazzaBeingRevived())
            {
                Debug.Log("Play revive animation");
                currentDazzaAnimation = currentDazzaSkinRevive;

                if (previousDazzaAnimation != currentDazzaAnimation) ApplyCorrectAnimation();
                previousDazzaAnimation = currentDazzaAnimation;
            }
            else
            {
                currentDazzaAnimation = currentDazzaSkinDeath;

                if (previousDazzaAnimation != currentDazzaAnimation) ApplyCorrectAnimation();

                previousDazzaAnimation = currentDazzaAnimation;
            }
        }
        
    }


    private void ApplyCorrectAnimation()
    {

        string animationParameter;

        dazzaAnimationDictionary.TryGetValue(currentDazzaAnimation, out animationParameter);

        

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
                currentDazzaSkinJump = DazzaAnimationState.Jumping;
                currentDazzaSkinFall = DazzaAnimationState.Falling;
                currentDazzaSkinDeath = DazzaAnimationState.Death;
                currentDazzaSkinSpeedBoost = DazzaAnimationState.SpeedBoost;
                currentDazzaSkinRevive = DazzaAnimationState.Revive;
                break;

            case DazzaSkin.Police:
                currentDazzaSkinAnimation = DazzaAnimationState.PoliceSkin;
                currentDazzaSkinJump = DazzaAnimationState.PoliceJumping;
                currentDazzaSkinFall = DazzaAnimationState.PoliceFalling;
                currentDazzaSkinDeath = DazzaAnimationState.PoliceDeath;
                currentDazzaSkinSpeedBoost = DazzaAnimationState.PoliceSpeedBoost;
                currentDazzaSkinRevive = DazzaAnimationState.PoliceRevive;
                break;

            case DazzaSkin.Shirtless:
                currentDazzaSkinAnimation = DazzaAnimationState.ShirtlessSkin;
                currentDazzaSkinJump = DazzaAnimationState.ShirtlessJumping;
                currentDazzaSkinFall = DazzaAnimationState.ShirtlessFalling;
                currentDazzaSkinDeath = DazzaAnimationState.ShirtlessDeath;
                currentDazzaSkinSpeedBoost = DazzaAnimationState.ShirtlessSpeedBoost;
                currentDazzaSkinRevive = DazzaAnimationState.ShirtlessRevive;
                break;

            case DazzaSkin.Tradie:
                currentDazzaSkinAnimation = DazzaAnimationState.TradieSkin;
                currentDazzaSkinJump = DazzaAnimationState.TradieJumping;
                currentDazzaSkinFall = DazzaAnimationState.TradieFalling;
                currentDazzaSkinDeath = DazzaAnimationState.TradieDeath;
                currentDazzaSkinSpeedBoost = DazzaAnimationState.TradieSpeedBoost;
                currentDazzaSkinRevive = DazzaAnimationState.TradieRevive;
                break;
        }

        currentDazzaAnimation = currentDazzaSkinAnimation;
    }


    public void SetSkin(DazzaSkin inSkin)
    {
        dazzasSkin = inSkin;
    }
}
