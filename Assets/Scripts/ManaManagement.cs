using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Speed {
    public float runSpeed;
    public float runAcceleration;
    public float dashSpeed;
    public float jumpSpeed;
    public float gravityScale;
    public float maxAirSpeed;
}

public class ManaManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int manaCount;
    public int initialMana;
    public int maxMana;

    [SerializeField] private showManaBalls manaBar;

    public Speed defaultSpeed = new Speed() { runSpeed = 8f, runAcceleration = 1f, dashSpeed = 24f, jumpSpeed = 10f, gravityScale = 5f};

    public Speed[] speeds = new Speed[0];

    void Start()
    {
        setMana(initialMana);
    }
    
    public void setMana(int mana)
    {
        manaCount = Math.Clamp(mana, 0, maxMana);
        if (manaBar != null)
        {
            manaBar.UpdateHealthBar(manaCount);
        }
    }

    public void increaseMana(int count)
    {
        setMana(manaCount + count);
    }

    public void decreaseMana(int count)
    {
        setMana(manaCount - count);
    }

    public bool enoughMana(int count) {
        return manaCount >= count;
    }

    public int getCount() {
        return manaCount;
    }
    private Speed getSpeedData()
    {
        if (speeds.Length == 0 || manaCount == 0)
            return defaultSpeed;
        if (speeds.Length < manaCount)
            return speeds[speeds.Length - 1];
        return speeds[manaCount - 1];
    }

    public float getJumpSpeed()
    {
        return getSpeedData().jumpSpeed;
    }

    public float getDashSpeed()
    {
        return getSpeedData().dashSpeed;
    }

    public float getRunSpeed()
    {
        return getSpeedData().runSpeed;
    }

    public float getRunAcceleration()
    {
        return getSpeedData().runAcceleration;
    }

    public float getGravityScale()
    {
        return getSpeedData().gravityScale;
    }

    public float getMaxAirSpeed()
    {
        return getSpeedData().maxAirSpeed;
    }
}
