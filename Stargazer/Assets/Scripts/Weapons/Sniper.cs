﻿using UnityEngine;
using UnityEngine.UI;

public class Sniper : Equipment {

    public GameObject bulletPrefab;
    private float currentReloadTime = 0;
    private const float MAX_RELOAD_TIME = 1.25f;
    private const float BULLET_SPEED = 25.0f;
    private const float BULLET_RANGE = 200.0f;

    void Start() {
        this.maxAmmoCount = 15;
        this.currentAmmoCount = this.maxAmmoCount;
        this.id = "Sniper";
    }

    public override void OnActivate() {
        if (this.currentAmmoCount > 0) {
            if (this.currentReloadTime <= 0) {

                Vector3 bulletDirection = Calculate.DirectionFromAngle(this.transform.eulerAngles);
                Vector3 position = this.transform.GetChild(0).position + bulletDirection * .2f;

                GameObject bulletClone = Instantiate(bulletPrefab, position, this.transform.rotation) as GameObject;
                bulletClone.GetComponent<LasBolt>().Init(bulletDirection, BULLET_SPEED, BULLET_RANGE);

                this.currentReloadTime = MAX_RELOAD_TIME;
                this.currentAmmoCount--;
            }
        }
    }


    void Update() {
        if (!(this.currentReloadTime <= 0)) {
            this.currentReloadTime -= Time.deltaTime;
        }
    }
}