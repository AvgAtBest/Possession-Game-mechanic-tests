using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterMovement))]
public class HealthController : MonoBehaviour
{
    public float sMaxHealth;
    public float sCurHealth;
    public float sHealthDecay = 10f;
    public float sHealthDecayTime = 1f;
    public float sStartTime = 1f;
    public float pMaxHealth;
    public float pCurHealth;
    public bool isPossessed;
    bool isDead = false;
    bool damaged;
    public CharacterMovement charM;

	public void Start ()
    {
        charM = this.GetComponent<CharacterMovement>();
        charM.isShadow = true;

        sMaxHealth = 200f;
        sCurHealth = sMaxHealth;

        pMaxHealth = 100f;
        pCurHealth = pMaxHealth;

	}
    public void Update()
    {
        if(charM.isShadow)
        {
            sHealthDecayTime -= Time.deltaTime;
            if (sHealthDecayTime < 0)
            {
                sCurHealth -= sHealthDecay;
                sHealthDecayTime = sStartTime;
                if (sCurHealth <= 0)
                {
                    Dead();
                    //isDead = true;
                    //charM.enabled = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (charM.isShadow == true)
            {
                charM.isShadow = false;
                charM.isPossessed = true;
                isPossessed = true;
                PuppetForm();
            }
            else 
            {
                ShadowForm();
            }
        }
    }
    public void ShadowForm()
    {
        isPossessed = false;
        charM.isPossessed = false;
        charM.isShadow = true;
        sCurHealth = sMaxHealth;
        
    }
    public void PuppetForm()
    {
        if (isPossessed == true)
        {
            pCurHealth = pMaxHealth;
            if (pCurHealth <= 0)
            {
                ShadowForm();
            }
        }
    }
    public void TakeDamage (int damage)
    {
        if (charM.isShadow)
        {
            sCurHealth -= damage;
            if (sCurHealth <= 0 && !isDead)
            {
                Dead();
            }
        }
        else
        {
            pCurHealth -= damage;
            if (pCurHealth <= 0)
            {
                ShadowForm();
                charM.isShadow = true;
                charM.isPossessed = false;
            }
        }

    }
    public void Dead()
    {
        isDead = true;
        charM.enabled = false;
    }
}
