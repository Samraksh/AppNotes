﻿using System;
using Microsoft.SPOT;
using Samraksh.SPOT.Hardware;

namespace Accel {
    public class Program {
        public static void Main() {
            var accel = new Accelerometer();	// The accelerometer object
            int rot = 0;
            int drawImage = 1;
            // Setting up display bitmap
            var LCD = new Bitmap(200, 200);
            var rotated = new Bitmap(200, 200);
            // importing bitmap from resource to display
            var image = new Bitmap(Resources.GetBytes(Resources.BinaryResources.logo), Bitmap.BitmapImageType.Bmp);

            accel.Initialize();

            while (true) {
                try {
                    int xVal = accel.GetX();
                    int yVal = accel.GetY();

                    if (xVal > 200) {
                        // rot 0
                        if (rot != 0) {
                            rot = 0;
                            drawImage = 1;
                        }
                    }
                    else if (xVal < -200) {
                        // rot 180
                        if (rot != 180) {
                            rot = 180;
                            drawImage = 1;
                        }
                    }
                    else if (yVal > 200) {
                        // rot 90 
                        if (rot != 90) {
                            rot = 90;
                            drawImage = 1;
                        }
                    }
                    else if (yVal < -200) {
                        // rot 270 
                        if (rot != 270) {
                            rot = 270;
                            drawImage = 1;
                        }
                    }

                    if (drawImage == 1) {
                        // clearing bitmap
                        LCD.Clear();
                        rotated.Clear();
                        // rotating image
                        if (rot == 0)
                            LCD.DrawImage(0, 0, image, 0, 0, 200, 142, 0xFF);
                        else if (rot == 90) {
                            rotated.RotateImage(rot, 0, 0, image, 0, 0, 200, 200, 0xff);
                            LCD.DrawImage(0, 0, rotated, 58, 0, 142, 200, 0xFF);
                        }
                        else if (rot == 180) {
                            LCD.RotateImage(rot, 0, 0, image, 0, 0, 200, 142, 0xff);
                        }
                        else if (rot == 270) {
                            rotated.RotateImage(rot, 0, 0, image, 0, 0, 200, 200, 0xff);
                            LCD.DrawImage(0, 0, rotated, 0, 0, 142, 200, 0xFF);
                        }
                        // drawing image to screen
                        LCD.Flush();
                        drawImage = 0;
                    }
                }
                catch (Exception ex) {
                    Debug.Print(ex.ToString());
                }
            }
        }
    }
}