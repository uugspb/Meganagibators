﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class UserSettings : MonoBehaviour {

    public const float ARM_PER_POINT = 1;
    public const float REG_PER_POINT = 0.1f;
    public const float DMG_PER_POINT = 1f;
    public const float MAX_HEALTH_PER_POINT = 5;

    private PlayerModel model;
    private GunModel gunModel;

    public Text AvailableSkills;

    public ParameterSlider MaxHealthSlider;
    public ParameterSlider ArmorSlider;
    public ParameterSlider RegenSlider;
    public ParameterSlider DamageSlider;

    public void Init(PlayerModel model, GunModel gunModel)
    {
        this.model = model;
        this.gunModel = gunModel;
        AvailableSkills.text = model.skillPoints.ToString();
        MaxHealthSlider.value = model.MaxHealth;
        MaxHealthSlider.OnAddButton += MaxHealthSlider_OnAddButton;
        ArmorSlider.value = model.Armor;
        ArmorSlider.OnAddButton += ArmorSlider_OnAddButton;
        RegenSlider.value = model.RegenPerSecond;
        RegenSlider.OnAddButton += RegenSlider_OnAddButton;
        DamageSlider.value = gunModel.Damage;
        DamageSlider.OnAddButton += DamageSlider_OnAddButton;
    }
    private void DamageSlider_OnAddButton(ParameterSlider obj)
    {
        var addingPoints = Math.Min(5, model.skillPoints);
        gunModel.Damage += DMG_PER_POINT * addingPoints / 5;
        DamageSlider.value = gunModel.Damage;
        model.skillPoints -= addingPoints;
        AvailableSkills.text = model.skillPoints.ToString();
    }

    private void RegenSlider_OnAddButton(ParameterSlider obj)
    {
        var addingPoints = Math.Min(5, model.skillPoints);
        gunModel.Damage += REG_PER_POINT * addingPoints;
        RegenSlider.value = model.RegenPerSecond;
        model.skillPoints -= addingPoints;
        AvailableSkills.text = model.skillPoints.ToString();
    }

    private void ArmorSlider_OnAddButton(ParameterSlider obj)
    {
        var addingPoints = Math.Min(5, model.skillPoints);
        model.Armor += ARM_PER_POINT* addingPoints;
        ArmorSlider.value = model.Armor;
        model.skillPoints -= addingPoints;
        AvailableSkills.text = model.skillPoints.ToString();
    }

    private void MaxHealthSlider_OnAddButton(ParameterSlider obj)
    {
        var addingPoints = Math.Min(5, model.skillPoints);
        model.MaxHealth += REG_PER_POINT * addingPoints;
        model.Health += REG_PER_POINT * addingPoints;
        MaxHealthSlider.value = model.MaxHealth;
        model.skillPoints -= addingPoints;
        AvailableSkills.text = model.skillPoints.ToString();
    }

    private void Update()
    {
        AvailableSkills.text = model.skillPoints.ToString();
    }
}
