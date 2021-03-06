﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Image keyImage;
    public Image schoolKeyImage;
    public Image bossKeyImage;
    private Color temp;

    void Update()
    {
		if (Application.loadedLevel != 6 || Application.loadedLevel != 7) {
			if (player.hasWaterKey) {
				temp = keyImage.color;
				temp.a = 1.0f;
				keyImage.color = temp;
			}
			if (player.hasSchoolKey) {
				temp = schoolKeyImage.color;
				temp.a = 1.0f;
				schoolKeyImage.color = temp;
			}
			if (player.hasBossKey) {
				temp = bossKeyImage.color;
				temp.a = 1.0f;
				bossKeyImage.color = temp;
			}
			if (!player.hasWaterKey) {
				temp = keyImage.color;
				temp.a = 0.0f;
				keyImage.color = temp;

			}
			if (!player.hasSchoolKey) {
				temp = schoolKeyImage.color;
				temp.a = 0.0f;
				schoolKeyImage.color = temp;
			}
			if (!player.hasBossKey) {
				temp = bossKeyImage.color;
				temp.a = 0.0f;
				bossKeyImage.color = temp;
			}
		}
	}
}
